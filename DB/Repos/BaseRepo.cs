using DatabaseContext.IRepos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DatabaseContext.Repos
{
    public class BaseRepo<Entity> : IBaseRepo<Entity> where Entity : class
    {
        protected readonly DbContext Context;
        protected DbSet<Entity> _dbSet;
        public BaseRepo(DbContext context)
        {
            Context = context;
            _dbSet = Context.Set<Entity>();
        }

        public Entity Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<Entity> GetPaginated(int pageIndex, int pageSize)
        {
            return  _dbSet.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
        }

        public IEnumerable<Entity> GetAll()
        {
            return _dbSet.ToList();
        }
        public IEnumerable<Entity> Find(Expression<Func<Entity, bool> > predicate)
        {
            return _dbSet.Where(predicate);
        }

        public void Add(Entity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(Entity entity)
        {
            _dbSet.Update(entity);
        }

        public void Remove(Entity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
