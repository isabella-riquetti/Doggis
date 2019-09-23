using Doggis.ViewModel;
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
        EditVeterinaryViewModel GetVeterinary(Guid id);
        Dictionary<int, string> GetNotUsedSpecies(EditVeterinaryViewModel vet, SelectList species);
    }
}