using ToDoApp.Models;

namespace ToDoApp.Services.Iservices
{
    public interface IUserServices
    {

        Task<string> AddUserAsync(User user);
        Task <IEnumerable<User>> GetAllUsersAsync();
        Task<string>ViewCompletedTaskAsync(User user);

        
    }
}
