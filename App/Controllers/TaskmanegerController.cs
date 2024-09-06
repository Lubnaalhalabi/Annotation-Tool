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
    public class TaskmanegerController : BaseController

    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPasswordGenerator _passwordGenerator;
        private int pageSize = 7;
        public TaskmanegerController(IUnitOfWork uow, UserManager<ApplicationUser> userManager, IPasswordGenerator passwordGenerator) : base(uow)
        {
            this._userManager = userManager;
            this._passwordGenerator = passwordGenerator;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                // Count the number of users in the "Manager" role
                int cur = (await _userManager.GetUsersInRoleAsync("Manager")).ToList().Count();
                // Calculate the number of pages needed for pagination based on users count and page size
                if (cur % this.pageSize != 0)
                    ViewBag.NumberOfPages = (cur / this.pageSize) + 1;
                else
                    ViewBag.NumberOfPages = cur / this.pageSize;
                // Return the view with pagination information
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
                // Get users from the "Manager" role, skipping based on pagination and taking the specified page size
                var users = (await _userManager.GetUsersInRoleAsync("Manager")).Skip((page - 1) * this.pageSize).Take(this.pageSize).ToList();
                // Return JSON response with fetched table data
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
                    // Check if a user with the given email already exists
                    var userByEmail = _userManager.FindByEmailAsync(model.Email).Result;
                    if (userByEmail != null)
                    {
                        // Return an error message if the email already exists
                        return Json(new
                        {
                            error = true,
                            message = "This email already exists!!",
                        });
                    }
                    // Generate a unique identifier for the new manager user
                    var cur = Guid.NewGuid().ToString();
                    var user = new ApplicationUser
                    { Id = cur, UserName = cur, Email = model.Email, Name = model.Name, Address = model.Address, PhoneNumber = model.Phone };
                    // Generate a random password for the new manager user
                    var pass = _passwordGenerator.GenerateRandomPassword();
                    // Attempt to create the new manager user
                    var result = _userManager.CreateAsync(user, pass).Result;
                    if (result.Succeeded)
                    {
                        // Add the "Manager" role to the new manager user
                        _userManager.AddToRoleAsync(user, "Manager").Wait();
                        // Return a success message along with the new manager's ID and generated password
                        return Json(new
                        {
                            error = false,
                            data = model.Id,
                            message = "New manager added successfully!!, and his passowrd is " + pass,
                        });
                    }
                    // Return an error message if user creation was not successful
                    return Json(new
                    {
                        error = true,
                        message = result.Errors.FirstOrDefault().Description,
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
        public async Task<IActionResult> Edit(AdminRegisterViewModel model)
        {
            
                if (ModelState.IsValid)
                {
                try
                {
                    // Check if a user with the given email already exists
                    var userByEmail = _userManager.FindByEmailAsync(model.Email).Result;
                    if (userByEmail != null)
                    {
                        return Json(new
                        {
                            error = true,
                            message = "This email already exists!!",
                        });
                    }
                    // Get the current user using the provided ID
                    var currentUser = await _userManager.FindByIdAsync(model.Id);
                    // Update the user's details with the provided model data
                    currentUser.Name = model.Name;
                    currentUser.Email = model.Email;
                    currentUser.PhoneNumber = model.Phone;
                    currentUser.Address = model.Address;
                    currentUser.PhoneNumber = model.Phone;
                    // Attempt to update the user's details
                    var result = _userManager.UpdateAsync(currentUser).Result;
                    if (result.Succeeded)
                    {
                        // Add the "Manager" role to the updated manager user
                        _userManager.AddToRoleAsync(currentUser, "Manager").Wait();
                        // Return a success message along with the updated manager's ID
                        return Json(new
                        {
                            error = false,
                            data = model.Id,
                            message = "Manager updated successfully!!",
                        });
                    }
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
                // Find the manager user using the provided ID
                var user = await _userManager.FindByIdAsync(Id);
                // Attempt to delete the manager user
                var result = _userManager.DeleteAsync(user).Result;
                if (result.Succeeded)
                {
                    // Return a success message if the user was deleted successfully
                    return Json(new
                    {
                        error = false,
                        message = "Manager deleted successfully!!",
                    });
                }
                // Return an error message if user deletion was not successful
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
                // Retrieve all users in the "Manager" role
                var users = await _userManager.GetUsersInRoleAsync("Manager");
                // Filter the retrieved users based on the provided value
                var filteredUsers = users.Where(u => u.Name.Contains(val)).ToList();
                // Return the filtered users as a JSON response along with success message
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
        public async Task<IActionResult> ViewTasks(string id)
        {
            try
            {
                // Find tasks associated with the provided manager ID
                var tasks = _uow.TaskRepo.Find(t => t.TaskManeger == id);
                // Set the "UsersTasks" property of each task to null to remove unnecessary data
                foreach (var t in tasks)
                {
                    t.UsersTasks = null;
                }
                // Return the list of tasks associated with the manager as a JSON response
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