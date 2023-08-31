using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ToDoApp.Data;
using ToDoApp.Models;
using ToDoApp.Responses;
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
        private async Task<IEnumerable<ToDoList>> GetAllTasks()
        {
            return await _context.ToDoLists.ToListAsync();
        }

    
        public async Task<(IEnumerable<ToDoList>,PaginationMetaData)> GetAllAsync(string?TaskName, string ?UserName, int pageSize, int pageNumber)
        {
           
            if (string.IsNullOrEmpty(TaskName) && string.IsNullOrEmpty(UserName))
            {
                var tasklist = await GetAllTasks();
                var paginationmetadata = new PaginationMetaData(pageSize, pageNumber, tasklist.Count());
                return (tasklist, paginationmetadata);
            }
            var query = _context.ToDoLists.AsQueryable<ToDoList>();
            if (!string.IsNullOrEmpty(UserName))
            {
                query = query.Where(u => u.User.UserName.ToLower().Contains(UserName.ToLower()));
            }

            if(!string.IsNullOrEmpty(TaskName))
            {
                
                query = query.Where(n => n.TaskName.ToLower().Contains(TaskName.ToLower()) || n.Description.ToLower().Contains(TaskName.ToLower()));
            }
            //deffered execution

            //pagination
            
            query = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
            var paginationmetadata1 = new PaginationMetaData(pageSize, pageNumber, query.Count());
            return (await query.ToListAsync(), paginationmetadata1);
        }


        public async Task<ToDoList> GetTaskByIdAsync(Guid id)
        {
            return await _context.ToDoLists.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
