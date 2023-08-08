using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksAPI.Domain.Exceptions
{
    public class TaskNotFoundException : Exception
    {
        public override string Message 
            => "Tarefa não encontrada. Verifique os dados informados.";
    }
}
