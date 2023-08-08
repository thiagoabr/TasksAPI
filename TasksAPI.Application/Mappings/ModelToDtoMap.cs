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
    public class ModelToDtoMap : Profile
    {
        public ModelToDtoMap()
        {
            CreateMap<Task, TaskGetResponseDto>()
                .AfterMap((model, dto) => {
                    dto.Date = model.Date?.ToString("dd/MM/yyyy");
                    dto.Time = model.Time?.ToString(@"hh\:mm\:ss");
                });

            CreateMap<User, UserCreateResponseDto>()
                .AfterMap((model, dto) => {
                    dto.CreatedAt = DateTime.Now;
                });

            CreateMap<User, UserAuthResponseDto>();
        }
    }
}



