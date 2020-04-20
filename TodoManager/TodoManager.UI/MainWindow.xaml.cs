using System.Windows;
using TodoManager.UI.Views;

namespace TodoManager.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new TodoItems();
        }

        private void NavigateToTasks(object sender, RoutedEventArgs e)
        {
            Main.Content = new TodoItems();
        }

        private void NavigateToMyDay(object sender, RoutedEventArgs e)
        {
            Main.Content = new MyDay();
        }

        private void NavigateToImportantTasks(object sender, RoutedEventArgs e)
        {
            Main.Content = new ImportantTasks();
        }
    }
}
