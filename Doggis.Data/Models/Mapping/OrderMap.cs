using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Doggis.Data.Models.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            // Primary Key
            HasKey(t => t.ID);
            
            // Table & Column Mappings
            ToTable("Order");
            Property(p => p.ID).HasColumnName("ID");
            Property(p => p.ProtocolNumber).HasColumnName("ProtocolNumber").IsRequired().HasMaxLength(255);
            Property(p => p.Paid).HasColumnName("Paid");
            Property(p => p.PaymentType).HasColumnName("PaymentType");
            Property(p => p.TotalPrice).HasColumnName("TotalPrice");
        }
    }
}
