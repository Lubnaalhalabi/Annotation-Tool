using DatabaseContext.IRepos;
using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DatabaseContext.Repos
{
    public class AnnotationClassMappingRepository : BaseRepo<AnnotationClassMapping>, IAnnotationClassMappingRepository
    {

        public AnnotationClassMappingRepository(AnnotationToolContext context) : base(context)
        {

        }
        
    }
}
