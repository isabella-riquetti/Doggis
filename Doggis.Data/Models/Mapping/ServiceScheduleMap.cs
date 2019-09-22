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
            Property(p => p.ResponsibleID).HasColumnName("ResponsibleID").IsRequired();
            Property(p => p.Finished).HasColumnName("Finished");
            Property(p => p.Status).HasColumnName("Status").IsRequired();

            HasRequired(t => t.Service)
                .WithMany(t => t.ServiceSchedules)
                .HasForeignKey(d => d.ServiceID)
                .WillCascadeOnDelete(false);

            HasRequired(t => t.Client)
                .WithMany(t => t.ServiceSchedules)
                .HasForeignKey(d => d.ClientID)
                .WillCascadeOnDelete(false);

            HasRequired(t => t.Pet)
                .WithMany(t => t.ServiceSchedules)
                .HasForeignKey(d => d.PetID)
                .WillCascadeOnDelete(false);

            HasRequired(t => t.Responsible)
                .WithMany(t => t.ServiceSchedulesResponsibleFor)
                .HasForeignKey(d => d.ResponsibleID)
                .WillCascadeOnDelete(false);
        }
    }
}
