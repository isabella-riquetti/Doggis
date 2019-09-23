using Doggis.Services;
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

        [HttpGet]
        public JsonResult UpdateStatus(Guid id, bool status)
        {
            var result = _veterinaryService.DisableVet(id, status);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}