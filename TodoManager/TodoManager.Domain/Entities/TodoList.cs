using System.Collections.Generic;
using TodoManager.Domain.Common;

namespace TodoManager.Domain.Entities
{
    public class TodoList : Entity<int>
    {
        public TodoList()
        {
            Items = new HashSet<TodoItem>();
        }

        public string Title { get; set; }

        public string Colour { get; set; }

        public ICollection<TodoItem> Items { get; set; }
    }
}
