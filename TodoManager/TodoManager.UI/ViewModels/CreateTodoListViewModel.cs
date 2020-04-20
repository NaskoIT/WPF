using MediatR;
using System.Threading.Tasks;
using TodoManager.Application.TodoLists.Commands.CreateTodoList;
using TodoManager.UI.Common;

namespace TodoManager.UI.ViewModels
{
    public class CreateTodoListViewModel : NotifyPropertyChanged
    {
        private readonly IMediator mediator;
        private string title;
        private string colour;

        public CreateTodoListViewModel(IMediator mediator)
        {
            this.mediator = mediator;
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

        public async Task Create()
        {
            var command = new CreateTodoListCommand
            {
                Title = Title,
                Colour = Colour
            };

            await mediator.Send(command);
        }
    }
}
