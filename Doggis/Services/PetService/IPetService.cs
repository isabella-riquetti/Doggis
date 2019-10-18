using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Doggis.ViewModel;

namespace Doggis.Services
{
    public interface IPetService
    {
        Dictionary<Guid, string> GetActiveClient();
        List<PetViewModel> GetPets();
        PetViewModel GetPetDetails(Guid id);
        EditablePetViewModel GetPet(Guid id);
        bool UpdatePet(EditablePetViewModel model);
        bool CreatePet(CreatePetViewModel model);
        bool DeletePet(Guid id);
    }
}