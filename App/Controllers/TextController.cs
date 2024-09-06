using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseContext.UoW;
using DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Models;
using MongoDB.MongoUOW;

namespace App.Controllers
{
    [Authorize(Roles = "Annotator")]
    public class TextController : BaseController
    {
        private readonly IMongoUOW _mongoUOW;
        private readonly UserManager<ApplicationUser> _userManager;
        public TextController(IUnitOfWork uow, IMongoUOW mongoUOW, UserManager<ApplicationUser> userManager) : base(uow)
        {
            _mongoUOW = mongoUOW;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(int taskId)
        {
            try
            {
                // Find the task associated with the provided taskId
                var task = _uow.TaskRepo.Find(t => t.Id == taskId).FirstOrDefault();
                
                // Check if the task's status allows accessing the annotation index
                if (task.Status != 1 && task.Status != 0)
                {
                    return Redirect(Url.Action("Index", "Profile") + "?mydo=1&completedTask=2");
                }
                // Get the annotator's job record for the dataset
                RecordModel record = _mongoUOW.Record.GetAnnotatorJobOnDataset(task.DatasetId, (await _userManager.GetUserAsync(User)).Id, task.Random !=0).Result;
                // Get classes and other data for the view
                ViewBag.classes = _uow.ClassRepo.Find(t => t.TaskId == task.Id).ToList();
                ViewBag.classesType = task.AnnotationClassMappingId;
                ViewBag.taskType = task.TaskTypeId;
                ViewBag.taskId = taskId;
              
                // Check if AI-selected classes are available
                if (record != null)
                {
                    AnnotationResultModel aiSelectedClasses = _mongoUOW.Record.GetAIJobOnDataset(record._id, (await _userManager.GetUserAsync(User)).Id).Result;
                    if (aiSelectedClasses == null)
                        ViewBag.selectedAIClass = null;
                    else
                        ViewBag.selectedAIClass = aiSelectedClasses.Classes.First();
                }

                // Get counts of completed and AI records
                var completedRecords = _mongoUOW.Record.GetCountOfDoneRecord(task.DatasetId).Result;
                var AIRecords = _mongoUOW.Record.GetCountOfAIDoneRecord(task.DatasetId).Result;
                var allRecords = _mongoUOW.Record.GetCountOfAllRecord(task.DatasetId).Result;
                var waitingAnnotations = _mongoUOW.Record.GetCountOfWaitingAnnotations(task.DatasetId).Result;

                /* AI Training section */
                if (task.AiTraining != 0) 
                {
                    // Check if AI Training conditions are met
                    if (completedRecords >= allRecords * 50 / 100 && AIRecords == 0)
                    {
                        // Update task status and redirect to Profile index with query parameters
                        task.Status = 5;
                        _uow.TaskRepo.Update(task);
                        _uow.SaveChanges();
                        return Redirect(Url.Action("Index", "Profile") + "?mydo=1&completedTask=2");
                    }
                }
                /* finish AI Training section */

                // Check if an annotator job record exists
                if (record != null)
                    return View(record);
                else
                {
                    // Update task status if all records are completed
                    if (waitingAnnotations == 0)
                    {
                        task.Status = 3;
                        _uow.TaskRepo.Update(task);
                        _uow.SaveChanges();
                    }

                    return Redirect(Url.Action("Index", "Profile") + "?mydo=1&completedTask=1");
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
        }
        [HttpPost]
        public async Task<IActionResult> Save(string recordId, List<string> data ,int taskId)
        {
            try
            {
                // Find the task associated with the provided taskId
                var task = _uow.TaskRepo.Find(t => t.Id == taskId).FirstOrDefault();
                // Update the task's status to indicate annotation is in progress
                task.Status = 1;
                _uow.TaskRepo.Update(task);
                _uow.SaveChanges();
                // Create an annotation result model based on the provided data
                var result = new AnnotationResultModel
                {
                    Classes = data
                };
                // Save the annotator's job result on the record in MongoDB
                await _mongoUOW.Record.SaveAnnotatorJobOnRecord(recordId, (await _userManager.GetUserAsync(User)).Id, result);
                // Return a success message after saving the annotation result
                return Json(new
                {
                    error = false,
                    message = "Thanks for doing this record!!",
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
    }
}
