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
            return _unitOfWork.User.Get(u => u.Type == Data.Enum.User.UserType.Vet).OrderByDescending(u => u.Status).Select(u => new VeterinaryViewModel()
            {
                ID = u.ID,
                Name = u.Name,
                Identification = u.Identification,
                NationalInsuranceNumber = u.NationalInsuranceNumber,
                CouncilNumber = u.CouncilNumber,
                EntryTime = (TimeSpan)u.EntryTime,
                DepartureTime = (TimeSpan)u.DepartureTime,
                Status = u.Status ? "Ativo" : "Inativo"
            }).ToList();
        }

        public bool DisableVet(Guid id, bool status)
        {
            var vet = _unitOfWork.User.FirstOrDefault(u => u.ID == id);
            if (vet == null)
                return false;

            vet.Status = status;
            _unitOfWork.Commit();

            return true;
        }
    }
}