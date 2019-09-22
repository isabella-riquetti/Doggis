using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Repository
{
    public class UserAvaliationRepository : RepositoryBase<Doggis.Data.Models.UserAvaliation>, IUserAvaliationRepository
    {
        private readonly DoggisContext _context;

        public UserAvaliationRepository(DoggisContext context) : base(context)
        {
            _context = context;
        }
    }
}
