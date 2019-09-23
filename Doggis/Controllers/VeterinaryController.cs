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
        public ActionResult Index()
        {
            var veterinaries = _veterinaryService.GetVeterinaries();
            return View(veterinaries);
        }

        public ActionResult Edit(Guid id)
        {
            var vet = _veterinaryService.GetVeterinary(id);

            var species = Helpers.EnumSelectlist<Enums.Pet.Specie>(true);
            ViewBag.NotUsedSpecies = _veterinaryService.GetNotUsedSpecies(vet, species);

            return View(vet);
        }

        [HttpPost]
        public ActionResult Edit(EditVeterinaryViewModel model)
        {
            var species = Helpers.EnumSelectlist<Enums.Pet.Specie>(true);
            ViewBag.NotUsedSpecies = _veterinaryService.GetNotUsedSpecies(model, species);

            if (!ModelState.IsValid)
                return View(model);

            return Index();
        }
    }
}