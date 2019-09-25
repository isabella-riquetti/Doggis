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

        public ActionResult Avaliate(Guid? serviceScheduleId)
        {
            if(serviceScheduleId == null)
            {
                SetSessionNotification("Não foi possível localizar o serviço.", "alert-danger");
                return RedirectToAction("Index");
            }

            var serviceSchedule = _serviceScheduleService.GetServiceSchedule((Guid)serviceScheduleId);
            if (serviceSchedule == null)
            {
                SetSessionNotification("Não foi possível localizar o serviço.", "alert-danger");
                return RedirectToAction("Index");
            }
            return View(serviceSchedule);
        }

        [HttpPost]
        public ActionResult Avaliate(UserAvaliationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var serviceSchedule = _serviceScheduleService.GetServiceSchedule((Guid)model.ServiceScheduleID, model.Score, model.Description);
                if (serviceSchedule == null)
                {
                    SetSessionNotification("Não foi possível localizar o serviço.", "alert-danger");
                    return RedirectToAction("Index");
                }
                return View(serviceSchedule);
            }

            var result = _serviceScheduleService.CreateAvaliation(model);
            if (result)
            {
                SetSessionNotification("Avaliação realizada com sucesso!", "alert-success");
                return RedirectToAction("Index");
            }
            else
            {
                SetSessionNotification("Não foi possível enviar a avaliação.", "alert-danger");
                return RedirectToAction("Index");
            }
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