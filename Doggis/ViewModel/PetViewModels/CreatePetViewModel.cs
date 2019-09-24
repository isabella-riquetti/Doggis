using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Doggis.ViewModel
{
    public class CreatePetViewModel : EditablePetViewModel
    {
        [Required(ErrorMessage = "O campo dono é obrigatório")]
        public Guid OwnerID { get; set; }
    }
}