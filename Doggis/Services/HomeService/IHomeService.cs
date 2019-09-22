using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doggis.Services
{
    public interface IHomeService
    {
        public int GetPendingServiceScheduleCount()
        {
            return _unitOfWork.ServiceSchedule.Get(s => s.Schedule > DateTime.Now.Brasilia()).Count();
        }

        public int GetClientCount()
        {
            return _unitOfWork.Client.Get().Count();
        }

        public int GetPetCount()
        {
            return _unitOfWork.Pet.Get().Count();
        }

        public int GetOrderCount()
        {
            return _unitOfWork.Order.Get().Count();
        }

        public int GetClientPendingAvaliationCount(Guid clientID)
        {
            return _unitOfWork.ServiceSchedule.Get(s => s.Schedule < DateTime.Now.Brasilia() && s.ClientID == clientID && s.Avaliations.Count() == 0).Count();
        }

        public int GetClientPendingServiceScheduleCount(Guid clientID)
        {
            return _unitOfWork.ServiceSchedule.Get(s => s.Schedule > DateTime.Now.Brasilia() && s.ClientID == clientID).Count();
        }

        public int GetClientPetCount(Guid clientID)
        {
            return _unitOfWork.Pet.Get(p => p.OwnerId == clientID).Count();
        }

        public int GetClientPataz(Guid clientID)
        {
            return _unitOfWork.Client.FirstOrDefault(p => p.ID == clientID).Pataz;
        }
    }
}