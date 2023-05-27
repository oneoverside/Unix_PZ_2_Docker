using Dictionary_min.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDependencies(builder.Configuration)
    .AddEndpointsApiExplorer()
    .AddSwagger()
    .AddControllers();

builder.Build()
    .UseSwaggerInterface()
    .ConfigureRouting()
    .Run();