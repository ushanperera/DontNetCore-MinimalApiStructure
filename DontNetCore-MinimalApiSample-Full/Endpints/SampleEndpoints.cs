using DontNetCore_MinimalApiStructure.Repository;

namespace DontNetCore_MinimalApiStructure.Endpints
{
    public static class SampleEndpoints
    {
        public static void AddSampleEndpoints(this WebApplication app)
        {
            //Get all samples---------------------------

            // 01. Just return 
            //app.MapGet("/samples", (Repository.SampleData data) =>
            //{
            //    return Results.Ok(data?.sampleData);
            //});


            //// 02. Get the SampleData from the DI
            //var data = app.Services.GetService<Repository.SampleData>();

            //app.MapGet("/samples", () =>
            //{
            //    return Results.Ok(data?.sampleData);
            //});

            //app.MapGet("/sample/{id}", (int id) =>
            //{
            //    var sample = sampleData?.sampleData.FirstOrDefault(x => x.Id == id);
            //    if (sample == null)
            //    {
            //        return Results.NotFound();
            //    }
            //    return Results.Ok(sample);
            //});


            // 03. With the HTTP support
            app.MapGet("/samples", (LoadAllSample));

            app.MapGet("/sample/{id}", (LoadSampleById));

            app.MapGet("/sampleFilter", (LoadSampleFilter));


        }


        private static IResult LoadAllSample(SampleData data)
        {
            return Results.Ok(data?.sampleData);
        }

        private static IResult LoadSampleById(SampleData data, int id)
        {
            var output = data?.sampleData.FirstOrDefault(x => x.Id == id);
            if (output == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(output);
        }

        private static IResult LoadSampleFilter(SampleData data, string? Name, string? Description)
        {

            var output = data.sampleData;

            if (string.IsNullOrWhiteSpace(Name) == false)
            {
                output.RemoveAll(x => !x.Name.Contains(Name));
            }
            if (string.IsNullOrWhiteSpace(Description) == false)
            {
                output.RemoveAll(x => !x.Description.Contains(Description));
            }


            if (output == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(output);
        }
    }
}
