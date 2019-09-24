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
    public class ServiceScheduleController : Controller
    {
        private readonly IServiceScheduleService _serviceScheduleService;

        public ServiceScheduleController(IServiceScheduleService serviceScheduleService)
        {
            _serviceScheduleService = serviceScheduleService;
        }

        [Authorize(Roles = "IsClient")]
        public ActionResult Index()
        {
            SetViewBagMessage();

            var clientId = Helpers.GetLoggedUserId();
            var serviceScheduçes = _serviceScheduleService.GetServiceSchedules(clientId);
            return View(serviceScheduçes);
        }

        public ActionResult Avaliate()
        {
            //GetViewBags();
            //ViewBag.Clients = _petService.GetActiveClient();

            //return View(new CreatePetViewModel() { ID = Guid.NewGuid(), Status = true });
            return View();
        }

        [HttpPost]
        public ActionResult Avaliate(CreatePetViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    GetViewBags();
            //    ViewBag.Clients = _petService.GetActiveClient();
            //    return View(model);
            //}

            //var result = _petService.CreatePet(model);
            //if (result)
            //{
            //    SetSessionNotification("Pet criado com sucesso!", "alert-success");
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    SetSessionNotification("Não foi possível criar o pet.", "alert-danger");
            //    return RedirectToAction("Index");
            //}
            return View();
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