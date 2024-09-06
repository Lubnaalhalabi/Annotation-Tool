using DatabaseContext.IRepos;
using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DatabaseContext.Repos
{
    public class AnnotationToolRepository : BaseRepo<AnnotationToolContext>, IAnnotationToolRepository
    {

        public AnnotationToolRepository(AnnotationToolContext context) : base(context)
        { 
        }

    }
}
