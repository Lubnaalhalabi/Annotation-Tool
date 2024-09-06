using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseContext.IRepos;
using DatabaseContext.Repos;
using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseContext.Repos
{
    public class UsersTaskRepo : BaseRepo<UsersTask>, IUsersTaskRepo
    {
        public UsersTaskRepo(AnnotationToolContext context) : base(context)
        {

        }
       
    }
}
