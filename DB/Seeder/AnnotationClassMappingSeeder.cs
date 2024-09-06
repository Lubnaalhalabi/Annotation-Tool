using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseContext.UoW;

namespace DB.Seeder
{
    public class AnnotationClassMappingSeeder
    {
        public static void SeedAnnotationClassMapping(IUnitOfWork _uwo)
        {
            if (_uwo.AnnotationClassMappingRepo.Find(e => e.Name == "OneClass").Count() == 0)
            {
                DB.Models.AnnotationClassMapping cur = new DB.Models.AnnotationClassMapping { Name = "OneClass", Description = "Task to choose one class" };
                _uwo.AnnotationClassMappingRepo.Add(cur);
                _uwo.SaveChanges();
            }
            if (_uwo.AnnotationClassMappingRepo.Find(e => e.Name == "MultiClasses").Count() == 0)
            {
                DB.Models.AnnotationClassMapping cur = new DB.Models.AnnotationClassMapping { Name = "MultiClasses", Description = "Task to choose many classes" };
                _uwo.AnnotationClassMappingRepo.Add(cur);
                _uwo.SaveChanges();
            }
        }
    }
}
