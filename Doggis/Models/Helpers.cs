using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doggis.Models
{
    public static class Helpers
    {
        public static bool CurrentUserHasPermission(string code)
        {
            var claimsIdentity = System.Web.HttpContext.Current.User.Identity as System.Security.Claims.ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var hasPermission = claimsIdentity.Claims
                    .Any(x => x.Type == System.Security.Claims.ClaimTypes.Role && x.Value == code);

                return hasPermission;
            }

            return false;
        }

        public static string GetLoggedUserName()
        {
            var claimsIdentity = System.Web.HttpContext.Current.User.Identity as System.Security.Claims.ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var claim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.Name);

                if(claim != null)
                    return claim.Value;
            }

            return "Não Identificado";
        }

        public static string GetUserExtraData()
        {
            var claimsIdentity = System.Web.HttpContext.Current.User.Identity as System.Security.Claims.ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var claim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.UserData);

                if (claim != null)
                    return claim.Value;
            }

            return "Não Identificado";
        }

        public static Guid GetLoggedUserId()
        {
            var claimsIdentity = System.Web.HttpContext.Current.User.Identity as System.Security.Claims.ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var claim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier);

                if (claim != null)
                    return new Guid(claim.Value);
            }

            return Guid.NewGuid();
        }

        public static DateTime Brasilia(this DateTime data)
        {
            var utc = DateTime.UtcNow;
            var brasiliaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            var dateTimeNowBrasilia = TimeZoneInfo.ConvertTimeFromUtc(utc, brasiliaTimeZone);

            return dateTimeNowBrasilia;
        }
    }
}