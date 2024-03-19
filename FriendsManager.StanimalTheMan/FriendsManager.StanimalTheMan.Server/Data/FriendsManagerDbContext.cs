using FriendsManager.StanimalTheMan.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace FriendsManager.StanimalTheMan.Server.Data;

public class FriendsManagerDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Friend> Friends { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDb)\\LocalDBDemo;Database=FriendsManager;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Friends)
            .WithOne(f => f.Category)
            .HasForeignKey(f => f.CategoryID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
