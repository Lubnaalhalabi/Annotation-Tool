using System;
using System.Diagnostics;
using System.Linq;
using App.Models;
using DatabaseContext.UoW;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace App.Controllers 
{ 

    public class HomeController : BaseController
    {
        public HomeController(IUnitOfWork uow) : base(uow)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
