using System.Windows;
using System.Windows.Controls;

namespace TodoManager.UI.Views
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class TodoLists : Page
    {
        public TodoLists()
        {
            InitializeComponent();
        }

        private void ShowTodoItems(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int id = (int)button.DataContext;
            TodoListItems todoListItems = new TodoListItems(id);
            this.NavigationService.Navigate(todoListItems);
        }
    }
}
