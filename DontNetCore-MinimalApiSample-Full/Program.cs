using DontNetCore_MinimalApiStructure.Endpints;
using DontNetCore_MinimalApiStructure.Startup;
using DontNetCore_MinimalApiStructure.Startup.Dependencies;

var builder = WebApplication.CreateBuilder(args);


//--------------------------Add services to app---------------------
// Add services from service file
builder.AddDependencies();


//--------------------------Middleware--------------------------------
var app = builder.Build();
app.UseHttpsRedirection();


//add custom - OpenApi Middleware
app.UseAppOpenApi();

// add custom - Endpoint service Middleware
app.UseAppRootEndPoints();
app.UseAppSampleEndpoints();

// add custom - CORES Middleware
app.UseAppCoresConfig();

// add custom - Health Checks Middleware
app.UseAppHealthChecks();



app.Run();