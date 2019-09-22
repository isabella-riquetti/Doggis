using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Models
{
    public class UserAvaliation
    {
        public Guid ID { get; set; }
        public Guid ClientID { get; set; }
        public Guid ScheduleID { get; set; }
        public int Avaliation { get; set; }
    }
}
