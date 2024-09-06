using DatabaseContext.IRepos;
using DB.Models;
using DatabaseContext.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseContext.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly AnnotationToolContext _context;
        public UnitOfWork(AnnotationToolContext context) 
        {
            _context = context;

            // VERY IMPORTANT:
            // Use the same context to initialize all repositories
            AnnotationClassMappingRepo = new AnnotationClassMappingRepository(_context);
            InputTypeRepo = new InputTypeRepository(_context);
            AnnotationToolRepo = new AnnotationToolRepository(_context);
            ClassRepo = new ClassRepository(_context);
            DistributionPolicyRepo = new DistributionPolicyRepository(_context);
            TaskTypeRepo = new TaskTypeRepository(_context);
            TaskRepo = new TaskRepository(_context);
            UsersTaskRepo = new UsersTaskRepo(_context);
        }
        public IAnnotationClassMappingRepository AnnotationClassMappingRepo { get; private set; }
        public IInputTypeRepository InputTypeRepo { get; private set; }
        public IAnnotationToolRepository AnnotationToolRepo { get; private set; }
        public IClassRepository ClassRepo { get; private set; }
        public IDistributionPolicyRepository DistributionPolicyRepo { get; private set; }
        public ITaskTypeRepository TaskTypeRepo { get; private set; }
        public ITaskRepository TaskRepo { get; private set; }
        public IUsersTaskRepo UsersTaskRepo { get; private set; }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
