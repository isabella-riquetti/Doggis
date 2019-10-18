using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Doggis.ViewModel.VeterinaryViewModels
{
    public class VetViewModel
    {
        public Guid ID { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "RG")]
        public string Identification { get; set; }

        [Display(Name = "CPF")]
        public string NationalInsuranceNumber { get; set; }

        [Display(Name = "Nº do Conselho")]
        public string CouncilNumber { get; set; }

        [Display(Name = "Horário de Entrada")]
        public string EntryTime { get; set; }

        [Display(Name = "Horário de Saída")]
        public string DepartureTime { get; set; }

        [Display(Name = "Espécies Tratadas")]
        public List<string> AllowedSpecies { get; set; }
    }
}