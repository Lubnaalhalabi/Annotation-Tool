using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using App.ViewModels;
using System;
using DatabaseContext.UoW;
using DB.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace App.Controllers
{
    public class AccountantController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountantController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUnitOfWork uow) : base(uow)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect(Url.Action("Index", "Profile"));
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Verify that the user exists in the system
                    var user = _userManager.FindByEmailAsync(model.Email).Result;
                    if (user != null)
                    {
                        // Attempt to sign in the user with the provided password
                        var result = _signInManager.PasswordSignInAsync(user, model.Password,
                            true, false).Result;
                        if (result.Succeeded)
                            return Json(new
                            {
                                error = false,
                                message = "You have logged in successfully!!",
                            });
                    }
                    // User does not exist or login failed, return an error message
                    return Json(new
                    {
                        error = true,
                        message = "Invalid Credentials!!",
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
        public IActionResult Logout()
        {
            // Sign out the current user
            _signInManager.SignOutAsync();  
            // Return a JSON response indicating successful logout
            return Json(new
            {
                error = false,
                message = " Logged out successfully!!",
            });
        }
        [HttpPost]
        public IActionResult Create(RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userByEmail = _userManager.FindByEmailAsync(model.Email).Result;
                    if (userByEmail != null)
                    {
                        // User with the provided email already exists, return a validation error
                        return Json(new
                        {
                            error = true,
                            validationError = true,
                            message = "This email already exists!!",
                        });
                    }

                    var cur = Guid.NewGuid().ToString();
                    // Create a new user with the provided registration information
                    var user = new ApplicationUser
                    { Id = cur, UserName = cur, Email = model.Email, Name = model.Name, Address = model.Address, PhoneNumber = model.Phone };

                    // Attempt to create the new user
                    var result = _userManager.CreateAsync(user, model.Password).Result;
                    if (result.Succeeded)
                    {
                        // Add the "Annotator" role to the new user
                        _userManager.AddToRoleAsync(user, "Annotator").Wait();
                        
                        // Sign in the new user after successful creation
                        var result1 = _signInManager.PasswordSignInAsync(user, model.Password, true, false).Result;

                        // Return success message after user creation and login
                        return Json(new
                        {
                            error = false,
                            message = "New user added successfully!!",
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

        [Authorize(Roles = "Annotator, Manager,Admin")]
        public async Task<IActionResult> UpdateLastSeen()
        {
            try
            {
                // Get the currently logged-in user
                var user = await _userManager.GetUserAsync(User);
                // Update the user's last seen timestamp to the current time
                user.LastSeen = DateTime.Now;
                // Attempt to update the user's information in the UserManager
                var result = _userManager.UpdateAsync(user).Result;
                if (result.Succeeded)
                {
                    // Return a JSON response indicating a successful update
                    return Json(new
                    {
                        error = false
                    });
                }
                // User update failed, return an error message with details
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
    }
}
