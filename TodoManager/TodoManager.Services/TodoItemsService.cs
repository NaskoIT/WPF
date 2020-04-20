using System.Collections.Generic;
using System.Linq;
using TodoManager.Data;
using TodoManager.Data.Models;
using TodoManager.Models.TodoItems;

namespace TodoManager.Services
{
    public class TodoItemsService : ITodoItemsService
    {
        private readonly ApplicationDbContext context;

        public TodoItemsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<TodoItemViewModel> All() =>
            context.TodoItems
            .Select(t => new TodoItemViewModel
            {
                Id = t.Id,
                Content = t.Content
            })
            .ToList();

        public void Create(TodoItemInputModel model)
        {
            var todoItem = new TodoItem
            {
                Content = model.Content,
            };

            context.TodoItems.Add(todoItem);
            context.SaveChanges();
        }
    }
}
