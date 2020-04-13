using System;
using System.Collections.Generic;
using System.Linq;
using TodoManager.Domain.Enums;

namespace TodoManager.Application.TodoLists.Queries.GetTodos
{
    public class TodosViewModel
    {
        public IList<PriorityLevelDto> PriorityLevels =
            Enum.GetValues(typeof(PriorityLevel))
                .Cast<PriorityLevel>()
                .Select(p => new PriorityLevelDto { Value = (int)p, Name = p.ToString() })
                .ToList();

        public IList<TodoListDto> Lists { get; set; }
    }
}
