using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Application.Dtos.Users;
using TasksAPI.Application.Ports.Application;
using TasksAPI.Application.Security;
using TasksAPI.Domain.Models;
using TasksAPI.Domain.Services.Interfaces;

namespace TasksAPI.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserDomainService? _userDomainService;
        private readonly JwtTokenCreator? _jwtTokenCreator;
        private readonly JwtBearerSettings? _jwtBearerSettings;
        private readonly IMapper? _mapper;

        public UserAppService(IUserDomainService? userDomainService, JwtTokenCreator? jwtTokenCreator, IOptions<JwtBearerSettings>? jwtBearerSettings, IMapper? mapper)
        {
            _userDomainService = userDomainService;
            _jwtTokenCreator = jwtTokenCreator;
            _jwtBearerSettings = jwtBearerSettings.Value;
            _mapper = mapper;
        }

        public UserCreateResponseDto Create(UserCreateRequestDto dto)
        {
            var user = _mapper?.Map<User>(dto);
            _userDomainService?.Add(user);

            return _mapper?.Map<UserCreateResponseDto>(user);
        }

        public UserAuthResponseDto Authentication(UserAuthRequestDto dto)
        {
            var user = _userDomainService?.Get(dto.Name, dto.Password);

            var response = _mapper?.Map<UserAuthResponseDto>(user);
            response.AccessToken = _jwtTokenCreator?.CreateToken(user.Id.ToString());
            response.Expiration = DateTime.Now.AddMinutes(Convert.ToDouble(_jwtBearerSettings?.ExpirationInMinutes));

            return response;
        }

        public void Dispose()
        {
            _userDomainService?.Dispose();
        }
    }
}
