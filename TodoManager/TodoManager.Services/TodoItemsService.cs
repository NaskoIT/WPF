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
                Content = t.Content,
                Done = t.Done
            })
            .ToList();

        public TodoItemViewModel Create(TodoItemInputModel model)
        {
            var todoItem = new TodoItem
            {
                Content = model.Content,
            };

            context.TodoItems.Add(todoItem);
            context.SaveChanges();

            return new TodoItemViewModel
            {
                Content = model.Content,
                Id = todoItem.Id
            };
        }

        public void Delete(int id)
        {
            TodoItem todoItem = context.TodoItems.Find(id);
            context.TodoItems.Remove(todoItem);
            context.SaveChanges();
        }

        public void Toggle(int id)
        {
            var todoItem = context.TodoItems.Find(id);
            todoItem.Done = !todoItem.Done;
            context.TodoItems.Update(todoItem);
            context.SaveChanges();
        }
    }
}
