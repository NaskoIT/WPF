using System.Collections.Generic;
using TodoManager.Models.TodoItems;
using TodoManager.Services;
using TodoManager.UI.Common;

namespace TodoManager.UI.ViewModels
{
    public class TodoItemsViewModel : NotifyPropertyChanged
    {
        private string content;
        private readonly ITodoItemsService todoItemsService;

        public TodoItemsViewModel(ITodoItemsService todoItemsService)
        {
            this.todoItemsService = todoItemsService;
        }

        public string Content
        {
            get => content;
            set
            {
                content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        public IEnumerable<TodoItemViewModel> GetTodoItems() =>
            todoItemsService.All();

        public void AddTodoItem()
        {
            var todoItem = new TodoItemInputModel
            {
                Content = Content
            };

            todoItemsService.Create(todoItem);
        }

        public void Toggle(int id) => 
            todoItemsService.Toggle(id);
    }
}
