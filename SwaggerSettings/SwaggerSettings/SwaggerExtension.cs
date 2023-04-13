using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SwaggerSettings;
public static class SwaggerExtension
{
    public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
    {
        // Swagger Services
        services.AddApiVersioning(option =>
        {
            option.DefaultApiVersion = new ApiVersion(2, 0);
            option.AssumeDefaultVersionWhenUnspecified = true;
            option.ReportApiVersions = true;
        });

        services.AddEndpointsApiExplorer();
        services.AddVersionedApiExplorer(option =>
        {
            option.GroupNameFormat = "'v'VVV";
            option.SubstituteApiVersionInUrl = true;
        });

        // Swagger XML Documentation
        services.AddSwaggerGen(option =>
        {
            option.OperationFilter<SwaggerDefaultValues>();

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine($"{AppContext.BaseDirectory}", xmlFile);

            option.IncludeXmlComments(xmlPath);
            option.ExampleFilters();
        });

        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>();
        services.AddSwaggerExamplesFromAssemblies(Assembly.GetExecutingAssembly());

        return services;
    }

    public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
    {
        var provider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();
        app.UseSwagger();
        app.UseSwaggerUI(option =>
        {
            foreach (var desciptions in provider.ApiVersionDescriptions.Reverse())
            {
                option.SwaggerEndpoint($"/swagger/{desciptions.GroupName}/swagger.json", $"{desciptions.GroupName.ToUpper()}");
            }
        });

        return app;
    }
}
