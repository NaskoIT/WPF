using System;
using System.Collections.Generic;
using TodoManager.Common;
using TodoManager.Models.TodoItems;
using TodoManager.Services;

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

        public TodoItemViewModel AddTodoItem()
        {
            var todoItem = new TodoItemInputModel
            {
                Content = Content
            };

            Content = string.Empty;
            return todoItemsService.Create(todoItem);
        }

        public void Toggle(int id) => 
            todoItemsService.Toggle(id);

        public void Delete(int id) => todoItemsService.Delete(id);
    }
}
