using Lojinha.Application.Interfaces;
using Lojinha.Application.Services;
using Lojinha.Domain.Interfaces.Repositories;
using Lojinha.Domain.Interfaces.Services;
using Lojinha.Domain.Services;
using Lojinha.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Lojinha.API;

public static class Setup
{
    public static void AddRegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IProdutoApplicationService, ProdutoApplicationService>();
        builder.Services.AddTransient<IProdutoDomainService, ProdutoDomainService>();
        builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
    }

    public static void AddEntityFrameworkServices(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("LojinhaDb");
        builder.Services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connectionString));
    }

    public static void AddAutoMapperServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}
