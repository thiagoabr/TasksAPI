using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Domain.Validations;

namespace TasksAPI.Domain.Models
{
    public class User
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }

        public List<Task>? Tasks { get; set; }

        public ValidationResult? Validate
            => new UserValidation().Validate(this);
    }
}
