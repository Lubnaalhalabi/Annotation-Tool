using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseContext.UoW;

namespace DB.Seeder
{
    public class InputTypeSeeder
    {
        public static void SeedInputType(IUnitOfWork _uwo)
        {
            if (_uwo.InputTypeRepo.Find(e => e.Name == "Img").Count() == 0) 
            {
                DB.Models.InputType cur = new DB.Models.InputType { Name = "Img", Description = "Task for annotating images" };
                _uwo.InputTypeRepo.Add(cur);
                _uwo.SaveChanges();
            }

            if (_uwo.InputTypeRepo.Find(e => e.Name == "Text").Count() == 0)
            {
                DB.Models.InputType cur = new DB.Models.InputType { Name = "Text", Description = "Task for annotating text" };
                _uwo.InputTypeRepo.Add(cur);
                _uwo.SaveChanges();
            }
        }
    }
}
