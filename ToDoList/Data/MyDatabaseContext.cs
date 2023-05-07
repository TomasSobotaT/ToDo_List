using Microsoft.EntityFrameworkCore;

namespace ToDoList.Data
{
    /// <summary>
    /// Db Context for this app
    /// </summary>
    public class MyDatabaseContext : DbContext
    {
        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options) : base(options) { }


        public DbSet<ToDoModel> ToDoModelCollection { get; set; }
        public DbSet<DoneModel> DoneModelCollection { get; set; }
        

    }
}
