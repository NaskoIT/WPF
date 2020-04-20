using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using TodoManager.Models.TodoItems;
using TodoManager.UI.ViewModels;
using static TodoManager.UI.DependencyInjection;

namespace TodoManager.UI.Views
{
    /// <summary>
    /// Interaction logic for TodoItems.xaml
    /// </summary>
    public partial class TodoItems : Page
    {
        private readonly TodoItemsViewModel todoItemsViewModel;
        private ObservableCollection<TodoItemViewModel> todoItems;

        public TodoItems()
        {
            InitializeComponent();

            todoItemsViewModel = Resolve<TodoItemsViewModel>();
            DataContext = todoItemsViewModel;
            BindTodoItems();
        }

        private void BindTodoItems()
        {
            IEnumerable<TodoItemViewModel> allTodoItems = todoItemsViewModel.GetTodoItems();
            todoItems = new ObservableCollection<TodoItemViewModel>(allTodoItems);
            TodoItemsList.ItemsSource = todoItems;
            foreach (var todoItem in todoItems)
            {
                todoItem.Done = true;
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            var todoItem = todoItemsViewModel.AddTodoItem();
            todoItems.Add(todoItem);
        }

        private void ToggleCompletion(object sender, RoutedEventArgs e)
        {
            var button = sender as CheckBox;
            int id = (int)button.DataContext;

            todoItemsViewModel.Toggle(id);
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int id = (int)button.DataContext;
            todoItemsViewModel.Delete(id);

            var todoItem = todoItems.First(t => t.Id == id);
            todoItems.Remove(todoItem);
        }
    }
}
