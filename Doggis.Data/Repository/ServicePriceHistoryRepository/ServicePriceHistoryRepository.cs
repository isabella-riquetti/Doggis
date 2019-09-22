using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Repository
{
    public class ServicePriceHistoryRepository : RepositoryBase<Doggis.Data.Models.ServicePriceHistory>, IServicePriceHistoryRepository
    {
        private readonly DoggisContext _context;

        public ServicePriceHistoryRepository(DoggisContext context) : base(context)
        {
            _context = context;
        }
    }
}
