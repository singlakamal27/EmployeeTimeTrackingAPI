using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using EmployeeTimeTrackingAPI.Services;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EmployeeTimeTrackingAPI.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IEmployeeService, EmployeeService>();
        services.AddSingleton<ITimeTrackingService, TimeTrackingService>();
        services.AddSingleton<ILocationService, LocationService>();
        services.AddSingleton<ICategoryService, CategoryService>();
        return services;
    }

    public static IServiceCollection AddApiVersioningConfiguration(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
            options.ApiVersionReader = new UrlSegmentApiVersionReader(); // Only supporting url versioning for now.
        })
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        return services;
    }

    public static IServiceCollection AddSwaggerGenConfiguration(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    public static WebApplication AddSwaggerUIConfiguration(this WebApplication app)
    {
        var apiVersionDescProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            foreach (var description in apiVersionDescProvider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            }
        });

        return app;
    }

    public static WebApplication AddSwaggerDocConfiguration(this WebApplication app)
    {
        var apiVersionDescProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        var swaggerGenOptions = app.Services.GetRequiredService<IOptions<SwaggerGenOptions>>().Value;
        
        foreach (var description in apiVersionDescProvider.ApiVersionDescriptions) 
        {
            swaggerGenOptions.SwaggerGeneratorOptions.SwaggerDocs.TryAdd(
                description.GroupName,
                new OpenApiInfo
                {
                    Title = "EmployeeTimeTrackingAPI",
                    Version = description.ApiVersion.ToString(),
                    Description = "API for tracking employee times across locations and categories."
                });
        }
        
        return app;
    }
}
