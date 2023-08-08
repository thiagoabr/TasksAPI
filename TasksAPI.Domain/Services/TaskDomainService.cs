using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Domain.Exceptions;
using TasksAPI.Domain.Ports.Data.Repositories;
using TasksAPI.Domain.Ports.Messages.Producers;
using TasksAPI.Domain.Services.Interfaces;
using Task = TasksAPI.Domain.Models.Task;

namespace TasksAPI.Domain.Services
{
    public class TaskDomainService : ITaskDomainService
    {
        private readonly ITaskRepository? _taskRepository;
        private readonly ITaskMessageProducer? _taskMessageProducer;

        public TaskDomainService(ITaskRepository? taskRepository, ITaskMessageProducer? taskMessageProducer)
        {
            _taskRepository = taskRepository;
            _taskMessageProducer = taskMessageProducer;
        }

        public void Create(Task task)
        {
            var result = task.Validate;
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            _taskRepository?.Add(task);
            _taskMessageProducer?.CreateLog(task, OperationType.Create);
        }

        public void Update(Task task)
        {
            var result = task.Validate;
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            if (GetById(task.Id.Value, task.UserId.Value) == null)
                throw new TaskNotFoundException();

            _taskRepository?.Update(task);
            _taskMessageProducer?.CreateLog(task, OperationType.Update);
        }

        public void Delete(Guid id, Guid userId)
        {
            var task = GetById(id, userId);

            if(task == null)
                throw new TaskNotFoundException();

            _taskRepository?.Delete(task);
            _taskMessageProducer?.CreateLog(task, OperationType.Delete);
        }

        public List<Task> GetAll(DateTime dataMin, DateTime dataMax, Guid userId)
        {
            return _taskRepository.GetAll(task => 
                    task.Date >= dataMin && task.Date <= dataMax && task.UserId == userId)
                .OrderByDescending(task => task.Date)
                .ToList();
        }

        public Task GetById(Guid id, Guid userId)
        {
            return _taskRepository.Get(task =>
                    task.Id == id && task.UserId == userId);
        }

        public void Dispose()
        {
            _taskRepository?.Dispose();
        }
    }
}
