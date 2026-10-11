using Serilog;
using TechStore.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("StaticWebApp", policy =>
        policy.WithOrigins("https://jolly-sand-030e7df1e.5.azurestaticapps.net")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services
    .AddandConfigureControllers()
    .AddDbConnection(builder.Configuration)
    .AddUseCases()
    .AddLogs();



var app = builder.Build();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("StaticWebApp");
app.UseAuthorization();

app.MapControllers();

app.Run();
