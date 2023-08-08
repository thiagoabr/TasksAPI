using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Domain.Models;

namespace TasksAPI.Domain.Ports.Data.Repositories
{
    public interface IUserRepository : IBaseRepository<User, Guid>
    {

    }
}
