using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Pinocchio.Infrastructure.EntityFramework.Sqlite;

public class SqlitePinocchioContextFactory : IDesignTimeDbContextFactory<SqlitePinocchioDataContext>
{
    public SqlitePinocchioDataContext CreateDbContext(string[] args)
    {
        var connectionString = string.Empty;
        if (string.IsNullOrEmpty(connectionString))
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .AddUserSecrets<SqlitePinocchioDataContext>().Build();
            connectionString = configuration.GetConnectionString("pinocchio");
        }
        return new SqlitePinocchioDataContext(connectionString);
    }
}
