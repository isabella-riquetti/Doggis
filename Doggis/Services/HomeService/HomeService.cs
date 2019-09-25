using Doggis.Data.UnitOfWork;
using Doggis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doggis.Services
{
    public class HomeService : IHomeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int GetPendingServiceScheduleCount()
        {
            var today = DateTime.Now.Brasilia();
            return _unitOfWork.ServiceSchedule.Get(s => s.Schedule > today && s.Status).Count();
        }

        public int GetClientCount()
        {
            return _unitOfWork.Client.Get(c => c.Status).Count();
        }

        public int GetPetCount()
        {
            return _unitOfWork.Pet.Get(p => p.Status).Count();
        }

        public int GetOrderCount()
        {
            return _unitOfWork.Order.Get(o => o.Status).Count();
        }

        public int GetClientPendingAvaliationCount(Guid clientID)
        {
            var today = DateTime.Now.Brasilia();
            return _unitOfWork.ServiceSchedule.Get(s => s.Status && s.Schedule < today && s.ClientID == clientID && s.Avaliations.Where(a => a.Status).Count() == 0).Count();
        }

        public int GetClientPendingServiceScheduleCount(Guid clientID)
        {
            var today = DateTime.Now.Brasilia();
            return _unitOfWork.ServiceSchedule.Get(s => s.Schedule > today && s.ClientID == clientID && s.Status && !s.Finished).Count();
        }

        public int GetClientPetCount(Guid clientID)
        {
            return _unitOfWork.Pet.Get(p => p.OwnerID == clientID && p.Status).Count();
        }

        public int GetClientPataz(Guid clientID)
        {
            return _unitOfWork.Client.FirstOrDefault(p => p.ID == clientID && p.Status).Pataz;
        }
    }
}