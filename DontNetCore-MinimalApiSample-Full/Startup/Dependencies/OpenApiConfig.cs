using Scalar.AspNetCore;

namespace DontNetCore_MinimalApiStructure.Startup.Dependencies
{
    public static class OpenApiConfig
    {
        public static void AddOpenApiServices(this IServiceCollection services)
        {
            services.AddOpenApi();
        }

        public static void UseAppOpenApi(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                //Added Salar (options are UI changes only)
                app.MapScalarApiReference(options =>
                {
                    options.Title = "My API";
                    options.Theme = ScalarTheme.Saturn;
                    options.Layout = ScalarLayout.Modern;
                    options.HideClientButton = true;
                });

            }
        }
    }
}
