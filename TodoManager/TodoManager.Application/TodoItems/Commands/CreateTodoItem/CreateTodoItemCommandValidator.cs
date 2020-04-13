using FluentValidation;
using TodoManager.Application.TodoItems.Commands.CreateTodoItem;

namespace DefaultTemplate.Application.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
    {
        public CreateTodoItemCommandValidator()
        {
            RuleFor(v => v.Title)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(v => v.Note)
               .MaximumLength(50000)
               .NotEmpty();
        }
    }
}
