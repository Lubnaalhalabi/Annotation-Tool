using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseContext.UoW;

namespace DB.Seeder
{
    public class DistributionPolicySeeder
    {
        public static void SeedDistributionPolicy(IUnitOfWork _uwo)
        {
            if (_uwo.DistributionPolicyRepo.Find(e => e.Name == "All to all").Count() == 0)
            {
                DB.Models.DistributionPolicy cur = new DB.Models.DistributionPolicy {Name = "All to all", Description = "All data distributed on annotators" };
                _uwo.DistributionPolicyRepo.Add(cur);
                _uwo.SaveChanges();
            }
            if (_uwo.DistributionPolicyRepo.Find(e => e.Name == "With intersection").Count() == 0)
            {
                DB.Models.DistributionPolicy cur = new DB.Models.DistributionPolicy { Name = "With intersection", Description = "Distribution with overlap ratio" };
                _uwo.DistributionPolicyRepo.Add(cur);
                _uwo.SaveChanges();
            }

            if (_uwo.DistributionPolicyRepo.Find(e => e.Name == "Without intersection").Count() == 0)
            {
                DB.Models.DistributionPolicy cur = new DB.Models.DistributionPolicy { Name = "Without intersection", Description = "Distribution without overlap ratio" };
                _uwo.DistributionPolicyRepo.Add(cur);
                _uwo.SaveChanges();
            }
        }

    }
}
