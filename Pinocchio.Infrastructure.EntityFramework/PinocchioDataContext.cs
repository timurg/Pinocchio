using Microsoft.EntityFrameworkCore;
using Pinocchio.Domain;

namespace Pinocchio.Infrastructure.EntityFramework;

public class PinocchioDataContext : DbContext
{
    public delegate void Log(string message);

    public Log? LogMessage {get; protected set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //LogMessage("!");
        modelBuilder.Entity<Child>().ToTable("Children");
        modelBuilder.Entity<Parent>().HasMany( p => p.Children).WithOne(c => c.Parent);
        modelBuilder.Entity<Parent>().ToTable("Parents");
        modelBuilder.Entity<DateChildState>().ToTable("ChildStates");
    }
}
