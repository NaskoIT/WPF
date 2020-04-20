using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoManager.Application.Common.Exceptions;
using TodoManager.Application.Common.Interfaces;
using TodoManager.Domain.Entities;

namespace TodoManager.Application.TodoItems.Commands.DeleteTodoItem
{
    public class DeleteTodoItemCommand : IRequest
    {
        public long Id { get; set; }

        public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
        {
            private readonly IApplicationDbContext context;

            public DeleteTodoItemCommandHandler(IApplicationDbContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
            {
                var entity = await context.TodoItems.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(TodoItem), request.Id);
                }

                context.TodoItems.Remove(entity);
                await context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
