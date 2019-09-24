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
    public class PetController : Controller
    {

        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        // GET: Veterinary
        public ActionResult Index()
        {
            SetViewBagMessage();

            var veterinaries = _petService.GetPets();
            return View(veterinaries);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", new { alertMessage = "Selecione um pet para editar", alertType = "alert-danger" });
            }

            var vet = _petService.GetPet((Guid)id);

            GetViewBags();

            return View(vet);
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", new { alertMessage = "Selecione um pet para editar", alertType = "alert-danger" });
            }

            var vet = _petService.GetPetDetails((Guid)id);

            return View(vet);
        }

        [HttpPost]
        public ActionResult Edit(EditablePetViewModel model)
        {
            if (!ModelState.IsValid)
            {
                GetViewBags();

                return View(model);
            }

            var result = _petService.UpdatePet(model);
            if (result)
            {
                SetSessionNotification("Pet editado com sucesso!", "alert-success");
                return RedirectToAction("Index");
            }
            else
            {
                SetSessionNotification("Não foi possível editar o pet.", "alert-danger");
                return RedirectToAction("Index");
            }
        }

        public ActionResult Create()
        {
            GetViewBags();
            ViewBag.Clients = _petService.GetActiveClient();

            return View(new CreatePetViewModel() { ID = Guid.NewGuid(), Status = true });
        }

        [HttpPost]
        public ActionResult Create(CreatePetViewModel model)
        {
            if (!ModelState.IsValid)
            {
                GetViewBags();
                ViewBag.Clients = _petService.GetActiveClient();
                return View(model);
            }

            var result = _petService.CreatePet(model);
            if (result)
            {
                SetSessionNotification("Pet criado com sucesso!", "alert-success");
                return RedirectToAction("Index");
            }
            else
            {
                SetSessionNotification("Não foi possível criar o pet.", "alert-danger");
                return RedirectToAction("Index");
            }
        }

        public void GetViewBags()
        {
            ViewBag.Species = Helpers.EnumDictionary<Enums.Pet.Specie>();
            ViewBag.Sizes = Helpers.EnumDictionary<Enums.Pet.Size>();
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