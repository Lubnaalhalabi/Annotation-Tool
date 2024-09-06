using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseContext.UoW;
using Microsoft.AspNetCore.Mvc;
using DB.Models ;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.IO;
using Services;
using Services.DataManager;
using MongoDB.MongoUOW;
using MongoDB.Models;

namespace App.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class TaskController  
        
        : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDataDecompresser _rarDecompressor;
        private readonly IDataManagerUOW _dataManager;
        private readonly IMongoUOW _mongoUOW;

        public TaskController(IUnitOfWork uow, UserManager<ApplicationUser> userManager, 
                                IDataDecompresser rarDecompressor, 
                                IDataManagerUOW dataManager,
                                IMongoUOW mongoUOW) : base(uow)
        {
            this._userManager = userManager;
            this._rarDecompressor = rarDecompressor;
            this._dataManager = dataManager;
            this._mongoUOW = mongoUOW;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetAll()
        {   try
            {
                // Retrieve all tasks with associated data using the Unit of Work
                var tasks = _uow.TaskRepo.GetAllWithData(_userManager).Result;
              
                // Return a JSON response containing the fetched table data
                return Json(new
                {
                    error = false,
                    message = "Table data fetched successfully",
                    data = tasks,
                });
            }
            catch (Exception e)
            {
                // An exception occurred, return an error message with the exception details
                return Json(new
                {
                    error = true,
                    message = "Exception Error: " + e.Message,
                });
            }
        }
        public IActionResult Create()
        {
            try
            {
                ViewBag.InputType = _uow.InputTypeRepo.GetAll().ToList();
                ViewBag.AnnotationClassMapping = _uow.AnnotationClassMappingRepo.GetAll().ToList();
                ViewBag.DistributionPolicy = _uow.DistributionPolicyRepo.GetAll().ToList();
                ViewBag.TaskType = _uow.TaskTypeRepo.GetAll().ToList();
                return View();
            }
            catch (Exception e)
            {
                return Json(new
                {
                    error = true,
                    message = "Exception Error: " + e.Message,
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(IFormFile data, DB.Models.Task task)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new
                    {
                        error = true,
                        validationError = true,
                        message = ModelState.Values,
                    });
                }
                // Check if the uploaded file is null or empty
                if (data == null || data.Length == 0)
                {
                    return Json(new
                    {
                        error = true,
                        message = "Please upload the file!!",
                    });
                }
            }
            catch (Exception e)
            {
                // An exception occurred, return an error message with the exception details
                return Json(new
                {
                    error = true,
                    message = "Exception Error: " + e.Message,
                });
            }

            try
            {
                // Assign annotators to the task
                task.UsersTasks = new List<UsersTask>();
                var annotators = _uow.TaskRepo.GetUsersWithLessTasks(task.NumberOfAnnotators, _userManager).Result;
                // Check if there are enough annotators for the task
                if (annotators.Count() < task.NumberOfAnnotators)
                {
                    return Json(new
                    {
                        error = true,
                        message = "There isn't enough annotators for this task, the available annotators are just " + annotators.Count() + "!!",
                    });
                }
                // Add annotators to the task's UsersTasks
                foreach (var an in annotators)
                {
                    task.UsersTasks.Add(new UsersTask { ApplicationUser = an });
                }

                // Assign the task manager
                task.TaskManeger = (await _userManager.GetUserAsync(User)).Id;

                // Get file extension and process the file accordingly
                string uploadedFileName = data.FileName;
                string fileExtension = Path.GetExtension(uploadedFileName);

                var csv = "";
                var rar = "";
                if (fileExtension == ".rar")
                {
                    // Upload the compressed file
                    var fileName = task.Name + "-" + DateTime.Now.Millisecond;
                    var rootPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
                    var wwwrootPath = Path.Combine(rootPath, "wwwroot");
                    var filePath = Path.Combine(wwwrootPath, "data", "compressed", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await data.CopyToAsync(stream);
                    }
             
                    // Extract the compressed file
                    var extractToPath = Path.Combine(wwwrootPath, "data", "extracted", fileName);
                    Directory.CreateDirectory(extractToPath);
                    _rarDecompressor.Decompress(filePath, extractToPath);
                    rar = extractToPath;
                }
                else if (fileExtension == ".csv")
                {
                    // Upload the compressed file
                    var fileName = task.Name + "-" + DateTime.Now.Millisecond;
                    var rootPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
                    var wwwrootPath = Path.Combine(rootPath, "wwwroot");
                    var filePath = Path.Combine(wwwrootPath, "data", "csv", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await data.CopyToAsync(stream);
                    }
                    csv = filePath;
                }              
                // Read the files
                List<string> stringData = new List<string>();
                if (task.InputTypeId == 2)
                {
                    try
                    {
                        // Call the ReadTextFromFolder function to get the contents of all files in the folder
                        if (fileExtension == ".rar")
                        {
                           stringData = _dataManager.TXT.Process(rar).ToList();
                        }
                        else if (fileExtension == ".csv")
                        {
                            stringData = _dataManager.CSV.Process(csv).ToList();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exception that might occur during the process
                        return Json(new
                        {
                            error = true,
                            message = $"Error: {ex.Message}",
                        });

                    }
                }
                else if (task.InputTypeId == 1)
                {
                    return Json(new
                    {
                        error = true,
                        message = "Img annotation is not supported yet!!",
                    });
                }

                // Save the dataset to Mongo
                DatasetModel dataSet = new DatasetModel
                {
                    Type = task.InputTypeId,
                    CreatedAt = DateTime.Now
                };
                _mongoUOW.Dataset.Create(dataSet);
                task.DatasetId = dataSet._id;

                // Save the records to the Mongo
                if (task.DistributionPolicyId == 1)
                {
                    List<AnnotationModel> annotatorsMappingList = new List<AnnotationModel>();
                    foreach (var an in annotators)
                    {
                        annotatorsMappingList.Add(new AnnotationModel
                        {
                            AnnotationResult = null,
                            AIAnnotationResult = null,
                            AnntatorId = an.Id,
                            AnnotationDate = DateTime.Now,
                        });
                    }

                    foreach (string txt in stringData)
                    {
                        _mongoUOW.Record.Create(new RecordModel
                        {
                            DatasetId = dataSet._id,
                            Data = txt,
                            Annotation = annotatorsMappingList
                        });
                    }
                }
                else if (task.DistributionPolicyId == 2)
                {

                }
                else if (task.DistributionPolicyId == 3)
                {
                    int cnt = 0;
                    foreach (string txt in stringData)
                    {
                        var cur = new List<AnnotationModel>();
                        cur.Add(new AnnotationModel
                        {
                            AnnotationResult = null,
                            AIAnnotationResult = null,
                            AnntatorId = annotators[cnt++].Id,
                            AnnotationDate = DateTime.Now,
                        });

                        if (cnt == annotators.Count()) cnt = 0;

                        _mongoUOW.Record.Create(new RecordModel
                        {
                            DatasetId = dataSet._id,
                            Data = txt,
                            Annotation = cur
                        });
                    }
                }
                task.CreatedAt = DateTime.Now;
                _uow.TaskRepo.Add(task);
                _uow.SaveChanges();

                return Json(new
                {
                    error = false,
                    message = "New task added successfully!!",
                });
            }
            catch(Exception e)
            {
                return Json(new
                {
                    error = true,
                    message = "Exception Error: " + e.Message,
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DB.Models.Task task)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var cls = _uow.ClassRepo.Find(i => i.TaskId == task.Id).ToList();
                    foreach (var c in cls)
                    {
                        _uow.ClassRepo.Remove(c);
                        _uow.SaveChanges();
                    }

                    var user = await _userManager.GetUserAsync(User);
                    // Update the task's task manager and save changes
                    task.TaskManeger = user.Id;
                    _uow.TaskRepo.Update(task);
                    _uow.SaveChanges();
                    return Json(new
                    {
                        error = false,
                        message = "Task updated successfully!!",
                    });
                }
                return Json(new
                {
                    error = true,
                    validationError = true,
                    message = ModelState.Values,
                });
            }
            catch (Exception e)
            {
                // An exception occurred, return an error message with the exception details
                return Json(new
                {
                    error = true,
                    message = "Exception Error: " + e.Message,
                });
            }
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            try
            {
                
                var cls = _uow.ClassRepo.Find(i => i.TaskId == Id).ToList();

                foreach (var c in cls)
                {
                    _uow.ClassRepo.Remove(c);
                    _uow.SaveChanges();
                }

                var ut = _uow.UsersTaskRepo.Find(i => i.Task.Id == Id).ToList();
                foreach (var c in ut)
                {
                    _uow.UsersTaskRepo.Remove(c);
                    _uow.SaveChanges();
                }

                DB.Models.Task task = _uow.TaskRepo.Get(Id);
                _uow.TaskRepo.Remove(task);
                _uow.SaveChanges();
                /*
                DB.Models.Task task = _uow.TaskRepo.Get(Id);
                task.Status = 4;
                _uow.TaskRepo.Update(task);
                _uow.SaveChanges();
                */
                return Json(new
                {
                    error = false,
                    message = "Task canceled successfully!!",
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    error = true,
                    message = "Exception Error: " + e.Message,
                });
            }
        }
        public IActionResult Edit(int Id)
        {
            try
            {
                var task = _uow.TaskRepo.GetWithData(Id);
                ViewBag.InputType = _uow.InputTypeRepo.GetAll().ToList();
                ViewBag.AnnotationClassMapping = _uow.AnnotationClassMappingRepo.GetAll().ToList();
                ViewBag.DistributionPolicy = _uow.DistributionPolicyRepo.GetAll().ToList();
                ViewBag.TaskType = _uow.TaskTypeRepo.GetAll().ToList();
                return View(task);
            }
            catch (Exception e)
            {
                return Json(new
                {
                    error = true,
                    message = "Exception Error: " + e.Message,
                });
            }
        }
        //Finished tasks
        public IActionResult FinishedTasksPersentage()
        {
            double tasks = _uow.TaskRepo.GetAll().Count();
            double finished = _uow.TaskRepo.Find(t => t.Status == 3).Count();
            if (tasks != 0 && finished != 0)
            {
                return Json(new
                {
                    error = false,
                    messege = (finished / tasks * 100.0).ToString("0.0")
                });
            }
            else
            {
                return Json(new
                {
                    error = false,
                    messege = (0 * 100.0).ToString("0.0")
                });
            }
               
        }
    }
}
