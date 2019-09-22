using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Models.Mapping
{
    public class ServiceScheduleMap : EntityTypeConfiguration<ServiceSchedule>
    {
        public ServiceScheduleMap()
        {
            // Primary Key
            HasKey(t => t.ID);
            
            // Table & Column Mappings
            ToTable("ServiceSchedule");
            Property(p => p.ID).HasColumnName("ID");
            Property(p => p.ServiceID).HasColumnName("ServiceID").IsRequired();
            Property(p => p.Schedule).HasColumnName("Schedule").IsRequired();
            Property(p => p.ClientID).HasColumnName("ClientID").IsRequired();
            Property(p => p.PetID).HasColumnName("PetID").IsRequired();
            Property(p => p.ResponsibleID).HasColumnName("ResponsibleID");
            Property(p => p.Finished).HasColumnName("Finished");
        }
    }
}
