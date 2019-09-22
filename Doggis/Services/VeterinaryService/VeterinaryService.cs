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
            return _unitOfWork.User.Get(u => u.Type == Data.Enum.User.UserType.Vet && u.Status).Select(u => new VeterinaryViewModel()
            {
                ID = u.ID,
                Name = u.Name,
                Identification = u.Identification,
                NationalInsuranceNumber = u.NationalInsuranceNumber,
                CouncilNumber = u.CouncilNumber,
                EntryTime = (TimeSpan)u.EntryTime,
                DepartureTime = (TimeSpan)u.DepartureTime
            }).ToList();
        }
    }
}