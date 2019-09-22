using Doggis.Data.UnitOfWork;
using Doggis.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Doggis.Services
{
    public class VeterinaryService : IVeterinaryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public VeterinaryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<VeterinaryViewModel> GetVeterinaries()
        {
            return _unitOfWork.User.Get(u => u.Type == Data.Enum.User.UserType.Vet).Select(u => new VeterinaryViewModel()
            {
                ID = u.ID,
                Name = u.Name,
                Identification = u.Identification,
                NationalInsuranceNumber = u.NationalInsuranceNumber,
                CouncilNumber = u.CouncilNumber,
                EntryTime = GetTimeWithouMilliseconds((TimeSpan)u.EntryTime),
                DepartureTime = GetTimeWithouMilliseconds((TimeSpan)u.DepartureTime)
            }).ToList();
        }

        private string GetTimeWithouMilliseconds(TimeSpan time)
        {
            return String.Format(CultureInfo.CurrentCulture, "{0}:{1}:{2}", time.Hours, time.Minutes, time.Seconds);
        }
    }
}