using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doggis.ViewModel
{
    public class EditablePetViewModel
    {
        [HiddenInput]
        public Guid ID { get; set; }

        public string OwnerName { get; set; }

        [Display(Name = "Espécie")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Specie { get; set; }

        [Display(Name = "Nome")]
        [StringLength(255, ErrorMessage = "O campo {0} não pode possuir mais do que {1} caracteres")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }

        [Display(Name = "Raça")]
        [StringLength(255, ErrorMessage = "O campo {0} não pode possuir mais do que {1} caracteres")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Breed { get; set; }

        [Display(Name = "Tamanho")]
        public int? Size { get; set; }

        [Display(Name = "Alegias")]
        [StringLength(255, ErrorMessage = "O campo {0} não pode possuir mais do que {1} caracteres")]
        public string Alergies { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(1000, ErrorMessage = "O campo {0} não pode possuir mais do que {1} caracteres")]
        public string Description { get; set; }

        [Display(Name = "Permite Fotos")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool AllowsPhotos { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Status { get; set; }
    }
}