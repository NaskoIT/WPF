using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            Main.Content = new TodoLists();
        }

        private void NavigateToTodoLists(object sender, RoutedEventArgs e)
        {
            Main.Content = new TodoLists();
        }

        private void NavigateToAddTodoListPage(object sender, RoutedEventArgs e)
        {
            Main.Content = new CreateTodoList();
        }
    }
}
