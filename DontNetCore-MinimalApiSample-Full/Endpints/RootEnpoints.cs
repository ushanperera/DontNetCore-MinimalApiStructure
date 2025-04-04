namespace DontNetCore_MinimalApiStructure.Endpints
{
    public static class RootEnpoints
{
        public static void AddRootEndPoints(this WebApplication app)
        {
            app.MapGet("/hello", () => "Hello World!");

            app.MapGet("/", () => "Hellow...");
        }

}
}
