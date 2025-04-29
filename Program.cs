using Asp.Versioning;

using EmployeeTimeTrackingAPI.Extensions;
using EmployeeTimeTrackingAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiVersioningConfiguration();
builder.Services.AddSwaggerGenConfiguration();
builder.Services.AddApplicationServices();

var app = builder.Build();

var apiVersionSet = app.NewApiVersionSet()
    .HasApiVersion(new ApiVersion(1, 0))
    .ReportApiVersions()
    .Build();

var group = app.MapGroup("/api/v{version:apiVersion}")
    .WithApiVersionSet(apiVersionSet);

if(app.Environment.IsDevelopment())
{
    app.AddSwaggerUIConfiguration();
    app.AddSwaggerDocConfiguration();
}
   
app.UseHttpsRedirection();

group.MapEmployeeEndpoints();
group.MapTimeTrackingEndpoints();
group.MapCategoryEndpoints();
group.MapLocationEndpoints();

app.Run();
