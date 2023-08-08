using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = TasksAPI.Domain.Models.Task;

namespace TasksAPI.Domain.Ports.Data.Repositories
{
    public interface ITaskRepository : IBaseRepository<Task, Guid>
    {

    }
}
