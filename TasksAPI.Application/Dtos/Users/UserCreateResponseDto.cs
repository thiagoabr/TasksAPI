using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksAPI.Application.Dtos.Users
{
    public class UserCreateResponseDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
