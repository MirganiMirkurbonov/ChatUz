using Microsoft.Extensions.DependencyInjection;
using Persistance.RootContext;

namespace Persistance;

public static class Persistance
{
    public static IServiceCollection AddPersistance(this IServiceCollection services, string connectionString)
    {
        EntityContext.ConnectionString = connectionString;
        services.AddDbContext<EntityContext>();

        return services;
    }
}
