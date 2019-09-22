using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Models
{
    public class Service
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public TimeSpan EstimatedTime { get; set; }
        public string Price { get; set; }
        public int Responsable { get; set; }
        public int PatazGiven { get; set; }
        public int PatazPrice { get; set; }
    }
}
