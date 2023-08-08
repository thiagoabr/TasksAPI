using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Application.Dtos.Users;

namespace TasksAPI.Application.Ports.Application
{
    public interface IUserAppService : IDisposable
    {
        UserCreateResponseDto Create(UserCreateRequestDto dto);
        UserAuthResponseDto Authentication(UserAuthRequestDto dto);
    }
}
