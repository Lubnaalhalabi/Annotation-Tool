using DatabaseContext.IRepos;
using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DatabaseContext.Repos
{
    public class InputTypeRepository : BaseRepo<InputType>, IInputTypeRepository
    {

        public InputTypeRepository(AnnotationToolContext context) : base(context)
        {

        }
     
    }
}
