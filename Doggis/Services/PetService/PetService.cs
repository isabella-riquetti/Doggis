using Doggis.Data.UnitOfWork;
using Doggis.ViewModel;
using Enums.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doggis.Services
{
    public class PetService : IPetService
    {

        private readonly IUnitOfWork _unitOfWork;

        public PetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Dictionary<Guid, string> GetActiveClient()
        {
            return _unitOfWork.Client.Get(c => c.Status).OrderBy(u => u.Name).ToDictionary(c => c.ID, c=> String.Concat(c.NationalInsuranceNumber, " - ", c.Name));
        }

        public List<PetViewModel> GetPets()
        {
            var pets = _unitOfWork.Pet.Get().OrderByDescending(u => u.Status).ThenBy(u => u.Name).Select(u => new PetViewModel()
            {
                ID = u.ID,
                OwnerName = u.Owner.Name,
                Name = u.Name,
                Breed = u.Breed,
                Specie = u.Specie,
                AllowsPhotos = u.AllowsPhotos ? "Sim" : "Não",
                Status = u.Status ? "Ativo" : "Inativo"
            }).ToList();

            pets.ForEach(p =>
            {
                p.SpecieText = EnumHelper.GetDescription(p.Specie);
            });

            return pets;
        }

        public PetViewModel GetPetDetails(Guid id)
        {
            var pet = _unitOfWork.Pet.FirstOrDefault(v => v.ID == id);
            if (pet != null)
            {
                var petDetails = new PetViewModel();
                petDetails.ID = pet.ID;
                petDetails.OwnerName = pet.Owner.Name;
                petDetails.Name = pet.Name;
                petDetails.Breed = pet.Breed;
                petDetails.SpecieText = EnumHelper.GetDescription(pet.Specie);
                petDetails.SizeText = pet.Size != null ? EnumHelper.GetDescription(pet.Size) : "";
                petDetails.Alergies = String.IsNullOrEmpty(pet.Alergies) ? "Nenhuma" : pet.Alergies;
                petDetails.Description = String.IsNullOrEmpty(pet.Description) ? "Nenhuma" : pet.Description;
                petDetails.AllowsPhotos = pet.AllowsPhotos ? "Sim" : "Não";
                petDetails.Status = pet.Status ? "Ativo" : "Inativo";

                return petDetails;
            }
            return null;
        }

        public EditablePetViewModel GetPet(Guid id)
        {
            var pet = _unitOfWork.Pet.FirstOrDefault(v => v.ID == id);
            if (pet != null)
            {
                return new EditablePetViewModel()
                {
                    ID = pet.ID,
                    OwnerName = pet.Owner.Name,
                    Specie = (int)pet.Specie,
                    Name = pet.Name,
                    Breed = pet.Breed,
                    Size = pet.Size != null ? (int)pet.Size : 0,
                    Alergies = pet.Alergies,
                    Description = pet.Description,
                    AllowsPhotos = pet.AllowsPhotos,
                    Status = pet.Status
                };
            }
            return null;
        }

        public bool UpdatePet(EditablePetViewModel model)
        {
            var pet = _unitOfWork.Pet.FirstOrDefault(v => v.ID == model.ID);
            if (pet != null)
            {
                pet.Specie = (Enums.Pet.Specie)model.Specie;
                pet.Name = model.Name;
                pet.Breed = model.Breed;
                pet.Size = model.Specie == 0 ? (Enums.Pet.Size)(model.Size ?? 0) : Enums.Pet.Size.Default;
                pet.Alergies = model.Alergies;
                pet.Description = model.Description;
                pet.AllowsPhotos = model.AllowsPhotos;
                pet.Status = model.Status;

                _unitOfWork.Pet.Edit(pet);
                _unitOfWork.Commit();
                return true;
            }

            return false;
        }

        public bool CreatePet(CreatePetViewModel model)
        {
            try
            {
                var pet = new Data.Models.Pet()
                {
                    ID = Guid.NewGuid(),
                    Specie = (Enums.Pet.Specie)model.Specie,
                    Name = model.Name,
                    Breed = model.Breed,
                    Size = model.Specie == 0 ? (Enums.Pet.Size)(model.Size ?? 0) : Enums.Pet.Size.Default,
                    Alergies = model.Alergies,
                    Description = model.Description,
                    AllowsPhotos = model.AllowsPhotos,
                    Status = model.Status,
                    OwnerID = model.OwnerID
                };

                _unitOfWork.Pet.Add(pet);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}