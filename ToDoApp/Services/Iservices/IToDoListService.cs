using ToDoApp.Models;

namespace ToDoApp.Services.Iservices
{
    public interface IToDoListService
    {
        Task<string> AddTaskAsync(ToDoList toDoList);
        Task<string> DeleteTaskAsync(ToDoList toDoList);
        Task<ToDoList> GetTaskByIdAsync(Guid id);
        Task<IEnumerable<ToDoList>> GetAllAsync();
    }
}
