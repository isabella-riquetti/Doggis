using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Repository
{
    public class VeterinaryAllowedSpeciesRepository : RepositoryBase<Doggis.Data.Models.VeterinaryAllowedSpecie>, IVeterinaryAllowedSpeciesRepository
    {
        private readonly DoggisContext _context;

        public VeterinaryAllowedSpeciesRepository(DoggisContext context) : base(context)
        {
            _context = context;
        }
    }
}
