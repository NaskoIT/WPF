using System;
using System.Collections.Generic;
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

namespace TodoManager.UI.Views
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void ShowTodoItems(object sender, RoutedEventArgs e)
        {
            int todoListId = 1;
            TodoListItems todoListItems = new TodoListItems(todoListId);
            this.NavigationService.Navigate(todoListItems);
        }
    }
}
