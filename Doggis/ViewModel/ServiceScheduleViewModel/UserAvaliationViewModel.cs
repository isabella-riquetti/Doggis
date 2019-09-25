using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doggis.ViewModel
{
    public class UserAvaliationViewModel
    {
        [HiddenInput]
        public Guid ServiceScheduleID { get; set; }
        [HiddenInput]
        public Guid ClientID { get; set; }

        public string ResponsibleName { get; set; }
        public string PetName { get; set; }
        public string ServiceName { get; set; }
        public string ScheduleText { get; set; }
        public DateTime Schedule { get; set; }

        [Display(Name = "Nota")]
        [Required(ErrorMessage = "É necessário informar uma nota para o serviço.")]
        [Range(1,10, ErrorMessage = "A nota deve ser entre 1 e 10. Sendo 1 (Muito Ruim) e 10 (Excelente)")]
        public int Score { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "É necessário informar uma descrição para nota.")]
        [StringLength(500, MinimumLength = 20, ErrorMessage = "É necessário informar uma descrição de {2} a {1} caracteres.")]
        public string Description { get; set; }
    }
}