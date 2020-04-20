using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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

        public TodoItems()
        {
            InitializeComponent();

            todoItemsViewModel = Resolve<TodoItemsViewModel>();
            BindTodoItems();
        }

        private void BindTodoItems()
        {
            IEnumerable<Models.TodoItems.TodoItemViewModel> todoItems = todoItemsViewModel.GetTodoItems();
            TodoItems.ItemsSource = todoItems;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            todoItemsViewModel.AddTodoItem();
        }

        private void ToggleCompletion(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int id = (int)button.DataContext;
        }
    }
}
