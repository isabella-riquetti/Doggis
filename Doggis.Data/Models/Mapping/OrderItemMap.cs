using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Models.Mapping
{
    public class OrderItemMap : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Table & Column Mappings
            ToTable("OrderItem");
            Property(p => p.ID).HasColumnName("ID");
            Property(p => p.OrderID).HasColumnName("OrderID").IsRequired();
            Property(p => p.Type).HasColumnName("Type").IsRequired();
            Property(p => p.ServiceScheduleID).HasColumnName("ServiceScheduleID").IsRequired();
            Property(p => p.ProductID).HasColumnName("ProductID").IsRequired();
            Property(p => p.OriginalPrice).HasColumnName("OriginalPrice").IsRequired();
            Property(p => p.PromotionID).HasColumnName("PromotionID");
            Property(p => p.PaidPrice).HasColumnName("PaidPrice").IsRequired();
        }
    }
}
