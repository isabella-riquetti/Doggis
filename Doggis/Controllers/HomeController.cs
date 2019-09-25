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
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
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
                    Card1Title = "AGENDAMENTOS FUTUROS",
                    Card1Value = _homeService.GetClientPendingServiceScheduleCount(clientId).ToString(),
                    Card2Icon = "star",
                    Card2Title = "AVALIAÇÕES PENDENTES",
                    Card2Value = _homeService.GetClientPendingAvaliationCount(clientId).ToString(),
                    Card3Icon = "loyalty",
                    Card3Title = "PATAZ",
                    Card3Value = _homeService.GetClientPataz(clientId).ToString(),
                    Card4Icon = "pets",
                    Card4Title = "PETS",
                    Card4Value = _homeService.GetClientPetCount(clientId).ToString()
                });
            }
            else
            {
                var aux = new HomeViewModel()
                {
                    Card1Icon = "schedule",
                    Card1Title = "AGENDAMENTOS FUTUROS",
                    Card1Value = _homeService.GetPendingServiceScheduleCount().ToString(),
                    Card2Icon = "person",
                    Card2Title = "CLIENTES CADASTRADOS",
                    Card2Value = _homeService.GetClientCount().ToString(),
                    Card3Icon = "pets",
                    Card3Title = "PETS CADASTRADOS",
                    Card3Value = _homeService.GetPetCount().ToString(),
                    Card4Icon = "monetization_on",
                    Card4Title = "PEDIDOS FINALIZADOS",
                    Card4Value = _homeService.GetOrderCount().ToString()
                };

                return View(aux);
            }
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}