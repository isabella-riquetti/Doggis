using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Doggis.Data.Models.Mapping
{
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Table & Column Mappings
            ToTable("Client");
            Property(p => p.ID).HasColumnName("ID");
            Property(p => p.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
            Property(p => p.Identification).HasColumnName("Identification").IsRequired().HasMaxLength(13);
            Property(p => p.NationalInsuranceNumber).HasColumnName("NationalInsuranceNumber").IsRequired().HasMaxLength(14);
            Property(p => p.PhoneNumber).HasColumnName("PhoneNumber").IsRequired().HasMaxLength(100);
            Property(p => p.Email).HasColumnName("Email").IsRequired().HasMaxLength(100);
            Property(p => p.Address).HasColumnName("Address").IsRequired().HasMaxLength(255);
            Property(p => p.Number).HasColumnName("Number").IsRequired();
            Property(p => p.Complement).HasColumnName("Complement").HasMaxLength(255);
            Property(p => p.Neighborhood).HasColumnName("Neighborhood").IsRequired().HasMaxLength(100);
            Property(p => p.City).HasColumnName("City").IsRequired().HasMaxLength(100);
            Property(p => p.State).HasColumnName("State").IsRequired().HasMaxLength(2);
            Property(p => p.Pataz).HasColumnName("Pataz").IsRequired();
            Property(p => p.Status).HasColumnName("Status").IsRequired();
        }
    }
}
