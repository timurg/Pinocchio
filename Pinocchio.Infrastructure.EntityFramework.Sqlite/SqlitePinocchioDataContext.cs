using Microsoft.EntityFrameworkCore;

namespace Pinocchio.Infrastructure.EntityFramework.Sqlite;

public class SqlitePinocchioDataContext : PinocchioDataContext
{
    private readonly string? connectionString;

    public SqlitePinocchioDataContext(string connectionString)
    {
        this.connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString);
        // optionsBuilder.LogTo(System.Console.WriteLine);
    }
}
