using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Models
{
    public class VeterinaryAllowedSpecies
    {
        public Guid ID { get; set; }
        public Guid VeterinaryID { get; set; }
        public int Specie { get; set; }
    }
}
