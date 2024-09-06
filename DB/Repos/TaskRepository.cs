using DatabaseContext.IRepos;
using DB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext.Repos
{
    public class TaskRepository : BaseRepo<DB.Models.Task>, ITaskRepository
    {

        public TaskRepository(AnnotationToolContext context) : base(context)
        {

        }

        public async Task<IEnumerable<DB.Models.Task>> GetAllWithData(UserManager<ApplicationUser> _userManager)
        {
            var ret = _dbSet.Include(acm => acm.AnnotationClassMapping)
                    .Include(dp => dp.DistributionPolicy)
                    .Include(it => it.InputType)
                    .Include(tt => tt.TaskType)
                    .Include(c => c.Class)
                    .ToList();

            foreach(DB.Models.Task t in ret)
            {
                t.TaskManeger = (await _userManager.FindByIdAsync(t.TaskManeger)).Name;
                t.AnnotationClassMapping.Task = null;
                t.DistributionPolicy.Task = null;
                t.InputType.Task = null;
                t.TaskType.Task = null;
                foreach(Class c in t.Class)
                {
                    c.Task = null;
                }
            }
            return ret;
        }

        public DB.Models.Task GetWithData(int id)
        {
            var ret = _dbSet.Include(acm => acm.AnnotationClassMapping)
                                .Include(dp => dp.DistributionPolicy)
                                .Include(it => it.InputType)
                                .Include(tt => tt.TaskType)
                                .Include(c => c.Class)
                                .Where(i => i.Id == id)
                                .FirstOrDefault();

            ret.AnnotationClassMapping.Task = null;
            ret.DistributionPolicy.Task = null;
            ret.InputType.Task = null;
            ret.TaskType.Task = null;
            foreach (Class c in ret.Class)
            {
                c.Task = null;
            }
            return ret;
        }

        public async Task<List<ApplicationUser>> GetUsersWithLessTasks(int number, UserManager<ApplicationUser> _userManager)
        {
            var annotators = (await _userManager.GetUsersInRoleAsync("Annotator")).Select(user => user.Id).ToList();

            var ret = Context.Set<ApplicationUser>()
                            .Where(user => annotators.Contains(user.Id))
                            .Select(user => new
                            {
                                User = user,
                                TaskCount = user.UsersTasks.Count()
                            })
                            .OrderBy(u => u.TaskCount)
                            .Take(number)
                            .Select(u => u.User)
                            .ToList();
            return ret;
        }

        public List<DB.Models.Task> GetTasksForAnnotator(string annotatorId)
        {
            var annotators = _dbSet.Include(t => t.UsersTasks).ThenInclude(au => au.ApplicationUser)
                                    .ToList();

            var ret = new List<DB.Models.Task>();
            foreach(var an in annotators)
            {
                if (an.UsersTasks.Where(t => t.ApplicationUser.Id == annotatorId).Count() == 0) continue;
                ret.Add(an);
            }
            return ret;
        }

        public List<ApplicationUser> GetAnnotatorsForTask(int taskId)
        {
            var annotators = _dbSet.Where(u => u.Id == taskId)
                                    .Include(t => t.UsersTasks)
                                    .ThenInclude(au => au.ApplicationUser)
                                    .ToList();

            var ret = new List<ApplicationUser>();
            foreach (var an in annotators[0].UsersTasks)
            {
                ret.Add(an.ApplicationUser);
            }
            return ret;
        }
    }
}
