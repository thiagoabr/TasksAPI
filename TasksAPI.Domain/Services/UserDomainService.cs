using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Domain.Exceptions;
using TasksAPI.Domain.Models;
using TasksAPI.Domain.Ports.Data.Repositories;
using TasksAPI.Domain.Services.Interfaces;

namespace TasksAPI.Domain.Services
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository? _userRepository;

        public UserDomainService(IUserRepository? userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(User user)
        {
            var result = user.Validate;
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            if (_userRepository?.Get(u => u.Name.Equals(user.Name)) != null)
                throw new UserAlreadyExistsException();

            _userRepository?.Add(user);
        }

        public User Get(string name, string password)
        {
            var user = _userRepository?.Get(user => user.Name.Equals(name) && user.Password.Equals(password));
            if(user == null)
                throw new UserNotFoundException();
            
            return user;
        }

        public void Dispose()
        {
            _userRepository?.Dispose();
        }
    }
}
