using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Repository
{
    public class PromotionRepository : RepositoryBase<Doggis.Data.Models.Promotion>, IPromotionRepository
    {
        private readonly DoggisContext _context;

        public PromotionRepository(DoggisContext context) : base(context)
        {
            _context = context;
        }
    }
}
