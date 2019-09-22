using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Repository
{
    public class ClientRepository : RepositoryBase<Doggis.Data.Models.Client>, IClientRepository
    {
        private readonly DoggisContext _context;

        public ClientRepository(DoggisContext context) : base(context)
        {
            _context = context;
        }
    }
}
