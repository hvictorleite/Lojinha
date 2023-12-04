using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Lojinha.Infrastructure.Data.Contexts;

public class SqlServerContextMigration : IDesignTimeDbContextFactory<SqlServerContext>
{
    public SqlServerContext CreateDbContext(string[] args)
    {
        #region Lendo o arquivo appsettings.json
        var configurationBuilder = new ConfigurationBuilder();
        var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
        configurationBuilder.AddJsonFile(path, false);
        #endregion

        #region Lendo a connection string do banco no arquivo
        var root = configurationBuilder.Build();
        var connectionString = root.GetSection("ConnectionStrings").GetSection("LojinhaDb").Value;
        #endregion

        #region Fazendo a injeção de dependência na classe SqlServerContext
        var builder = new DbContextOptionsBuilder<SqlServerContext>();
        builder.UseSqlServer(connectionString);

        return new SqlServerContext(builder.Options);
        #endregion
    }
}
