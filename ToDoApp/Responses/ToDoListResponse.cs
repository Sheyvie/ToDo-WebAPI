using ToDoApp.Models;

namespace ToDoApp.Responses

{
    public class ToDoListResponse
    {
        public Guid Id { get; set; }

        public string TaskName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
