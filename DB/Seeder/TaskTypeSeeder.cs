using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseContext.UoW;

namespace DB.Seeder
{
    public class TaskTypeSeeder
    { 
        public static void SeedTaskType(IUnitOfWork _uwo)
        {
            if (_uwo.TaskTypeRepo.Find(e => e.Name == "Tagging").Count() == 0)
            {
                DB.Models.TaskType cur = new DB.Models.TaskType { Name = "Tagging", Description = "Tagging task" };
                _uwo.TaskTypeRepo.Add(cur);
                _uwo.SaveChanges();
            }
            if (_uwo.TaskTypeRepo.Find(e => e.Name == "Classification").Count() == 0)
            {
                DB.Models.TaskType cur = new DB.Models.TaskType { Name = "Classification", Description = "Classification task" };
                _uwo.TaskTypeRepo.Add(cur);
                _uwo.SaveChanges();
            }
        }

    }

}
