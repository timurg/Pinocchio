using Microsoft.EntityFrameworkCore;
using Pinocchio.Domain;

namespace Pinocchio.Infrastructure.EntityFramework;

public class PinocchioDataContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Child>().ToTable("Children");
        modelBuilder.Entity<Parent>().ToTable("Parents");
    }
}
