using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Models
{
    public class Promotion
    {
        public Guid ID { get; set; }
        public bool AppliedToService { get; set; }
        public bool AppliedToProduct { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public Promotion()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
