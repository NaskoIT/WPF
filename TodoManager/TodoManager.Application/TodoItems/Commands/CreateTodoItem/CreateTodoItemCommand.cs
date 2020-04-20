using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TodoManager.Application.Common.Interfaces;
using TodoManager.Domain.Entities;
using TodoManager.Domain.Enums;

namespace TodoManager.Application.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommand : IRequest<int>
    {
        public int ListId { get; set; } 

        public string Title { get; set; }

        public string Note { get; set; }

        public DateTime? Reminder { get; set; }

        public PriorityLevel Priority { get; set; }

        public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, int>
        {
            private readonly IApplicationDbContext context;
            private readonly IMapper mapper;

            public CreateTodoItemCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
            {
                var entity = mapper.Map<TodoItem>(request);

                context.TodoItems.Add(entity);
                await context.SaveChangesAsync();

                return entity.Id;
            }
        }
    }
}
