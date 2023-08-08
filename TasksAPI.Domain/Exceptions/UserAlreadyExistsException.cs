using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksAPI.Domain.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public override string Message 
            => "Este usuário já está cadastrado no sistema. Verifique os dados informados.";
    }
}
