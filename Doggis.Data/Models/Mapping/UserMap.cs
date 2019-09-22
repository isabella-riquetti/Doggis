using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            HasKey(t => t.ID);
            
            // Table & Column Mappings
            ToTable("User");
            Property(p => p.ID).HasColumnName("ID");
            Property(p => p.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
            Property(p => p.Type).HasColumnName("Type").IsRequired();
            Property(p => p.Identification).HasColumnName("Identification").HasMaxLength(13);
            Property(p => p.NationalInsuranceNumber).HasColumnName("NationalInsuranceNumber").HasMaxLength(14);
            Property(p => p.CouncilNumber).HasColumnName("CouncilNumber").HasMaxLength(50);
            Property(p => p.EntryTime).HasColumnName("EntryTime");
            Property(p => p.DepartureTime).HasColumnName("DepartureTime");
        }
    }
}
