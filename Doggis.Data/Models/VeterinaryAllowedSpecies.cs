using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Models
{
    public class VeterinaryAllowedSpecie
    {
        public Guid ID { get; set; }
        public Guid VeterinaryID { get; set; }
        public Enums.Pet.Specie Specie { get; set; }

        public virtual User Veterinary { get; set; }
    }
}
