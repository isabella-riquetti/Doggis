using Doggis.Models;
using Doggis.Services;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Doggis.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        private readonly ILoginService _loginService;

        public AuthenticationController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var user = _loginService.GetUser(model.UserName, model.Password);

            var roleClaims = new List<Claim>() {
                new Claim(ClaimTypes.Role, "IsLogged"),
            };
            if (user.Client != null)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, "IsClient"));
                roleClaims.Add(new Claim(ClaimTypes.Name, user.Client.Name));
                roleClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Client.ID.ToString()));
                roleClaims.Add(new Claim(ClaimTypes.UserData, user.Client.Email));
            }
            else
            {
                if(user.User.Type == Data.Enum.User.UserType.Admin)
                {
                    roleClaims.Add(new Claim(ClaimTypes.Role, "IsAdmin"));
                    roleClaims.Add(new Claim(ClaimTypes.UserData, "Administrador"));
                }
                else
                {
                    roleClaims.Add(new Claim(ClaimTypes.Role, "IsAttendant"));
                    roleClaims.Add(new Claim(ClaimTypes.UserData, "Atendente"));
                }

                roleClaims.Add(new Claim(ClaimTypes.Name, user.User.Name));
                roleClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.User.ID.ToString()));
            }

            var identity = new ClaimsIdentity(roleClaims, "ApplicationCookie");
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignIn(identity);

            return RedirectToAction("Index", "Home");
        }

        public string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
                return Url.Action("Index", "Home");

            return returnUrl;
        }

        public ActionResult LogOff()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");

            return RedirectToAction("Login", "Authentication");
        }
    }
}