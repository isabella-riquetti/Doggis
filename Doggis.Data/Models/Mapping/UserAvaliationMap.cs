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
            Property(p => p.ScheduleID).HasColumnName("ScheduleID").IsRequired();
            Property(p => p.Avaliation).HasColumnName("Avaliation").IsRequired();
        }
    }
}
