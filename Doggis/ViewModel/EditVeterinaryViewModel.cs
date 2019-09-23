using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doggis.ViewModel
{
    public class EditVeterinaryViewModel
    {
        [HiddenInput]
        public Guid ID { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "RG")]
        public string Identification { get; set; }

        [Required]
        [Display(Name = "CPF")]
        public string NationalInsuranceNumber { get; set; }

        [Required]
        [Display(Name = "Nº Conselho Vet")]
        public string CouncilNumber { get; set; }

        [Required]
        [Display(Name = "Horário de Entrada")]
        public TimeSpan EntryTime { get; set; }

        [Required]
        [Display(Name = "Horário de Saída")]
        public TimeSpan DepartureTime { get; set; }

        [Required]
        [Display(Name = "Status")]
        public bool Status { get; set; }

        [Required]
        public Dictionary<int, string> AllowedSpecies { get; set; }
    }
}