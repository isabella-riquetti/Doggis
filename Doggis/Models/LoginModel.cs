using Doggis.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doggis.Models
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [HiddenInput]
        public string ReturnUrl { get; set; }
    }

    public class SystemUser
    {
        public Guid ID { get; set; }
        public Type Type { get; set; }
        public User User { get; set; }
        public Client Client { get; set; }
        public bool Authenticated { get; internal set; }
    }

    public enum Type
    {
        User = 0,
        Client = 1
    }
}