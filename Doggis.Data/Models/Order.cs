using Doggis.Data.Enum;
using System;
using System.Collections.Generic;

namespace Doggis.Data.Models
{
    public class Order
    {
        public Guid ID { get; set; }
        public string ProtocolNumber { get; set; }
        public bool? Paid { get; set; }
        public Enum.Order.PaymentType? PaymentType { get; set; }
        public decimal? TotalPrice { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
