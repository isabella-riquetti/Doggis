using Doggis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doggis.Services
{
    public interface ILoginService
    {
        SystemUser GetUser(string userName, string password);
    }
}