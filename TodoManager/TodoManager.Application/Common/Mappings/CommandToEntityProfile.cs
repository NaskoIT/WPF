using AutoMapper;
using TodoManager.Application.TodoItems.Commands.CreateTodoItem;
using TodoManager.Domain.Entities;

namespace TodoManager.Application.Common.Mappings
{
    public class CommandToEntityProfile : Profile
    {
        public CommandToEntityProfile()
        {
            CreateMap<CreateTodoItemCommand, TodoItem>();
        }
    }
}
