using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Models
{
    public class User
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string Identification { get; set; }
        public string NationalInsuranceNumber { get; set; }
        public string CouncilNumber { get; set; }
        public TimeSpan EntryTime { get; set; }
        public TimeSpan DepartureTime { get; set; }
    }
}
