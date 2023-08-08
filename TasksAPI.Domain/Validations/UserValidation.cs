using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Domain.Models;

namespace TasksAPI.Domain.Validations
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(user => user.Id)
                .NotEmpty().WithMessage("O ID do usuário é obrigatório.");

            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("O Nome do usuário é obrigatório.")
                .Length(6, 50).WithMessage("O Nome do usuário deve ter de 6 a 50 caracteres.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("A Senha do usuário é obrigatório.")
                .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@#$%^&+=])(?!.*\s).{8,}$")
                .WithMessage("Informe uma senha forte com pelo menos 8 caracteres.");
        }
    }
}
