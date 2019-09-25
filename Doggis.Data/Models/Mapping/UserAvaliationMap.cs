using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Models.Mapping
{
    public class UserAvaliationMap : EntityTypeConfiguration<UserAvaliation>
    {
        public UserAvaliationMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Table & Column Mappings
            ToTable("UserAvaliation");
            Property(p => p.ID).HasColumnName("ID");
            Property(p => p.ClientID).HasColumnName("ClientID").IsRequired();
            Property(p => p.ServiceScheduleID).HasColumnName("ScheduleID").IsRequired();
            Property(p => p.Score).HasColumnName("Score").IsRequired();
            Property(p => p.Status).HasColumnName("Status").IsRequired();
            Property(p => p.Description).HasColumnName("Description").IsRequired();

            HasRequired(t => t.Client)
                .WithMany(t => t.Avaliations)
                .HasForeignKey(d => d.ClientID)
                .WillCascadeOnDelete(false);

            HasRequired(t => t.Schedule)
                .WithMany(t => t.Avaliations)
                .HasForeignKey(d => d.ServiceScheduleID)
                .WillCascadeOnDelete(false);
        }
    }
}
