using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = TasksAPI.Domain.Models.Task;

namespace TasksAPI.Domain.Ports.Messages.Producers
{
    public interface ITaskMessageProducer
    {
        void CreateLog(Task task, OperationType operationType);
    }

    public enum OperationType
    {
        Create,
        Update,
        Delete
    }
}
