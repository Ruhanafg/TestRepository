using Microsoft.EntityFrameworkCore;
using GroceryApplication.Domain.Models;

namespace GroceryApplication.Infrastructure.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        
    public DbSet<User> Users { get; set; }
    public DbSet<MealPlan> MealPlans { get; set; }
    public DbSet<GroceryList> GroceryLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User ↔ MealPlan relationship
            modelBuilder.Entity<MealPlan>()
                .HasOne(m => m.User)
                .WithMany(u => u.MealPlans)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Unique Email constraint
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
}