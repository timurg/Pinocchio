using Microsoft.EntityFrameworkCore;

namespace Pinocchio.Infrastructure.EntityFramework.Sqlite;

public class SqlitePinocchioDataContext : PinocchioDataContext
{
    private readonly string? connectionString;

    public SqlitePinocchioDataContext(string connectionString, Log? log = null)
    {
        this.connectionString = connectionString;
        if (log != null){
            LogMessage = log;
        }
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString);
        if (LogMessage != null){
            optionsBuilder.LogTo(s => LogMessage(s))
            .EnableDetailedErrors(true)
                          .EnableSensitiveDataLogging(true);
        }
        // optionsBuilder.LogTo(System.Console.WriteLine);
    }
}
