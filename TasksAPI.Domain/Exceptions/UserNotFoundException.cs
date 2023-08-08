using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksAPI.Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public override string Message 
            => "Usuário não encontrado. Verifique os dados informados.";
    }
}
