using TodoManager.Domain.Common;

namespace TodoManager.Domain.Entities
{
    public class TodoItem : Entity<int>
    {
        public string Title { get; set; }

        public bool Done { get; set; }

        public int ListId { get; set; }
        public TodoList List { get; set; }
    }
}
