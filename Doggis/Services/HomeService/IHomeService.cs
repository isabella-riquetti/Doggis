using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doggis.Services
{
    public interface IHomeService
    {
        int GetPendingServiceScheduleCount();

        int GetClientCount();

        int GetPetCount();

        int GetOrderCount();

        int GetClientPendingAvaliationCount(Guid clientID);

        int GetClientPendingServiceScheduleCount(Guid clientID);

        int GetClientPetCount(Guid clientID);

        int GetClientPataz(Guid clientID);
    }
}