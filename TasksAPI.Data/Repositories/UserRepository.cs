using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Data.Contexts;
using TasksAPI.Domain.Models;
using TasksAPI.Domain.Ports.Data.Repositories;

namespace TasksAPI.Data.Repositories
{
    public class UserRepository : BaseRepository<User, Guid>, IUserRepository
    {
        private readonly DataContext? _dataContext;

        public UserRepository(DataContext? dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
