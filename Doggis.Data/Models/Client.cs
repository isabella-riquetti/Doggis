using Doggis.Data.Enum;
using System;
using System.Collections.Generic;

namespace Doggis.Data.Models
{
    public class Client
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Identification { get; set; }
        public string NationalInsuranceNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pataz { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
        public virtual ICollection<ServiceSchedule> ServiceSchedules { get; set; }
        public virtual ICollection<UserAvaliation> Avaliations { get; set; }

        public Client()
        {
            ServiceSchedules = new List<ServiceSchedule>();
            Avaliations = new List<UserAvaliation>();
            Pets = new List<Pet>();
        }
    }
}
