using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Repository
{
    public class OrderRepository : RepositoryBase<Doggis.Data.Models.Order>, IOrderRepository
    {
        private readonly DoggisContext _context;

        public OrderRepository(DoggisContext context) : base(context)
        {
            _context = context;
        }
    }
}
