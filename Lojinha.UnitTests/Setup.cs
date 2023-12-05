using Lojinha.Domain.Interfaces.Repositories;
using Lojinha.Domain.Interfaces.Services;
using Lojinha.Domain.Services;
using Lojinha.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Lojinha.UnitTests;

public class Setup : Xunit.Di.Setup
{
    protected override void Configure()
    {
        ConfigureAppConfiguration((hostingContext, config) =>
        {
            #region Ativando a Injeção de dependências no XUnit
            bool reloadOnChange = hostingContext.Configuration.GetValue("hostBuilder:reloadConfigOnChange", true);
            if (hostingContext.HostingEnvironment.IsDevelopment())
                config.AddUserSecrets<Setup>(true, reloadOnChange);
            #endregion
        });

        ConfigureServices((context, services) =>
        {
            #region Localizando o arquivo appsettings.json
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            #endregion

            #region Obtendo a connection string do arquivo
            var root = configurationBuilder.Build();
            var connectionString = root.GetSection("ConnectionStrings").GetSection("LojinhaDb").Value;
            #endregion

            #region Realizando a injeção das dependências necessárias
            services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connectionString));
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IProdutoDomainService, ProdutoDomainService>();
            #endregion
        });
    }
}
