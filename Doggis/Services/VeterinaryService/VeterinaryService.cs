using Doggis.Data.UnitOfWork;
using Doggis.ViewModel;
using Enums.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return _unitOfWork.User.Get(u => u.Type == Enums.User.UserType.Vet).OrderByDescending(u => u.Status).Select(u => new VeterinaryViewModel()
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

        public EditVeterinaryViewModel GetVeterinary(Guid id)
        {
            var vet = _unitOfWork.User.FirstOrDefault(v => v.ID == id);
            if(vet != null)
            {
                var vetEditable = new EditVeterinaryViewModel()
                {
                    ID = vet.ID,
                    Name = vet.Name,
                    Identification = vet.Identification,
                    NationalInsuranceNumber = vet.NationalInsuranceNumber,
                    CouncilNumber = vet.CouncilNumber,
                    EntryTime = vet.EntryTime ?? new TimeSpan(),
                    DepartureTime = vet.DepartureTime ?? new TimeSpan(),
                    Status = vet.Status
                };
                var vetAllowedSpecies = vet.VeterinaryAllowedSpecies.ToList();
                vetEditable.AllowedSpecies = new Dictionary<int, string>(vetAllowedSpecies.ToDictionary(s => (int)s.Specie, s => EnumHelper.GetDescription(s.Specie)));

                return vetEditable;
            }
            return null;
        }

        public Dictionary<int, string> GetNotUsedSpecies(EditVeterinaryViewModel vet, SelectList species)
        {
            var vetAllowedSpecies = vet.AllowedSpecies.Select(a => a.Value);
            return new Dictionary<int, string>(species.Where(s => !vetAllowedSpecies.Contains(s.Value)).ToDictionary(s => Convert.ToInt32(s.Value), s => s.Text));
        }
    }
}