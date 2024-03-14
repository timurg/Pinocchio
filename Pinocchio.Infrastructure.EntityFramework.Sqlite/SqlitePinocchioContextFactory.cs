using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using static Pinocchio.Infrastructure.EntityFramework.PinocchioDataContext;

namespace Pinocchio.Infrastructure.EntityFramework.Sqlite;

public class SqlitePinocchioContextFactory : IDesignTimeDbContextFactory<SqlitePinocchioDataContext>
{
    public SqlitePinocchioDataContext CreateDbContext(string[] args, Log? log = null)
    {
        var connectionString = string.Empty;
        if (string.IsNullOrEmpty(connectionString))
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .AddUserSecrets<SqlitePinocchioDataContext>().Build();
            connectionString = configuration.GetConnectionString("pinocchio") ?? throw new ApplicationException("Connection string not defined");
        }
        return new SqlitePinocchioDataContext(connectionString, log);
    }

    public SqlitePinocchioDataContext CreateDbContext(string[] args)
    {
        return CreateDbContext(args, null);
    }
}
