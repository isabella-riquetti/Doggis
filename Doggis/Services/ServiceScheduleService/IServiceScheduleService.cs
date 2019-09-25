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
        UserAvaliationViewModel GetServiceSchedule(Guid serviceScheduleId);
        UserAvaliationViewModel GetServiceSchedule(Guid serviceScheduleID, int score, string description);
        bool CreateAvaliation(UserAvaliationViewModel avaliation);
    }
}