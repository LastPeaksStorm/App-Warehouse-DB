using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.EntityTypeConfigurations
{
    public class ProviderConfigurations : EntityTypeConfiguration<Provider>
    {
        public ProviderConfigurations()
        {
            Property(p => p.Name)
                .IsRequired();
        }
    }
}
