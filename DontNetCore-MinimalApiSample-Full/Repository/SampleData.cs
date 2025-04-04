using DontNetCore_MinimalApiStructure.Models;
using System.Text.Json;

namespace DontNetCore_MinimalApiStructure.Repository
{
    public class SampleData
    {
        public List<SampleModel> sampleData { get; private set; }

        //ctor to load data from json file
        public SampleData()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            //Path.Combine work in all OS (linux, windows)
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "sampleData.json");

            string jsonString = File.ReadAllText(jsonFilePath);

            sampleData = JsonSerializer.Deserialize<List<SampleModel>>(jsonString, options) ?? new();
        }
    }

}
