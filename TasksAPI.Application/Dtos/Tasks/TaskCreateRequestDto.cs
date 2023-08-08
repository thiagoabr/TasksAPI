using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksAPI.Application.Dtos.Tasks
{
    public class TaskCreateRequestDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Date { get; set; }
        public string? Time { get; set; }
        public Guid? UserId { get; set; }
    }
}
