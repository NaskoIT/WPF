using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoManager.Application.TodoItems.Queries;

namespace TodoManager.UI.ViewModels
{
    public class TodoListsViewModel
    {
        private readonly IMediator mediator;

        public TodoListsViewModel(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IEnumerable<TodoListViewModel>> GetTodoLists() => 
            await mediator.Send(new TodoListsAllQuery());
    }
}
