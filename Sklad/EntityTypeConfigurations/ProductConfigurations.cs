using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Sklad.EntityTypeConfigurations
{
    public class ProductConfigurations : EntityTypeConfiguration<Product>
    {
        public ProductConfigurations()
        {
            Property(p => p.Name)
                .IsRequired();
        }
    }
}
