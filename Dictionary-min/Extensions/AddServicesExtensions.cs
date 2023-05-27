using Dictionary_min.Context;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;

namespace Dictionary_min.Extensions;

public static class AddServicesExtensions
{
    public static IServiceCollection AddDependencies(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddSingleton<IDatabase>(_ =>
        {
            var redisConfiguration = ConfigurationOptions.Parse(configuration.GetConnectionString("RedisConnection")!);
            var connection = ConnectionMultiplexer.Connect(redisConfiguration);
            return connection.GetDatabase();
        });
        
        serviceCollection.AddScoped<RedisManager>();
        
        return serviceCollection;
    }
    
    public static IServiceCollection AddSwagger(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Dictionary API",
                Version = "v1"
            });
        });
        return serviceCollection;
    }
}