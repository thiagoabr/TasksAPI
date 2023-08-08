using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksAPI.Application.Dtos.Users
{
    public class UserAuthResponseDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? AccessToken { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
