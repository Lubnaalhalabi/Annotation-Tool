using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DatabaseContext.IRepos
{
    public interface IBaseRepo<Entity> where Entity : class
    {
        public void Add(Entity entity);

        public void Update(Entity entity);

        void Remove(Entity entity); 

        IEnumerable<Entity> GetAll();

        IEnumerable<Entity> GetPaginated(int pageIndex, int pageSize);

        Entity Get(int id);

        IEnumerable<Entity> Find(Expression<Func<Entity, bool>> predicate);

    }
}
