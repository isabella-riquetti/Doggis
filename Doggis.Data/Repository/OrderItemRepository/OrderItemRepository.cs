using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Repository
{
    public class OrderItemRepository : RepositoryBase<Doggis.Data.Models.OrderItem>, IOrderItemRepository
    {
        private readonly DoggisContext _context;

        public OrderItemRepository(DoggisContext context) : base(context)
        {
            _context = context;
        }
    }
}
