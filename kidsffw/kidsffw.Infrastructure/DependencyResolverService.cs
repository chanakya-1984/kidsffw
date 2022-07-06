using kidsffw.Application.Interfaces.Persistence;
using kidsffw.Infrastructure.Data;
using kidsffw.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace kidsffw.Infrastructure;

public static class DependencyResolverService
{
    public static void Register(IServiceCollection services, IConfiguration Configuration)
    {
        string connString = Configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<KidsFfwDbContext>(options => options.UseSqlServer(connString));
        services.AddScoped(typeof(IBaseRepositoryAsync<>), typeof(BaseRepositoryAsync<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}