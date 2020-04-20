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
            int todoListId = 1;
            TodoListItems todoListItems = new TodoListItems(todoListId);
            this.NavigationService.Navigate(todoListItems);
        }
    }
}
