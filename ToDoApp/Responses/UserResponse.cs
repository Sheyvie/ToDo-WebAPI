using ToDoApp.Models;

namespace ToDoApp.Responses
{
    public class UserResponse
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<ToDoList> ToDoLists { get; set; }
    }
}
