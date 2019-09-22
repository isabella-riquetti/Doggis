using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Repository
{
    public class ServiceRepository : RepositoryBase<Doggis.Data.Models.Service>, IServiceRepository
    {
        private readonly DoggisContext _context;

        public ServiceRepository(DoggisContext context) : base(context)
        {
            _context = context;
        }
    }
}
