using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DB.Models;
using Microsoft.AspNetCore.Identity;

namespace DatabaseContext.IRepos
{
    public interface ITaskRepository : IBaseRepo <DB.Models.Task>
    {
        Task<List<ApplicationUser>> GetUsersWithLessTasks(int number, UserManager<ApplicationUser> _userManager);
        Task<IEnumerable<DB.Models.Task>> GetAllWithData(UserManager<ApplicationUser> userManager);
        DB.Models.Task GetWithData(int id);
        public List<DB.Models.Task> GetTasksForAnnotator(string annotatorId);
        public List<ApplicationUser> GetAnnotatorsForTask(int taskId);
    }
}

