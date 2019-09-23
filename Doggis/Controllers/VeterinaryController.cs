using Doggis.Models;
using Doggis.Services;
using Doggis.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doggis.Controllers
{
    public class VeterinaryController : Controller
    {
        private readonly IVeterinaryService _veterinaryService;

        public VeterinaryController(IVeterinaryService veterinaryService)
        {
            _veterinaryService = veterinaryService;
        }

        // GET: Veterinary
        public ActionResult Index(string alertMessage, string alertType)
        {
            if(!String.IsNullOrEmpty(alertMessage) && !String.IsNullOrEmpty(alertType))
            {
                ViewBag.AlertMessage = alertMessage;
                ViewBag.AlertType = alertType;
            }
            var veterinaries = _veterinaryService.GetVeterinaries();
            return View(veterinaries);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", new { alertMessage = "Selecione um veterinário para editar", alertType = "alert-danger"});
            }

            var vet = _veterinaryService.GetVeterinary((Guid)id);

            var allSpecies = Helpers.EnumDictionary<Enums.Pet.Specie>();
            var speciesWithSelected = _veterinaryService.SetAllowedSpecies(vet.AllowedSpecies, allSpecies);
            ViewBag.Species = speciesWithSelected;

            return View(vet);
        }

        [HttpPost]
        public ActionResult Edit(EditVeterinaryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var allSpecies = Helpers.EnumDictionary<Enums.Pet.Specie>();
                var speciesWithSelected = _veterinaryService.SetAllowedSpecies(model.AllowedSpecies, allSpecies);
                ViewBag.Species = speciesWithSelected;

                return View(model);
            }

            var result = _veterinaryService.UpdateVet(model);
            if(result)
                return RedirectToAction("Index", new { alertMessage = "Veterinário editado com sucesso!", alertType = "alert-sucess" });
            else
                return RedirectToAction("Index", new { alertMessage = "Não foi possível editar o veterinário.", alertType = "alert-danger" });
        }
    }
}