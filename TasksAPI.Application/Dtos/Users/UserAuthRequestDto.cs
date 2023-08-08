using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksAPI.Application.Dtos.Users
{
    public class UserAuthRequestDto
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
    }
}
