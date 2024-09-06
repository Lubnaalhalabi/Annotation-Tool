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
    public class ClassRepository : BaseRepo<Class>, IClassRepository
    {

        public ClassRepository(AnnotationToolContext context) : base(context)
        {

        }
    
    }
}
