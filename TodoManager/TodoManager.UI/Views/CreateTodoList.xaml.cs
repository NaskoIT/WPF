using System.Windows;
using System.Windows.Controls;
using TodoManager.UI.ViewModels;
using static TodoManager.UI.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace TodoManager.UI.Views
{
    /// <summary>
    /// Interaction logic for CreateTodoList.xaml
    /// </summary>
    public partial class CreateTodoList : Page
    {
        private const string DefaultColor = "Yellow";
        private readonly CreateTodoListViewModel todoList;

        public CreateTodoList()
        {
            InitializeComponent();
            todoList = Resolve<CreateTodoListViewModel>();
            todoList.Colour = DefaultColor;
            DataContext = todoList;
        }

        private async void SaveTodoList(object sender, System.Windows.RoutedEventArgs e)
        {
            await todoList.Create();
        }
    }
}
