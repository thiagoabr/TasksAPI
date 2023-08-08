using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Application.Dtos.Tasks;

namespace TasksAPI.Application.Ports.Application
{
    public interface ITaskAppService : IDisposable
    {
        TaskGetResponseDto Create(TaskCreateRequestDto dto);
        TaskGetResponseDto Update(TaskUpdateRequestDto dto);
        TaskGetResponseDto Delete(Guid? id, Guid? userId);

        List<TaskGetResponseDto> GetAll(DateTime dataMin, DateTime dataMax, Guid userId);
        TaskGetResponseDto GetById(Guid? id, Guid? userId);
    }
}
