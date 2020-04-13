using System.Collections.Generic;
using TodoManager.Domain.Common;

namespace TodoManager.Domain.Entities
{
    public class User : Entity<string>
    {
        public User()
        {
            TodoLists = new HashSet<TodoList>();
        }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public ICollection<TodoList> TodoLists { get; set; }
    }
}
