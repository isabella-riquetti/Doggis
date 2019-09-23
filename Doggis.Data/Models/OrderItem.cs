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
        public Enums.OrderItem.OrderItemType Type { get; set; }
        public Guid ServiceScheduleID { get; set; }
        public Guid ProductID { get; set; }
        public decimal OriginalPrice { get; set; }
        public Guid? PromotionID { get; set; }
        public decimal PaidPrice { get; set; }
        public bool Status { get; set; }

        public virtual Order Order { get; set; }
        public virtual ServiceSchedule ServiceSchedule { get; set; }
        public virtual Product Product { get; set; }
        public virtual Promotion Promotion { get; set; }

        public OrderItem()
        {

        }
    }
}
