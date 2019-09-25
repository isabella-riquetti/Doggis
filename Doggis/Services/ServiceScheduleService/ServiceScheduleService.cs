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

        public UserAvaliationViewModel GetServiceSchedule(Guid serviceScheduleID)
        {
            return GetServiceSchedule(serviceScheduleID, 0, "");
        }

        public UserAvaliationViewModel GetServiceSchedule(Guid serviceScheduleID, int score, string description)
        {
            var schedule = _unitOfWork.ServiceSchedule.FirstOrDefault(s => s.ID == serviceScheduleID);
            if (schedule == null)
            {
                return null;
            }

            var avaliation = new UserAvaliationViewModel()
            {
                ServiceScheduleID = schedule.ID,
                ClientID = schedule.ClientID,
                ServiceName = schedule.Service.Name,
                PetName = schedule.Pet.Name,
                ResponsibleName = schedule.Responsible.Name,
                Description = description,
                Score = score,
                ScheduleText = String.Concat(schedule.Schedule.ToShortDateString(), " ", schedule.Schedule.ToShortTimeString())
            };

            return avaliation;
        }

        public bool CreateAvaliation(UserAvaliationViewModel avaliation)
        {
            var service = _unitOfWork.ServiceSchedule.FirstOrDefault(s => s.ID == avaliation.ServiceScheduleID);
            if (service == null)
                return false;

            service.Scored = true;
            _unitOfWork.ServiceSchedule.Edit(service);
            _unitOfWork.UserAvaliation.Add(new Data.Models.UserAvaliation()
            {
                ID = Guid.NewGuid(),
                ClientID = avaliation.ClientID,
                ServiceScheduleID = avaliation.ServiceScheduleID,
                Score = avaliation.Score,
                Description = avaliation.Description,
                Status = true
            });

            try
            {
                _unitOfWork.Commit();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public List<ServiceScheduleViewModel> GetServiceSchedules(Guid ClientID)
        {
            var schedules = _unitOfWork.ServiceSchedule.Get(s => s.ClientID == ClientID && s.Finished && s.Status)
                .OrderBy(s => s.Scored).ThenBy(s => s.Schedule).Select(s => new ServiceScheduleViewModel()
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
                s.ScheduleText = String.Concat(s.Schedule.ToShortDateString(), " ", s.Schedule.ToShortTimeString());
            });

            return schedules;
        }
    }
}