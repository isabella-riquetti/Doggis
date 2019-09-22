using Doggis.Models;
using Doggis.Services;
using Doggis.Services;
using Doggis.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doggis.Controllers
{
    [Authorize(Roles = "IsLogged")]
    public class HomeController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IHomeService _homeService;

        public HomeController(IServiceService serviceService, IHomeService homeService)
        {
            _serviceService = serviceService;
            _homeService = homeService;
        }

        public ActionResult Index()
        {
            if(Helpers.CurrentUserHasPermission("IsClient"))
            {
                var clientId = Helpers.GetLoggedUserId();
                return View(new HomeViewModel()
                {
                    Card1Icon = "schedule",
                    Card1Title = "Agendamentos Futuros",
                    Card1Value = _homeService.GetClientPendingServiceScheduleCount(clientId).ToString(),
                    Card2Icon = "star",
                    Card2Title = "Avaliações Pendentes",
                    Card2Value = _homeService.GetClientPendingAvaliationCount(clientId).ToString(),
                    Card3Icon = "loyalty",
                    Card3Title = "Pataz",
                    Card3Value = _homeService.GetClientPataz(clientId).ToString(),
                    Card4Icon = "pets",
                    Card4Title = "Pets",
                    Card4Value = _homeService.GetClientPetCount(clientId).ToString()
                });
            }
            else
            {
                return View(new HomeViewModel()
                {
                    Card1Icon = "schedule",
                    Card1Title = "Agendamentos Futuros",
                    Card1Value = _homeService.GetPendingServiceScheduleCount().ToString(),
                    Card2Icon = "person",
                    Card2Title = "Clientes Cadastrados",
                    Card2Value = _homeService.GetClientCount().ToString(),
                    Card3Icon = "pets",
                    Card3Title = "Pets Cadastrados",
                    Card3Value = _homeService.GetPetCount().ToString(),
                    Card4Icon = "monetization_on",
                    Card4Title = "Pedidos Finalizados",
                    Card4Value = _homeService.GetOrderCount().ToString()
                });
            }
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}