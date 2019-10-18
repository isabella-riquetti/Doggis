using Enums.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public static SelectList EnumSelectList<TEnum>(bool indexed = false) where TEnum : struct
        {
            return new SelectList(System.Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Select(item => new SelectListItem
            {
                Text = EnumHelper.GetDescription(item as System.Enum),
                Value = indexed ? Convert.ToInt32(item).ToString() : item.ToString()
            })
            .OrderBy(f => f.Text)
            .ToList(), "Value", "Text");
        }
    }
}