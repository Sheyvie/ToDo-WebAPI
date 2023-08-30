namespace ToDoApp.Requests
{
    public class AddTask
    {
        public string TaskName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}
