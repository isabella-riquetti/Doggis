using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Repository
{
    public class UserRepository : RepositoryBase<Doggis.Data.Models.User>, IUserRepository
    {
        private readonly DoggisContext _context;

        public UserRepository(DoggisContext context) : base(context)
        {
            _context = context;
        }
    }
}
