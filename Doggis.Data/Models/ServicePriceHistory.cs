using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Models
{
    public class ServicePriceHistory
    {
        public Guid ID { get; set; }
        public Guid ServiceID { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? DisabledBy { get; set; }

        public virtual Service Service { get; set; }
        public virtual User CreatedByUser { get; set; }
        public virtual User DisabledByUser { get; set; }

        public ServicePriceHistory()
        {

        }
    }
}
