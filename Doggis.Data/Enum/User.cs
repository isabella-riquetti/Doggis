using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Enum
{
    public class User
    {
        public enum UserType
        {
            [Description("Administrador")]
            Admin = 0,
            [Description("Atendente")]
            Attendant = 1,
            [Description("Veterinário")]
            Vet = 2
        }
    }
}