using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoManager.Application.Common.Exceptions;
using TodoManager.Application.Common.Interfaces;
using TodoManager.Domain.Entities;

namespace TodoManager.Application.TodoItems.Commands.UpdateTodoItem
{
    public partial class UpdateTodoItemCommand : IRequest
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }

        public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand>
        {
            private readonly IApplicationDbContext context;

            public UpdateTodoItemCommandHandler(IApplicationDbContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
            {
                var entity = await context.TodoItems.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(TodoItem), request.Id);
                }

                entity.Title = request.Title;
                entity.Note = request.Note;
                await context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
