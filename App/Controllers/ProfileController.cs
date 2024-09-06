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
using DatabaseContext.UoW;
using App.ViewModels;
using Microsoft.AspNetCore.Identity;
using DB.Models;

namespace App.Controllers
{
    public class ProfileController : BaseController

    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ProfileController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUnitOfWork uow) : base(uow)
        {
                this._userManager = userManager;
            this._signInManager = signInManager;
        }

        [Authorize(Roles ="Manager,Admin,Annotator")]
        public async Task<IActionResult> Index(int mydo,int completedTask)
        {
            try
            {
                // Set ViewBag properties for "mydo" and "completedTask"
                ViewBag.mydo = mydo;
                ViewBag.completedTask = completedTask;
                // Get the currently logged-in user
                var user = await _userManager.GetUserAsync(User);
                // Create a new ProfileViewModel instance with user information
                ProfileViewModel newUser = new ProfileViewModel
                {
                    Name = user.Name,
                    Email = user.Email,
                    Phone = user.PhoneNumber,
                    Address = user.Address,
                    Img = user.Img,

                };
                // Check if the user is in the "Annotator" role
                if (await _userManager.IsInRoleAsync(user, "Annotator"))
                {
                    // Retrieve tasks associated with the annotator's ID
                    ViewBag.Tasks = _uow.TaskRepo.GetTasksForAnnotator(user.Id);
                }
                // Return the Index view with the prepared user information
                return View(newUser);
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
        public async Task<IActionResult> EditProfile(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {   try
                {
                    // Get the currently logged-in user
                    var userByEmail = await _userManager.GetUserAsync(User);
                    // Attempt to sign in the user with the provided old password
                    var result1 = _signInManager.PasswordSignInAsync(userByEmail, model.OldPassword, true, false).Result;
                    if (!result1.Succeeded)
                    {
                        // Return an error message if the old password is invalid
                        return Json(new
                        {
                            error = true,
                            validationError = true,
                            message = "Invalid old password!!",
                        });
                    }
                    // Retrieve the image data from the model
                    string imageFile = model.Img;
                    if (string.IsNullOrEmpty(imageFile))
                    {
                        // Return an error message if an image is not provided
                        return Json(new
                        {
                            error = true,
                            message = "Image is required",
                        });
                    }
                    // Convert and save the image data as a file
                    var base64Data = imageFile.Substring(imageFile.IndexOf(',') + 1);
                    var imageBytes = Convert.FromBase64String(base64Data);
                    var fileName = Guid.NewGuid().ToString() + ".jpg";
                    var rootPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
                    var wwwrootPath = Path.Combine(rootPath, "wwwroot");
                    var filePath = Path.Combine(wwwrootPath, "img", "users", fileName);
                    System.IO.File.WriteAllBytes(filePath, imageBytes);

                    // Update user information with the new values
                    userByEmail.Email = model.Email;
                    userByEmail.Name = model.Name;
                    userByEmail.Address = model.Address;
                    userByEmail.PhoneNumber = model.Phone;
                    userByEmail.Img = fileName;

                    // Attempt to update the user's information
                    var result = _userManager.UpdateAsync(userByEmail).Result;
                    if (result.Succeeded)
                    {
                        // Attempt to change the user's password
                        var result2 = _userManager.ChangePasswordAsync(userByEmail, model.OldPassword, model.NewPassword).Result;
                        if (result2.Succeeded)
                        {
                            // Return a success message after updating user information and password
                            return Json(new
                            {
                                error = false,
                                message = "Your Information updated successfully!!",
                            });
                        }
                        // Password change failed, return error messages
                        return Json(new
                        {
                            error = true,
                            message = result2.Errors.FirstOrDefault().Description,
                        });
                    }
                    // User information update failed, return error messages
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
    }
}










