using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TodoManager.Domain.Entities;

namespace TodoManager.UI.Views
{
    /// <summary>
    /// Interaction logic for TodoListItems.xaml
    /// </summary>
    public partial class TodoListItems : Page
    {
        private readonly int todoListId;
        private readonly ObservableCollection<TodoList> todoLists;


        public TodoListItems(int todoListId)
        {
            InitializeComponent();
            this.todoListId = todoListId;
            todoLists = new ObservableCollection<TodoList>();
            ListBoxOfCars.ItemsSource = todoLists;
        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            this.todoLists.Add(new TodoList { Title = "Next", Colour = "Black" });
        }

    }
}
