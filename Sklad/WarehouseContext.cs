using Sklad.EntityTypeConfigurations;
using System.Data.Entity;

namespace Sklad
{
    public class WarehouseContext : DbContext
    {
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<WarePurchase> WarePurchases { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new WarePurchaseConfigurations());
            modelBuilder.Configurations.Add(new ProductConfigurations());
            modelBuilder.Configurations.Add(new OrderConfigurations());
            modelBuilder.Configurations.Add(new CustomerConfigurations());
            modelBuilder.Configurations.Add(new ProviderConfigurations());

            base.OnModelCreating(modelBuilder);
        }
    }
}
