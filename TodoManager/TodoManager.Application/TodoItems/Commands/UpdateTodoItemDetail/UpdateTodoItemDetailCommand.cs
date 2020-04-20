using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoManager.Application.Common.Exceptions;
using TodoManager.Application.Common.Interfaces;
using TodoManager.Domain.Entities;
using TodoManager.Domain.Enums;

namespace TodoManager.Application.TodoItems.Commands.UpdateTodoItemDetail
{
    public class UpdateTodoItemDetailCommand : IRequest
    {
        public long Id { get; set; }

        public int ListId { get; set; }

        public PriorityLevel Priority { get; set; }

        public string Note { get; set; }

        public class UpdateTodoItemDetailCommandHandler : IRequestHandler<UpdateTodoItemDetailCommand>
        {
            private readonly IApplicationDbContext context;

            public UpdateTodoItemDetailCommandHandler(IApplicationDbContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(UpdateTodoItemDetailCommand request, CancellationToken cancellationToken)
            {
                var entity = await context.TodoItems.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(TodoItem), request.Id);
                }

                entity.ListId = request.ListId;
                await context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
