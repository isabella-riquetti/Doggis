using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Models.Mapping
{
    public class PetMap : EntityTypeConfiguration<Pet>
    {
        public PetMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Table & Column Mappings
            ToTable("Pet");
            Property(p => p.ID).HasColumnName("ID");
            Property(p => p.OwnerId).HasColumnName("OwnerId").IsRequired();
            Property(p => p.Specie).HasColumnName("Specie").IsRequired();
            Property(p => p.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
            Property(p => p.Breed).HasColumnName("Breed").IsRequired().HasMaxLength(255);
            Property(p => p.Size).HasColumnName("Size");
            Property(p => p.Alergies).HasColumnName("Alergies").HasMaxLength(255);
            Property(p => p.Description).HasColumnName("Description").HasMaxLength(1000);
            Property(p => p.AllowsPhotos).HasColumnName("AllowsPhotos").IsRequired();
            Property(p => p.Status).HasColumnName("Status").IsRequired();

            HasRequired(t => t.Owner)
                .WithMany(t => t.Pets)
                .HasForeignKey(d => d.OwnerId)
                .WillCascadeOnDelete(false);
        }
    }
}
