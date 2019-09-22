using Doggis.Data.Service.ChangeTrackerService;
using System;
using System.Linq;
using System.Threading;
using System.Web;

namespace Doggis.Data.Repository
{
    public class DoggisContext : DoggisontextLog
    {
        public const string ContextName = "DoggisContext";
        private readonly IChangeTrackerService _changeTrackerService;

        public DoggisContext() : base(ContextName)
        {
            _changeTrackerService = new ChangeTrackerService();
        }
    }
}



