using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = TasksAPI.Domain.Models.Task;

namespace TasksAPI.Domain.Services.Interfaces
{
    public interface ITaskDomainService : IDisposable
    {
        void Create(Task task);
        void Update(Task task);
        void Delete(Guid id, Guid userId);
        List<Task> GetAll(DateTime dataMin, DateTime dataMax, Guid userId);
        Task GetById(Guid id, Guid userId);
    }
}
