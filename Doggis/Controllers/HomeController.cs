﻿using Doggis.Models;
using Doggis.Services;
using Doggis.Services;
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

        public HomeController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public ActionResult Index()
        {
            if(Helpers.CurrentUserHasPermission("IsClient"))
            {

            }
            else
            {

            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}