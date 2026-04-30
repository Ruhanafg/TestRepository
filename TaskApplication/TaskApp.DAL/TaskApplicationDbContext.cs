using Microsoft.EntityFrameworkCore;
using TaskApp.Model;

namespace TaskApp.DAL
{
    public class TaskApplicationDbContext : DbContext
    {
        public TaskApplicationDbContext()
        {
        }

        public TaskApplicationDbContext(DbContextOptions<TaskApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "server=localhost;database=TaskDB;user=root;password=moon2504;";

                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)
                );
            }
        }

        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}