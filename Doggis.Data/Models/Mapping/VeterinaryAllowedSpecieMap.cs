using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Models.Mapping
{
    public class VeterinaryAllowedSpecieMap : EntityTypeConfiguration<VeterinaryAllowedSpecie>
    {
        public VeterinaryAllowedSpecieMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Table & Column Mappings
            ToTable("VeterinaryAllowedSpecies");
            Property(p => p.ID).HasColumnName("ID");
            Property(p => p.VeterinaryID).HasColumnName("VeterinaryID").IsRequired();
            Property(p => p.Specie).HasColumnName("Specie").IsRequired();

            HasRequired(t => t.Veterinary)
                .WithMany(t => t.VeterinaryAllowedSpecies)
                .HasForeignKey(d => d.VeterinaryID)
                .WillCascadeOnDelete(false);
        }
    }
}
