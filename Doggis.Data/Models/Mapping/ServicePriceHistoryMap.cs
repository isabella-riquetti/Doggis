using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Models.Mapping
{
    public class ServicePriceHistoryMap : EntityTypeConfiguration<ServicePriceHistory>
    {
        public ServicePriceHistoryMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Table & Column Mappings
            ToTable("ServicePriceHistory");
            Property(p => p.ID).HasColumnName("ID");
            Property(p => p.ServiceID).HasColumnName("ServiceID").IsRequired();
            Property(p => p.Price).HasColumnName("Price").IsRequired();
            Property(p => p.StartDate).HasColumnName("StartDate").IsRequired();
            Property(p => p.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            Property(p => p.EndDate).HasColumnName("EndDate");
            Property(p => p.DisabledBy).HasColumnName("DisabledBy");
        }
    }
}
