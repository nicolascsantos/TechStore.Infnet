using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using TechStore.Application.Interfaces;
using TechStore.Application.UseCases.Produto.CriarProduto;
using TechStore.Data;
using TechStore.Data.Repositories;
using TechStore.Domain.Repository;
using TechStore.API.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(typeof(APIGlobalExceptionHandler)));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<TechStoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")
));

builder.Services.AddSerilog((servicos, logger) =>
{
    logger
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console();

    var caminhoAzure = Environment.GetEnvironmentVariable("HOME");

    if (!string.IsNullOrWhiteSpace(caminhoAzure) &&
        !string.IsNullOrWhiteSpace(
            Environment.GetEnvironmentVariable("WEBSITE_SITE_NAME")))
    {
        logger.WriteTo.File(
            Path.Combine(caminhoAzure, "LogFiles", "techstore-.log"),
            rollingInterval: RollingInterval.Day,
            retainedFileCountLimit: 7,
            fileSizeLimitBytes: 10 * 1024 * 1024,
            rollOnFileSizeLimit: true,
            shared: true);
    }
});

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(CriarProduto).Assembly));

builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();

var app = builder.Build();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
