using Microsoft.EntityFrameworkCore;
using RoutineTracker.API.Model;

namespace RoutineTracker.API.Data;

public partial class RoutineTrackerContext : DbContext
{
    public RoutineTrackerContext(DbContextOptions<RoutineTrackerContext> options) : base(options) { }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Item> Items { get; set; }
    public virtual DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();
    }
}