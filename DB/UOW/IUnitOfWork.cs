using DatabaseContext.IRepos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseContext.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        public IAnnotationClassMappingRepository  AnnotationClassMappingRepo { get; }
        public IInputTypeRepository InputTypeRepo { get; }
        public IAnnotationToolRepository AnnotationToolRepo { get; }
        public IClassRepository ClassRepo { get; }
        public IDistributionPolicyRepository DistributionPolicyRepo { get; }
        public ITaskTypeRepository TaskTypeRepo { get; }
        public ITaskRepository TaskRepo { get; }
        public IUsersTaskRepo UsersTaskRepo { get; }
        public int SaveChanges();
    }
}