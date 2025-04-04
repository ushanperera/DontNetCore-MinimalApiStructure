namespace DontNetCore_MinimalApiStructure.Endpints
{
    public static class SampleEndpoints
    {
        public static void AddSampleEndpoints(this WebApplication app)
        {
            //Get the SampleData from the DI
            var sampleData = app.Services.GetService<Repository.SampleData>();

            //Get all samples
            app.MapGet("/samples", () =>
            {
                return Results.Ok(sampleData?.sampleData);
            });

            //Get sample by id
            app.MapGet("/sample/{id}", (int id) =>
            {
                var sample = sampleData?.sampleData.FirstOrDefault(x => x.Id == id);
                if (sample == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(sample);
            });
        }
    }
}
