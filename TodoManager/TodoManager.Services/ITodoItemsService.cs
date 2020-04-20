using System.Collections.Generic;
using TodoManager.Models.TodoItems;

namespace TodoManager.Services
{
    public interface ITodoItemsService
    {
        TodoItemViewModel Create(TodoItemInputModel model);

        IEnumerable<TodoItemViewModel> All();

        void Toggle(int id);

        void Delete(int id);
    }
}
