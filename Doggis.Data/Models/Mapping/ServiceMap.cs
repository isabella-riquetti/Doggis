using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Models.Mapping
{
    public class ServiceMap : EntityTypeConfiguration<Service>
    {
        public ServiceMap()
        {
            // Primary Key
            HasKey(t => t.ID);
            
            // Table & Column Mappings
            ToTable("Service");
            Property(p => p.ID).HasColumnName("ID");
            Property(p => p.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
            Property(p => p.EstimatedTime).HasColumnName("EstimatedTime").IsRequired();
            Property(p => p.Price).HasColumnName("Price").IsRequired();
            Property(p => p.Responsable).HasColumnName("Responsable").IsRequired();
            Property(p => p.PatazGiven).HasColumnName("PatazGiven").IsRequired();
            Property(p => p.PatazPrice).HasColumnName("PatazPrice").IsRequired();
        }
    }
}
