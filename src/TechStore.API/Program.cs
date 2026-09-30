using Microsoft.EntityFrameworkCore;
using TechStore.Application.Interfaces;
using TechStore.Application.UseCases.Produto.CriarProduto;
using TechStore.Data;
using TechStore.Data.Repositories;
using TechStore.Domain.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<TechStoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")
));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(CriarProduto).Assembly));

builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
