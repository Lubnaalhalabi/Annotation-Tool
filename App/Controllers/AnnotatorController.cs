using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using App.ViewModels;
using DatabaseContext.UoW;
using Microsoft.AspNetCore.Identity;
using DB.Models;
using System.Text;
using System.Security.Cryptography;
using Services.Password;

namespace App.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AnnotatorController : BaseController

    {
        private readonly UserManager<ApplicationUser> _userAnnotator;
        private readonly IPasswordGenerator _passwordGenerator;
        private int pageSize = 7;
        public AnnotatorController(IUnitOfWork uow, UserManager<ApplicationUser> userManager, IPasswordGenerator passwordGenerator) : base(uow)
        {
            this._userAnnotator = userManager;
            this._passwordGenerator = passwordGenerator;

        }
        public async Task<IActionResult> Index()
        {
            try
            {
                // Retrieve the count of users in the "Annotator" role
                int cur = (await _userAnnotator.GetUsersInRoleAsync("Annotator")).ToList().Count();
                // Calculate the number of pages based on the user count and page size
                if (cur % this.pageSize != 0)
                    ViewBag.NumberOfPages = (cur / this.pageSize) + 1;
                else
                    ViewBag.NumberOfPages = cur / this.pageSize;
                // Return the Index view, which may use the ViewBag.NumberOfPages for pagination
                return View();
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
        public async Task<IActionResult> GetAll(int page)
        {
            try
            {
                // Retrieve a list of users in the "Annotator" role based on pagination
                var users = (await _userAnnotator.GetUsersInRoleAsync("Annotator")).Skip((page - 1) * this.pageSize).Take(this.pageSize).ToList();

                // Return a JSON response containing the fetched table data
                return Json(new
                {
                    error = false,
                    message = "Table data fetched successfully",
                    data = users
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
        public IActionResult Create(AdminRegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Check if a user with the provided email already exists
                    var userByEmail = _userAnnotator.FindByEmailAsync(model.Email).Result;
                    if (userByEmail != null)
                    {
                        // Return an error message if the email is already in use
                        return Json(new
                        {
                            error = true,
                            message = "This email already exists!!",
                        });
                    }
                    var cur = Guid.NewGuid().ToString();
                    // Create a new ApplicationUser with the provided registration information
                    var user = new ApplicationUser
                    { Id = cur, UserName = cur, Email = model.Email, Name = model.Name, Address = model.Address, PhoneNumber = model.Phone };
                    // Generate a random password for the new user
                    var pass = _passwordGenerator.GenerateRandomPassword();
                    // Attempt to create the new user with the generated password
                    var result = _userAnnotator.CreateAsync(user, pass).Result;
                    if (result.Succeeded)
                    {
                        // Add the "Annotator" role to the new user
                        _userAnnotator.AddToRoleAsync(user, "Annotator").Wait();
                        // Return a success message with the generated password
                        return Json(new
                        {
                            error = false,
                            data = model.Id,
                            message = "New annotator added successfully!!, and his passowrd is " + pass,
                        });
                    }
                    // User creation failed, return error messages
                    return Json(new
                    {
                        error = true,
                        message = result.Errors.FirstOrDefault().Description,
                    });
                }
                // Model state is not valid, return validation error messages
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
        public async Task<IActionResult> Edit(AdminRegisterViewModel model)
        {   
            if (ModelState.IsValid)
            {
                try
                {
                    // Check if a user with the provided email already exists
                    var userByEmail = _userAnnotator.FindByEmailAsync(model.Email).Result;
                    if (userByEmail != null)
                    {
                        // Return an error message if the email is already in use
                        return Json(new
                        {
                            error = true,
                            message = "This email already exists!!",
                        });
                    }
                    // Retrieve the current user using the provided model's ID
                    var currentUser = await _userAnnotator.FindByIdAsync(model.Id);
                    // Update the user's information with the values from the model
                    currentUser.Name = model.Name;
                    currentUser.Email = model.Email;
                    currentUser.PhoneNumber = model.Phone;
                    currentUser.Address = model.Address;
                    currentUser.PhoneNumber = model.Phone;
                    // Attempt to update the user's information in the UserManager
                    var result = _userAnnotator.UpdateAsync(currentUser).Result;
                    if (result.Succeeded)
                    {
                        // Add the "Annotator" role to the updated user
                        _userAnnotator.AddToRoleAsync(currentUser, "Annotator").Wait();
                        // Return a success message after updating the annotator
                        return Json(new
                        {
                            error = false,
                            data = model.Id,
                            message = "Annotator updated successfully!!",
                        });
                    }
                    // User update failed, return error messages
                    return Json(new
                    {
                        error = true,
                        message = result.Errors.FirstOrDefault().Description,
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
            // Model state is not valid, return validation error messages
            return Json(new
            {
                error = true,
                validationError = true,
                message = ModelState.Values,
            });
           
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string Id)
        {
            try
            {
                // Find and remove all UserTasks associated with the user
                var ut = _uow.UsersTaskRepo.Find(i => i.ApplicationUser.Id == Id).ToList();
                foreach (var c in ut)
                {
                    _uow.UsersTaskRepo.Remove(c);
                    _uow.SaveChanges();
                }

                // Find the user to be deleted by their ID
                var user = await _userAnnotator.FindByIdAsync(Id);

                // Attempt to delete the user using the UserManager
                var result = _userAnnotator.DeleteAsync(user).Result;
                if (result.Succeeded)
                {
                    // Return a JSON response indicating successful deletion
                    return Json(new
                    {
                        error = false,
                        message = "Annotator deleted successfully!!",
                    });
                }

                // User deletion failed, return an error message with details
                return Json(new
                {
                    error = true,
                    message = result.Errors.FirstOrDefault().Description,
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

        public async Task<IActionResult> Search(string val)
        {
            try
            {
                // Retrieve a list of all users in the "Annotator" role
                var users = await _userAnnotator.GetUsersInRoleAsync("Annotator");
                // Filter the users based on the provided search value
                var filteredUsers = users.Where(u => u.Name.Contains(val)).ToList();
                // Return a JSON response containing the fetched and filtered users
                return Json(new
                {
                    error = false,
                    message = "Your user fetched successfully!",
                    data = filteredUsers,
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

        public async Task<IActionResult> ViewTasks (string id)
        {
            try
            {
                // Retrieve tasks associated with the provided annotator's ID
                var tasks = _uow.TaskRepo.GetTasksForAnnotator(id);
                // Remove UserTasks references from tasks to prevent circular referencing
                foreach (var t in tasks)
                {
                    t.UsersTasks = null;
                }
                // Return a JSON response containing the tasks for the annotator
                return Json(new
                {
                    error = false,
                    tasks = tasks,
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