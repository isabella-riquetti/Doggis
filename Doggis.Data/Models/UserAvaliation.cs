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
        public Guid ServiceScheduleID { get; set; }
        public int Score { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }

        public virtual Client Client { get; set; }
        public virtual ServiceSchedule Schedule { get; set; }
    }
}
