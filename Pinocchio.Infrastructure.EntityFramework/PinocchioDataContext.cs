using Microsoft.EntityFrameworkCore;
using Pinocchio.Domain;

namespace Pinocchio.Infrastructure.EntityFramework;

public class PinocchioDataContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Child>().ToTable("Children");
        modelBuilder.Entity<Parent>().HasMany( p => p.Children).WithOne(c => c.Parent);
        modelBuilder.Entity<Parent>().ToTable("Parents");
        modelBuilder.Entity<DateChildState>().ToTable("ChildStates");
    }
}
