using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Application.Dtos.Tasks;
using TasksAPI.Application.Dtos.Users;
using TasksAPI.Domain.Models;
using Task = TasksAPI.Domain.Models.Task;

namespace TasksAPI.Application.Mappings
{
    public class DtoToModelMap : Profile
    {
        public DtoToModelMap()
        {
            CreateMap<TaskCreateRequestDto, Task>()
                .AfterMap((dto, model) =>
                {
                    model.Id = Guid.NewGuid();
                    model.Date = DateTime.Parse(dto.Date);
                    model.Time = TimeSpan.Parse(dto.Time);
                });

            CreateMap<TaskUpdateRequestDto, Task>()
                .AfterMap((dto, model) =>
                {
                    model.Date = DateTime.Parse(dto.Date);
                    model.Time = TimeSpan.Parse(dto.Time);
                });

            CreateMap<UserCreateRequestDto, User>()
                .AfterMap((dto, model) =>
                {
                    model.Id = Guid.NewGuid();
                });
        }
    }
}
