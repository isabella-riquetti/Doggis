using Doggis.Data.UnitOfWork;
using Doggis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doggis.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Forçado para facilitar utilização
        //Ignorando senha
        public SystemUser GetUser(string userName, string password)
        {
            if (userName == "administrador")
            {
                var admin = _unitOfWork.User.FirstOrDefault(u => u.Type == Enums.User.UserType.Admin && u.Status);
                return new SystemUser()
                {
                    ID = admin.ID,
                    Type = Models.Type.User,
                    User = admin,
                    Authenticated = true
                };
            }
            else if (userName == "atendente")
            {
                var attendant = _unitOfWork.User.FirstOrDefault(u => u.Type == Enums.User.UserType.Attendant && u.Status);
                return new SystemUser()
                {
                    ID = attendant.ID,
                    Type = Models.Type.User,
                    User = attendant,
                    Authenticated = true
                };
            }
            else
            {
                var client = _unitOfWork.Client.FirstOrDefault(c => c.Status && c.Email == userName);
                return new SystemUser()
                {
                    ID = client.ID,
                    Type = Models.Type.Client,
                    Client = client,
                    Authenticated = true
                };
            }
        }
    }
}