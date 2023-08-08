using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Data.Contexts;
using TasksAPI.Domain.Ports.Data.Repositories;
using Task = TasksAPI.Domain.Models.Task;

namespace TasksAPI.Data.Repositories
{
    public class TaskRepository : BaseRepository<Task, Guid>, ITaskRepository
    {
        private readonly DataContext? _dataContext;

        public TaskRepository(DataContext? dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
