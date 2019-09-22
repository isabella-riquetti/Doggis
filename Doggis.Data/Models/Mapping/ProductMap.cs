using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Models.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Table & Column Mappings
            ToTable("Product");
            Property(p => p.ID).HasColumnName("ID");
            Property(p => p.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
            Property(p => p.Manufacturer).HasColumnName("Manufacturer").IsRequired().HasMaxLength(255);
            Property(p => p.Description).HasColumnName("Description").IsRequired().HasMaxLength(255);
            Property(p => p.Price).HasColumnName("Price").IsRequired();
            Property(p => p.Inventory).HasColumnName("Inventory").IsRequired();
            Property(p => p.Category).HasColumnName("Category");
            Property(p => p.Status).HasColumnName("Status").IsRequired();
        }
    }
}
