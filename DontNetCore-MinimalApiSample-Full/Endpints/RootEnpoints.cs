namespace DontNetCore_MinimalApiStructure.Endpints
{
    public static class RootEnpoints
{
        public static void UseAppRootEndPoints(this WebApplication app)
        {
            app.MapGet("/hello", () => "Hello World!");

            app.MapGet("/", () => "Hellow...");
        }

}
}
