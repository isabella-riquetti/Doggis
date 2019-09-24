using Doggis.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doggis.Services
{
    public interface IServiceScheduleService
    {
        List<ServiceScheduleViewModel> GetServiceSchedules(Guid ClientID);
    }
}