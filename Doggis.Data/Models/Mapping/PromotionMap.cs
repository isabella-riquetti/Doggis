using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Models.Mapping
{
    public class PromotionMap : EntityTypeConfiguration<Promotion>
    {
        public PromotionMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Table & Column Mappings
            ToTable("Promotion");
            Property(p => p.ID).HasColumnName("ID");
            Property(p => p.AppliedToService).HasColumnName("AppliedToService").IsRequired();
            Property(p => p.AppliedToProduct).HasColumnName("AppliedToProduct").IsRequired();
            Property(p => p.StartDate).HasColumnName("StartDate").IsRequired();
            Property(p => p.EndDate).HasColumnName("EndDate").IsRequired();
            Property(p => p.Percentage).HasColumnName("Percentage").IsRequired();
            Property(p => p.Status).HasColumnName("Status").IsRequired();
        }
    }
}
