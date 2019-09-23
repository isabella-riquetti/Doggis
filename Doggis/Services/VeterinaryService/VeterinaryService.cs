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
                Status = u.Status ? "Ativo" : "Inativo",
                AllowedSpeciesCount = u.VeterinaryAllowedSpecies.Count()
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
                return new EditVeterinaryViewModel()
                {
                    ID = vet.ID,
                    Name = vet.Name,
                    Identification = vet.Identification,
                    NationalInsuranceNumber = vet.NationalInsuranceNumber,
                    CouncilNumber = vet.CouncilNumber,
                    EntryTime = vet.EntryTime ?? new TimeSpan(),
                    DepartureTime = vet.DepartureTime ?? new TimeSpan(),
                    Status = vet.Status,
                    AllowedSpecies = vet.VeterinaryAllowedSpecies.Select(s => (int)s.Specie).ToList()
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

        public bool UpdateVet(EditVeterinaryViewModel model)
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

                var currentAllowedSpecies = vet.VeterinaryAllowedSpecies.ToList();
                var currentAllowedSpeciesValue = currentAllowedSpecies.Select(v => (int)v.Specie);

                foreach (var newAllowedSpecie in model.AllowedSpecies.Where(a => !currentAllowedSpeciesValue.Contains(a)))
                    _unitOfWork.VeterinaryAllowedSpecies.Add(new Data.Models.VeterinaryAllowedSpecie()
                    {
                        ID = Guid.NewGuid(),
                        Specie = (Enums.Pet.Specie)newAllowedSpecie,
                        VeterinaryID = vet.ID
                    });

                foreach (var oldAllowedSpecie in currentAllowedSpecies.Where(a => !model.AllowedSpecies.Contains((int)a.Specie)))
                    _unitOfWork.VeterinaryAllowedSpecies.Delete(oldAllowedSpecie);

                _unitOfWork.Commit();
                return true;
            }

            return false;
        }
    }
}