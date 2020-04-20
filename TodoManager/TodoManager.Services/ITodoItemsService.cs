using System.Collections.Generic;
using TodoManager.Models.TodoItems;

namespace TodoManager.Services
{
    public interface ITodoItemsService
    {
        void Create(TodoItemInputModel model);

        IEnumerable<TodoItemViewModel> All();
    }
}
