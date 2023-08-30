using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Models
{
    public class ToDoList
    {
        public Guid Id { get; set; }

        public string TaskName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public User User { get; set; }

        [ForeignKey("UserId")]
        public Guid  UserId { get; set; }
    }
}
