using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Repository
{
    public class PetRepository : RepositoryBase<Doggis.Data.Models.Pet>, IPetRepository
    {
        private readonly DoggisContext _context;

        public PetRepository(DoggisContext context) : base(context)
        {
            _context = context;
        }
    }
}
