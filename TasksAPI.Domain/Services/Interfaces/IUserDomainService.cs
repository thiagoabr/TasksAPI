using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Domain.Models;

namespace TasksAPI.Domain.Services.Interfaces
{
    public interface IUserDomainService : IDisposable
    {
        void Add(User user);
        User Get(string name, string password);
    }
}
