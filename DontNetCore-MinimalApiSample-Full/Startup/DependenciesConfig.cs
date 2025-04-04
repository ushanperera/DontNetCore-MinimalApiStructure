using System.Runtime.CompilerServices;

namespace DontNetCore_MinimalApiStructure.Startup
{
    public static class DependenciesConfig
    {
        public static void AddDependencies(this WebApplicationBuilder builder)
        {
            //All Dependencies will be listed here
            builder.Services.AddOpenApiServices();


        }

    }
}
