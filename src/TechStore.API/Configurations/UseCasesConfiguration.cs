using TechStore.Application.Interfaces;
using TechStore.Application.UseCases.Produto.CriarProduto;
using TechStore.Data;
using TechStore.Data.Repositories;
using TechStore.Domain.Repository;

namespace TechStore.API.Configurations
{
    public static class UseCasesConfiguration
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services) 
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(CriarProduto).Assembly));
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            return services;
        }
    }
}
