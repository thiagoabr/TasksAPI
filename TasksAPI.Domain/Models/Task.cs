using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Domain.Validations;

namespace TasksAPI.Domain.Models
{
    public class Task
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }
        public Guid? UserId { get; set; }

        public User? User { get; set; }

        public ValidationResult? Validate
            => new TaskValidation().Validate(this);
    }
}
