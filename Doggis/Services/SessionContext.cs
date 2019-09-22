using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doggis.Services
{

    public static class SessionContext
    {
        public static bool IsAdmin
        {
            get
            {
                return (bool)HttpContext.Current.Session["IsAdmin"];
            }
            set
            {
                HttpContext.Current.Session["IsAdmin"] = value;
            }
        }
        public static bool IsAttendant
        {
            get
            {
                return (bool)HttpContext.Current.Session["IsAttendant"];
            }
            set
            {
                HttpContext.Current.Session["IsAttendant"] = value;
            }
        }
        public static bool IsClient
        {
            get
            {
                return (bool)HttpContext.Current.Session["IsClient"];
            }
            set
            {
                HttpContext.Current.Session["IsClient"] = value;
            }
        }
    }
}