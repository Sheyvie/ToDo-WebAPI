namespace ToDoApp.Responses
{
    public class TaskSuccess
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public TaskSuccess(int c, string m)
        {
            this.Code = c;
            this.Message = m;
        }
    }
}
