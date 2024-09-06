using DatabaseContext.IRepos;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DatabaseContext.Repos
{
    public class DistributionPolicyRepository : BaseRepo<DistributionPolicy>, IDistributionPolicyRepository
    {

        public DistributionPolicyRepository(AnnotationToolContext context) : base(context)
        {

        }
    }
}
