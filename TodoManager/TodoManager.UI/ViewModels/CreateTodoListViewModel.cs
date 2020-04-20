using TodoManager.UI.Common;

namespace TodoManager.UI.ViewModels
{
    public class CreateTodoListViewModel : NotifyPropertyChanged
    {
        private string title;
        private string colour;

        public CreateTodoListViewModel(string title, string colour)
        {
            Title = title;
            Colour = colour;
        }

        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Colour 
        {
            get => colour;
            set
            {
                colour = value;
                OnPropertyChanged(nameof(Colour));
            }
        }
    }
}
