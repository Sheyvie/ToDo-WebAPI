using ToDoApp.Models;
using ToDoApp.Responses;

namespace ToDoApp.Services.Iservices
{
    public interface IToDoListService
    {
        Task<string> AddTaskAsync(ToDoList toDoList);
        Task<string> DeleteTaskAsync(ToDoList toDoList);
        Task<ToDoList> GetTaskByIdAsync(Guid id);
        Task<(IEnumerable<ToDoList>, PaginationMetaData)>  GetAllAsync(string?TaskName , string?UserName, int pageSize, int pageNumber);
    }
}
