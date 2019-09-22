using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Enum
{
    public class Order
    {
        public enum PaymentType
        {
            Money = 0,
            DebitCard = 1,
            CreditCard = 2,
            Pataz = 3
        }
    }
}
