using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Models
{
    public class ServiceSchedule
    {
        public Guid ID { get; set; }
        public Guid ServiceID { get; set; }
        public DateTime Schedule { get; set; }
        public Guid ClientID { get; set; }
        public Guid PetID { get; set; }
        public Guid ResponsibleID { get; set; }
        public bool Finished { get; set; }

    }
}
