using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoManager.Application.Common.Interfaces;

namespace TodoManager.Application.TodoLists.Queries.GetTodos
{
    public class GetTodosQuery : IRequest<TodosViewModel>
    {
        public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, TodosViewModel>
        {
            private readonly IApplicationDbContext context;
            private readonly IMapper mapper;

            public GetTodosQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<TodosViewModel> Handle(GetTodosQuery request, CancellationToken cancellationToken)
            {
                var vm = new TodosViewModel();

                vm.Lists = await context.TodoLists
                    .ProjectTo<TodoListDto>(mapper.ConfigurationProvider)
                    .OrderBy(t => t.Title)
                    .ToListAsync(cancellationToken);

                return vm;
            }
        }
    }
}
