using Doggis.ViewModel;
using Doggis.ViewModel.VeterinaryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doggis.Services
{
    public interface IVeterinaryService
    {
        List<VeterinaryViewModel> GetVeterinaries();
        bool DisableVet(Guid id, bool status);
        EditableVeterinaryViewModel GetVeterinary(Guid id);
        List<Species> SetAllowedSpecies(List<int> allowedSpecies, Dictionary<int, string> species);
        bool UpdateVet(EditableVeterinaryViewModel model);
        bool CreateVet(EditableVeterinaryViewModel model);
        bool DeleteVet(Guid id);
        VetViewModel GetVetDetails(Guid id);
    }
}