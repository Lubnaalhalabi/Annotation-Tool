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
using MongoDB.MongoUOW;
using Microsoft.AspNetCore.Identity;
using DB.Models;
namespace App.Controllers
{
    [Authorize(Roles = "Manager,Admin")]
    public class DashboardController : BaseController
    {

        private readonly IMongoUOW _mongoUOW;
        private readonly UserManager<ApplicationUser> _userManager;
        public DashboardController(IUnitOfWork uow, IMongoUOW mongoUOW, UserManager<ApplicationUser> userManager) : base(uow)
        {
            _mongoUOW = mongoUOW;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            //Cards
            var annotators = (await _userManager.GetUsersInRoleAsync("Annotator")).ToList().Count();
            var managers = (await _userManager.GetUsersInRoleAsync("Manager")).ToList().Count();
            var tasks = _uow.TaskRepo.GetAll().ToList().Count();
            var completedtask = _uow.TaskRepo.Find(t => t.Status == 3).ToList().Count();
            var taskinprosses = _uow.TaskRepo.Find(t => t.Status == 1).ToList().Count();
            var taskWaiting = _uow.TaskRepo.Find(t => t.Status == 0).ToList().Count();
            var onlineAnnotators = (await _userManager.GetUsersInRoleAsync("Annotator")).Where(u => u.LastSeen >= DateTime.Now.AddMinutes(-2)).Count();
            var onlineManagers = (await _userManager.GetUsersInRoleAsync("Manager")).Where(u => u.LastSeen >= DateTime.Now.AddMinutes(-2)).Count();

            ViewBag.numberofannotators = annotators;
            ViewBag.numberofmanagers = managers;
            ViewBag.numberoftasks = tasks;
            ViewBag.numberofcompletedtask = completedtask;
            ViewBag.numberoftaskinprosses = taskinprosses;
            ViewBag.numberoftaskWaiting = taskWaiting;
            ViewBag.onlineAnnotators = onlineAnnotators;
            ViewBag.onlineManagers = onlineManagers;
            //Annotation information
            double lastday = await _mongoUOW.Record.GetDoneRecordForDate(DateTime.Now.AddDays(-1));
            double lastweek = await _mongoUOW.Record.GetDoneRecordForDate(DateTime.Now.AddDays(-7));
            double lastmonth = await _mongoUOW.Record.GetDoneRecordForDate(DateTime.Now.AddDays(-30));

            ViewBag.lastday = lastday;
            ViewBag.lastweek = lastweek;
            ViewBag.lastmonth = lastmonth;
            //Added tasks
            List<int> y_axis = new List<int>();
            List<string> x_axis = new List<string>();
            for (int i=0; i<7; i++)
            {
                y_axis.Add(_uow.TaskRepo.Find(t => t.CreatedAt >= DateTime.Now.AddDays(i-7)).ToList().Count());
                x_axis.Add(DateTime.Now.AddDays(i).DayOfWeek.ToString());
            }
            ViewBag.AddTaskY = y_axis;
            ViewBag.AddTaskX = x_axis;

            return View();
        }
    }
}