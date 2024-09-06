using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.ViewModels;
using DatabaseContext.UoW;
using DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Models;
using MongoDB.MongoUOW;
using Services.FormatDate;

namespace App.Controllers
{
    public class ReportController : BaseController
    {
        private readonly IMongoUOW _mongoUOW;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly FormatDate _formatDate;
       
        public ReportController(IUnitOfWork uow, IMongoUOW mongoUOW, UserManager<ApplicationUser> userManager, FormatDate formatDate) : base(uow)
        {
            _mongoUOW = mongoUOW;
            _userManager = userManager;
            _formatDate = formatDate;
        }
        [Authorize(Roles = "Manager,Admin")]
        [HttpGet]
        public async Task <IActionResult> Index(int taskId)
        {
            var mytask = _uow.TaskRepo.Get(taskId);

            //Chart of achievement for each annotator separately
            List<AnnotatorRecordReport> result = new List<AnnotatorRecordReport>();

            var user_task = _uow.TaskRepo.GetAnnotatorsForTask(taskId);

            foreach (var ut in user_task)
            {
                var res = await (_mongoUOW.Record.GetAnnotatorJobOnTaskForReport(mytask.DatasetId, ut.Id));
                AnnotatorRecordReport tem = new AnnotatorRecordReport
                {
                    AnnotatorName = ut.Name,
                    CompletionRate = res
                };
                result.Add(tem);
            }
            ViewBag.AnnotatorNameCompletionRate = result;
   
            var TaskAchiv = await (_mongoUOW.Record.GetCountOfAllRecordById(mytask.DatasetId));
            ViewBag.TaskAchievement = TaskAchiv;
           
            //Classes Chart
            List<ClassesRecordReport> resclass = new List<ClassesRecordReport>();
            var classes = _uow.ClassRepo.Find(t => t.TaskId == taskId).ToList();
            var dataset = _uow.TaskRepo.Get(taskId).DatasetId;
            foreach (var cls in classes)
            {
               // var res = await (_mongoUOW.Record.GetClassesDistributionAtTask(cls.Name, dataset));
                double res = 0;
                if (mytask.TaskTypeId == 2)
                    res = await (_mongoUOW.Record.GetClassesDistributionAtClassificationTask(cls.Name, dataset));
                else
                    res = await (_mongoUOW.Record.GetClassesDistributionAtTaggingTask(cls.Name, dataset));
                ClassesRecordReport tem = new ClassesRecordReport
                {
                    Class = cls.Name,
                    Rate = res
                };
                resclass.Add(tem);
            }
            ViewBag.ClassNameRate = resclass;
           
            // Achievement Chart
            List<DateTime> dateList = await (_mongoUOW.Record.GetAnnotationDateForTask(mytask.DatasetId));
            DateTime startDate = dateList.Min();
            DateTime endDate = mytask.Deadline;
            var numberOfInterval = 7;
            TimeSpan interval = TimeSpan.FromTicks((endDate - startDate).Ticks / numberOfInterval);

            List<DateTime> Divi = new List<DateTime>();
            DateTime temp = startDate;
            for (int i = 0; i < numberOfInterval; i++)
            {
                Divi.Add(temp);
                temp += interval;
            }
            if (!Divi.Contains(endDate))
            {
                Divi.Add(endDate);
            }
            List<string> DiviFormatted = Divi.Select(d => _formatDate.FormatDateBasedOnInterval(d, interval)).ToList();

            List<double> y_axis = new List<double>();
            List<double> y_axisOptimal = new List<double>();

            foreach (DateTime d in Divi)
            {
                y_axis.Add(dateList.Count(dt => dt <= d));
            }

            double endY = await _mongoUOW.Record.GetCountOfAllRecord(mytask.DatasetId);
            double yInterval = endY / (double)numberOfInterval;
            double tempY = 0;
            for (int i = 0; i < numberOfInterval; i++)
            {
                y_axisOptimal.Add(tempY);
                tempY += yInterval;
            }
            if (!y_axisOptimal.Contains(endY))
            {
                y_axisOptimal.Add(endY);
            }
            ViewBag.date = DiviFormatted;
            ViewBag.y_axis = y_axis;
            ViewBag.y_axisOptimal = y_axisOptimal;
            
            // agreement functions
            var numberofsamerecord = await _mongoUOW.Record.GetDoneRecordForAnnotatorsWiththesameresult(mytask.DatasetId);
            var numberofsolvedrecord = await _mongoUOW.Record.GetCountOfDoneRecord(mytask.DatasetId);
            ViewBag.observedAgreement = numberofsamerecord / numberofsolvedrecord * 100.0;
            
            //agreement by chance 
            var taskclass = _uow.ClassRepo.Find(t => t.TaskId == taskId).ToList();
            var annotator = _uow.TaskRepo.GetAnnotatorsForTask(taskId).ToList();
            double chance = 0;
            double tempt = 1;
            foreach (var c in taskclass)
            {
                foreach (var a in annotator)
                {
                    var x = (await _mongoUOW.Record.GetCountOfRecordToClass_AForAnnotator_S(mytask.DatasetId, c.Name, a.Id));
                    if (x != 0)
                        tempt = tempt * x;
                }

                chance += tempt / (numberofsolvedrecord * numberofsolvedrecord);
                tempt = 1;
            }
            ViewBag.agreementByChance = chance * 100.0;
            
            //Kappa
            var agreement = numberofsamerecord / numberofsolvedrecord;
            var agreementbychance = chance;

            if ((agreement - agreementbychance) / (1 - agreementbychance) < 0)
            {
                ViewBag.Kappa = 0;
            }
            else
                ViewBag.Kappa = ((agreement - agreementbychance) / (1 - agreementbychance)) * 100.0;
            return View();
                
        }
    }
}
