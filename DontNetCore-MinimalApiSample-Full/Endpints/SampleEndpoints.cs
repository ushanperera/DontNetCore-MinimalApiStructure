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


            //With the HTTP support
            app.MapGet("/samples", (LoadAllSample));

            app.MapGet("/sample/{id}", (LoadSampleById));


         
        }


        private static IResult LoadAllSample(SampleData data)
        {
            return Results.Ok(data?.sampleData);
        }

        private static IResult LoadSampleById(SampleData data, int id)
        {
            var sample = data?.sampleData.FirstOrDefault(x => x.Id == id);
            if (sample == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(sample);
        }


    }
    }
