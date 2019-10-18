using Doggis.Data.UnitOfWork;
using Doggis.ViewModel;
using Doggis.ViewModel.VeterinaryViewModels;
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
            var vets = _unitOfWork.User.Get(u => u.Type == Enums.User.UserType.Vet).OrderByDescending(u => u.Status).ThenBy(u => u.Name).Select(u => new VeterinaryViewModel()
            {
                ID = u.ID,
                Name = u.Name,
                Identification = u.Identification,
                NationalInsuranceNumber = u.NationalInsuranceNumber,
                CouncilNumber = u.CouncilNumber,
                EntryTime = (TimeSpan)u.EntryTime,
                DepartureTime = (TimeSpan)u.DepartureTime,
                Status = u.Status ? "Ativo" : "Inativo",
                AllowedSpecies = u.VeterinaryAllowedSpecies
                
            }).ToList();

            vets.ForEach(u => u.AllowedSpeciesCount = u.AllowedSpecies != null ? EnumHelper.GetEnumsFlags<Enums.Pet.Specie>((Enums.Pet.Specie)u.AllowedSpecies, false).Count : 0);

            return vets;
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

        public EditableVeterinaryViewModel GetVeterinary(Guid id)
        {
            var vet = _unitOfWork.User.FirstOrDefault(v => v.ID == id);
            if(vet != null)
            {
                return new EditableVeterinaryViewModel()
                {
                    ID = vet.ID,
                    Name = vet.Name,
                    Identification = vet.Identification,
                    NationalInsuranceNumber = vet.NationalInsuranceNumber,
                    CouncilNumber = vet.CouncilNumber,
                    EntryTime = vet.EntryTime ?? new TimeSpan(),
                    DepartureTime = vet.DepartureTime ?? new TimeSpan(),
                    Status = vet.Status,
                    AllowedSpecies = vet.VeterinaryAllowedSpecies != null ? EnumHelper.GetEnumsFlags((Enums.Pet.Specie)vet.VeterinaryAllowedSpecies).Select(s => (int)s).ToList() : new List<int>()
                };
            }
            return null;
        }

        public List<Species> SetAllowedSpecies(List<int> allowedSpecies, Dictionary<int, string> species)
        {
            var list = new List<Species>();
            foreach (var specie in species)
            {
                var newSpecies = new Species()
                {
                    Text = specie.Value,
                    Value = specie.Key
                };
                if (allowedSpecies != null && allowedSpecies.Contains(specie.Key))
                    newSpecies.Selected = true;
                list.Add(newSpecies);
            }

            return list;
        }

        public bool UpdateVet(EditableVeterinaryViewModel model)
        {
            var vet = _unitOfWork.User.FirstOrDefault(v => v.ID == model.ID);
            if(vet != null)
            {
                vet.Name = model.Name;
                vet.Status = model.Status;
                vet.Identification = model.Identification;
                vet.NationalInsuranceNumber = model.NationalInsuranceNumber;
                vet.CouncilNumber = model.CouncilNumber;
                vet.EntryTime = model.EntryTime;
                vet.DepartureTime = model.DepartureTime;
                vet.VeterinaryAllowedSpecies = EnumHelper.ListEnumToEnumFlag(model.AllowedSpecies.Select(a => (Enums.Pet.Specie)a));

                _unitOfWork.Commit();
                return true;
            }

            return false;
        }

        public bool CreateVet(EditableVeterinaryViewModel model)
        {
            try
            {
                var vet = new Data.Models.User()
                {
                    ID = Guid.NewGuid(),
                    Name = model.Name,
                    Status = model.Status,
                    Identification = model.Identification,
                    NationalInsuranceNumber = model.NationalInsuranceNumber,
                    CouncilNumber = model.CouncilNumber,
                    EntryTime = model.EntryTime,
                    DepartureTime = model.DepartureTime,
                    Type = Enums.User.UserType.Vet,
                    VeterinaryAllowedSpecies = EnumHelper.ListEnumToEnumFlag(model.AllowedSpecies.Select(a => (Enums.Pet.Specie)a))
                };

                _unitOfWork.User.Add(vet);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteVet(Guid id)
        {
            try
            {
                var vet = _unitOfWork.User.Get(p => p.ID == id).FirstOrDefault();
                if (vet == null)
                    return false;

                _unitOfWork.User.Delete(vet);
                _unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public VetViewModel GetVetDetails(Guid id)
        {
            var vet = _unitOfWork.User.FirstOrDefault(v => v.ID == id);
            if (vet != null)
            {
                var vetDetails = new VetViewModel();
                vetDetails.ID = vet.ID;
                vetDetails.Name = vet.Name;
                vetDetails.Identification = vet.Identification;
                vetDetails.NationalInsuranceNumber = vet.NationalInsuranceNumber;
                vetDetails.CouncilNumber = vet.CouncilNumber;
                vetDetails.EntryTime = vet.EntryTime.Value.ToString();
                vetDetails.DepartureTime = vet.DepartureTime.Value.ToString();
                vetDetails.AllowedSpecies = EnumHelper.GetEnumsFlags<Enums.Pet.Specie>((Enums.Pet.Specie)vet.VeterinaryAllowedSpecies, false).Select(s => EnumHelper.GetDescription(s)).ToList();

                return vetDetails;
            }
            return null;
        }
    }
}