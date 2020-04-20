using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoManager.Application.Common.Exceptions;
using TodoManager.Application.Common.Interfaces;
using TodoManager.Domain.Entities;

namespace TodoManager.Application.TodoLists.Commands.DeleteTodoList
{
    public class DeleteTodoListCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteTodoListCommandHandler : IRequestHandler<DeleteTodoListCommand>
        {
            private readonly IApplicationDbContext context;

            public DeleteTodoListCommandHandler(IApplicationDbContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
            {
                var entity = await context.TodoLists
                    .Where(l => l.Id == request.Id)
                    .SingleOrDefaultAsync(cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(TodoList), request.Id);
                }

                context.TodoLists.Remove(entity);
                await context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
