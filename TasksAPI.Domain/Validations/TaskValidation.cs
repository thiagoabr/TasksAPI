using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = TasksAPI.Domain.Models.Task;

namespace TasksAPI.Domain.Validations
{
    public class TaskValidation : AbstractValidator<Task>
    {
        public TaskValidation()
        {
            RuleFor(task => task.Id)
                .NotEmpty().WithMessage("O ID da tarefa é obrigatório.");

            RuleFor(task => task.Name)
                .NotEmpty().WithMessage("O Nome da tarefa é obrigatório.")
                .Length(6, 150).WithMessage("O Nome da tarefa deve ter de 6 a 150 caracteres.");

            RuleFor(task => task.Description)
                .NotEmpty().WithMessage("A Descrição da tarefa é obrigatório.")
                .Length(6, 250).WithMessage("A Descrição da tarefa deve ter de 6 a 250 caracteres.");

            RuleFor(task => task.Date)
                .NotEmpty().WithMessage("A Data da tarefa é obrigatório.");

            RuleFor(task => task.Time)
                .NotEmpty().WithMessage("A Hora da tarefa é obrigatório.");

            RuleFor(task => task.UserId)
                .NotEmpty().WithMessage("O Usuário da tarefa é obrigatório.");
        }
    }
}
