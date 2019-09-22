using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Repository
{
    public class ServiceScheduleRepository : RepositoryBase<Doggis.Data.Models.ServiceSchedule>, IServiceScheduleRepository
    {
        private readonly DoggisContext _context;

        public ServiceScheduleRepository(DoggisContext context) : base(context)
        {
            _context = context;
        }
    }
}
