using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doggis.ViewModel
{
    public class EditableVeterinaryViewModel
    {
        [HiddenInput]
        public Guid ID { get; set; }

        [Display(Name = "Nome")]
        [StringLength(255, ErrorMessage = "O campo {0} não pode possuir mais do que {1} caracteres")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }

        [Display(Name = "RG")]
        [StringLength(13, ErrorMessage = "O campo {0} não pode possuir mais do que {1} caracteres")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Identification { get; set; }

        [Display(Name = "CPF")]
        [StringLength(14, ErrorMessage = "O campo {0} não pode possuir mais do que {1} caracteres")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string NationalInsuranceNumber { get; set; }

        [Display(Name = "Nº Conselho Vet")]
        [StringLength(50, ErrorMessage = "O campo {0} não pode possuir mais do que {1} caracteres")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CouncilNumber { get; set; }

        [Display(Name = "Horário de Entrada")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public TimeSpan? EntryTime { get; set; }

        [Display(Name = "Horário de Saída")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public TimeSpan? DepartureTime { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Status { get; set; }

        [Display(Name = "Espécies tratadas")]
        [Required(ErrorMessage = "É necessário selecionar ao menos uma espécie.")]
        public List<int> AllowedSpecies { get; set; }
    }

    public class Species
    {
        public int Value { get; set; }
        public string Text { get; set; }
        public bool Selected { get; set; }
    }
}