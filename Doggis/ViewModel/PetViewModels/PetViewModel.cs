using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Doggis.ViewModel
{
    public class PetViewModel
    {
        public Guid ID { get; set; }

        [Display(Name = "Dono")]
        public string OwnerName { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        public Enums.Pet.Specie Specie { get; set; }
        [Display(Name = "Espécie")]
        public string SpecieText { get; set; }

        [Display(Name = "Raça")]
        public string Breed { get; set; }

        public Enums.Pet.Size? Size { get; set; }
        [Display(Name = "Porte")]
        public string SizeText { get; set; }

        [Display(Name = "Alergias")]
        public string Alergies { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Permite Fotos")]
        public string AllowsPhotos { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }
    }
}