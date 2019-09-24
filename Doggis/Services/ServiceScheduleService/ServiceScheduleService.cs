using Doggis.Data.UnitOfWork;
using Doggis.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doggis.Services
{
    public class ServiceScheduleService : IServiceScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceScheduleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ServiceScheduleViewModel> GetServiceSchedules(Guid ClientID)
        {
            var schedules = _unitOfWork.ServiceSchedule.Get(s => s.ClientID == ClientID).Select(s => new ServiceScheduleViewModel()
            {
                ID = s.ID,
                ServiceName = s.Service.Name,
                PetName = s.Pet.Name,
                ResponsibleName = s.Responsible.Name,
                StatusText = s.Finished && s.Status ? "Pago" : (s.Status ? "Pendente" : "Cancelado"),
                Schedule = s.Schedule,
                Scored = s.Scored,
                Score = s.Scored ? s.Avaliations.FirstOrDefault().Score : 0
            }).ToList();

            schedules.ForEach(s =>
            {
                s.ScheduleText = String.Concat(s.Schedule.ToShortTimeString(), " ", s.Schedule.ToShortTimeString());
            });

            return schedules;
        }
    }
}