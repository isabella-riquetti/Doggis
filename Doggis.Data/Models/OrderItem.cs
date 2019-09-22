using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Models
{
    public class OrderItem
    {
        public Guid ID { get; set; }
        public Guid OrderID { get; set; }
        public int Type { get; set; }
        public Guid ServiceScheduleID { get; set; }
        public Guid ProductID { get; set; }
        public string OriginalPrice { get; set; }
        public Guid PromotionID { get; set; }
        public string PaidPrice { get; set; }
    }
}
