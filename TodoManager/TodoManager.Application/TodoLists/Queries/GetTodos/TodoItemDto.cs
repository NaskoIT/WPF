using AutoMapper;
using TodoManager.Application.Common.Mappings;
using TodoManager.Domain.Entities;
using TodoManager.Domain.Enums;

namespace TodoManager.Application.TodoLists.Queries.GetTodos
{
    public class TodoItemDto : IMapFrom<TodoItem>
    {
        public long Id { get; set; }

        public int ListId { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }
    }
}
