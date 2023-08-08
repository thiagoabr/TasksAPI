using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Application.Dtos.Tasks;
using TasksAPI.Application.Ports.Application;
using TasksAPI.Domain.Services.Interfaces;
using Task = TasksAPI.Domain.Models.Task;

namespace TasksAPI.Application.Services
{
    public class TaskAppService : ITaskAppService
    {
        private readonly ITaskDomainService? _taskDomainService;
        private readonly IMapper? _mapper;

        public TaskAppService(ITaskDomainService? taskDomainService, IMapper? mapper)
        {
            _taskDomainService = taskDomainService;
            _mapper = mapper;
        }

        public TaskGetResponseDto Create(TaskCreateRequestDto dto)
        {
            var task = _mapper?.Map<Task>(dto);
            _taskDomainService?.Create(task);

            return _mapper?.Map<TaskGetResponseDto>(task);
        }

        public TaskGetResponseDto Update(TaskUpdateRequestDto dto)
        {
            var task = _mapper?.Map<Task>(dto);
            _taskDomainService?.Update(task);

            return _mapper?.Map<TaskGetResponseDto>(task);
        }

        public TaskGetResponseDto Delete(Guid? id, Guid? userId)
        {
            var task = _taskDomainService?.GetById(id.Value, userId.Value);

            _taskDomainService?.Delete(id.Value, userId.Value);
            return _mapper?.Map<TaskGetResponseDto>(task);
        }

        public List<TaskGetResponseDto> GetAll(DateTime dataMin, DateTime dataMax, Guid userId)
        {
            var tasks = _taskDomainService?.GetAll(dataMin, dataMax, userId);
            return _mapper?.Map<List<TaskGetResponseDto>>(tasks);
        }

        public TaskGetResponseDto GetById(Guid? id, Guid? userId)
        {
            var task = _taskDomainService?.GetById(id.Value, userId.Value);
            return _mapper?.Map<TaskGetResponseDto>(task);
        }

        public void Dispose()
        {
            _taskDomainService?.Dispose();
        }
    }
}
