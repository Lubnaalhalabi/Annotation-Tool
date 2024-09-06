using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DatabaseContext.UoW;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.MongoUOW;
using Services.Text.AITraining.Classification;

namespace Services.Text.AITraining
{
    public class TasksChecker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public TasksChecker(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Starting the tasks checker!!");
            using (var scope = _serviceProvider.CreateScope())
            {
                var _uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var _mongoUOW = scope.ServiceProvider.GetRequiredService<IMongoUOW>();
                while (!stoppingToken.IsCancellationRequested)
                {
                    DB.Models.Task task = _uow.TaskRepo.Find(u => u.Status == 5).FirstOrDefault();
                    if (task != null)
                    {
                        if (task.TaskTypeId == 1)
                        {
                            // tagining waiting for AI Training
                        }
                        else if (task.TaskTypeId == 2)
                        {
                            // classification waiting for AI Training
                            Trainer trainer = new Trainer(_uow, _mongoUOW);
                            await trainer.start(task.DatasetId);
                            task.Status = 1;
                            _uow.TaskRepo.Update(task);
                            _uow.SaveChanges();
                        }
                    }
                    Console.WriteLine("New Interval for tasks checker!!");
                    await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
                }
            }
        }
    }
}
