using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ToDoApp.Models;

namespace ToDoApp.Data
{
    public class AppDbContext: DbContext
    {

        public DbSet <User> Users { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext>options): base(options) { }
    }
}
