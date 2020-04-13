using FluentValidation;

namespace TodoManager.Application.TodoItems.Commands.UpdateTodoItemDetail
{
    public class UpdateTodoItemDetailCommandValidator : AbstractValidator<UpdateTodoItemDetailCommand>
    {
        public UpdateTodoItemDetailCommandValidator()
        {
            RuleFor(v => v.Note)
               .MaximumLength(5000)
               .NotEmpty();
        }
    }
}
