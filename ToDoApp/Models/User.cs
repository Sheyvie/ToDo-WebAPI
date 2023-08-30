namespace ToDoApp.Models
{
    public class User
    {

        public Guid UserId { get; set; }
        public string UserName { get; set; }= string.Empty;
        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }

        public List<ToDoList> ToDoLists{ get; set; }   


    }
}
