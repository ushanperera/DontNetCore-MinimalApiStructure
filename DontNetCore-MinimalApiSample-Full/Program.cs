using DontNetCore_MinimalApiStructure.Endpints;
using DontNetCore_MinimalApiStructure.Startup;

var builder = WebApplication.CreateBuilder(args);


//--------------------------Add services to app---------------------
// Add services from service file
builder.AddDependencies();

//-------------------------Add Middleware to app--------------------
var app = builder.Build();
//added static clas for OpenApi
app.UseOpenApi();


app.UseHttpsRedirection();

//--------------------------Endpoints--------------------------------
// Add static class for Endpoint service file
app.AddRootEndPoints();
app.AddSampleEndpoints();

app.Run();