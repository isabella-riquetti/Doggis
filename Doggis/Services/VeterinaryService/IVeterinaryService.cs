using Doggis.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doggis.Services
{
    public interface IVeterinaryService
    {
        List<VeterinaryViewModel> GetVeterinaries();
        bool DisableVet(Guid id, bool status);
    }
}