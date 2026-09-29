using Microsoft.EntityFrameworkCore;
using TechStore.Data.Configurations;
using TechStore.Domain.Entities;

namespace TechStore.Data
{
    public class TechStoreDbContext : DbContext
    {
        public DbSet<Produto> Produtos => Set<Produto>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        }
    }
}
