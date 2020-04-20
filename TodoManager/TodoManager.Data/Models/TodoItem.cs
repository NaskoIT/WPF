using System.ComponentModel.DataAnnotations;

namespace TodoManager.Data.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public bool Done { get; set; }
    }
}
