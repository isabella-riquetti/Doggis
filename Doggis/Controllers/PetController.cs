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
    [Authorize(Roles = "IsAttendant")]
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

            var pets = _petService.GetPets();
            return View(pets);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                SetSessionNotification("Selecione um pet para editar!", "alert-danger");
                return RedirectToAction("Index");
            }

            var pet = _petService.GetPet((Guid)id);

            GetViewBags();

            return View(pet);
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                SetSessionNotification("Selecione um pet para ver os detalhes!", "alert-danger");
                return RedirectToAction("Index");
            }

            var pet = _petService.GetPetDetails((Guid)id);
            if (pet == null)
            {
                SetSessionNotification("Não foi encontrado um pet com o identificador informado.", "alert-danger");
                return RedirectToAction("Index");
            }

            return View(pet);
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

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                SetSessionNotification("Selecione um pet para deletar!", "alert-danger");
                return RedirectToAction("Index");
            }

            var result = _petService.DeletePet((Guid)id);
            if(!result)
                SetSessionNotification("Não foi possível exluir o pet!", "alert-danger");

            return RedirectToAction("Index");
        }

        public void GetViewBags()
        {
            ViewBag.Species = EnumHelper.EnumDictionary<Enums.Pet.Specie>();
            ViewBag.Sizes = EnumHelper.EnumDictionary<Enums.Pet.Size>();
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