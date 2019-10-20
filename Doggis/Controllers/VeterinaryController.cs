using Doggis.Models;
using Doggis.Services;
using Doggis.ViewModel;
using Enums.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doggis.Controllers
{
    [Authorize(Roles = "IsAdmin")]
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
            SetViewBagMessage();

            var veterinaries = _veterinaryService.GetVeterinaries();
            return View(veterinaries);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                SetSessionNotification("Selecione um veterinário para editar!", "alert-danger");
                return RedirectToAction("Index");
            }

            var vet = _veterinaryService.GetVeterinary((Guid)id);

            var allSpecies = EnumHelper.EnumDictionary<Enums.Pet.Specie>();
            var speciesWithSelected = _veterinaryService.SetAllowedSpecies(vet.AllowedSpecies, allSpecies);
            ViewBag.Species = speciesWithSelected;
            ViewBag.ButtonText = "Editar";

            return View(vet);
        }

        [HttpPost]
        public ActionResult Edit(EditableVeterinaryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var allSpecies = EnumHelper.EnumDictionary<Enums.Pet.Specie>();
                var speciesWithSelected = _veterinaryService.SetAllowedSpecies(model.AllowedSpecies, allSpecies);
                ViewBag.Species = speciesWithSelected;

                ViewBag.ButtonText = "Editar";
                return View(model);
            }

            var result = _veterinaryService.UpdateVet(model);
            if (result)
            {
                SetSessionNotification("Veterinário editado com sucesso!", "alert-success");
                return RedirectToAction("Index");
            }
            else
            {
                SetSessionNotification("Não foi possível editar o veterinário.", "alert-danger");
                return RedirectToAction("Index");
            }
        }

        public ActionResult Create()
        {
            var allSpecies = EnumHelper.EnumDictionary<Enums.Pet.Specie>();
            var speciesWithSelected = _veterinaryService.SetAllowedSpecies(null, allSpecies);
            ViewBag.Species = speciesWithSelected;
            ViewBag.ButtonText = "Criar";

            return View(new EditableVeterinaryViewModel() { ID = Guid.NewGuid(), Status = true});
        }

        [HttpPost]
        public ActionResult Create(EditableVeterinaryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var allSpecies = EnumHelper.EnumDictionary<Enums.Pet.Specie>();
                var speciesWithSelected = _veterinaryService.SetAllowedSpecies(model.AllowedSpecies, allSpecies);
                ViewBag.Species = speciesWithSelected;

                ViewBag.ButtonText = "Criar";
                return View(model);
            }

            var result = _veterinaryService.CreateVet(model);
            if (result)
            {
                SetSessionNotification("Veterinário criado com sucesso!", "alert-success");
                return RedirectToAction("Index");
            }
            else
            {
                SetSessionNotification("Não foi possível criar o veterinário.", "alert-danger");
                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                SetSessionNotification("Selecione um veterinário para ver os detalhes!", "alert-danger");
                return RedirectToAction("Index");
            }

            var vet = _veterinaryService.GetVetDetails((Guid)id);
            if(vet == null)
            {
                SetSessionNotification("Não foi encontrado um veterinário com o identificador informado.", "alert-danger");
                return RedirectToAction("Index");
            }

            return View(vet);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                SetSessionNotification("Selecione um vet para deletar!", "alert-danger");
                return RedirectToAction("Index");
            }

            var result = _veterinaryService.DeleteVet((Guid)id);
            if (!result)
                SetSessionNotification("Não foi possível exluir o veterinário!", "alert-danger");

            return RedirectToAction("Index");
        }

        public void SetSessionNotification(string message, string type)
        {
            Session["NotificationMessage"] = message;
            Session["NotificationType"] = type;
        }

        public void SetViewBagMessage()
        {
            var notificationMessage = Session["NotificationMessage"]?.ToString();
            if (!String.IsNullOrEmpty(notificationMessage))
            {
                var notificationType = Session["NotificationType"]?.ToString();

                ViewBag.NotificationMessage = notificationMessage;
                ViewBag.NotificationType = notificationType;
                Session["NotificationMessage"] = "";
                Session["NotificationType"] = "";
            }
        }
    }
}