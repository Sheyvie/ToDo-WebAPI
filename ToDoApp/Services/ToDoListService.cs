using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;
using ToDoApp.Models;
using ToDoApp.Services.Iservices;

namespace ToDoApp.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly AppDbContext _context;
        public ToDoListService(AppDbContext context)
        {
            _context = context;
        }

        public  async Task<string> AddTaskAsync(ToDoList toDoList)
        {

            _context.ToDoLists.Add(toDoList);
            await _context.SaveChangesAsync();
            return "Task Added Successfully";
        }

        public async Task<string> DeleteTaskAsync(ToDoList toDoList)
        {
            _context.ToDoLists.Remove(toDoList);
            await _context.SaveChangesAsync();
            return "Task Deleted Successfully";
        }

        public async Task<IEnumerable<ToDoList>> GetAllAsync()
        {
            return await _context.ToDoLists.ToListAsync();
        }

        public async Task<ToDoList> GetTaskByIdAsync(Guid id)
        {
            return await _context.ToDoLists.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
