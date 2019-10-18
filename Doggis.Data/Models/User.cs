using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Models
{
    public class User
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Enums.User.UserType Type { get; set; }
        public string Identification { get; set; }
        public string NationalInsuranceNumber { get; set; }
        public string CouncilNumber { get; set; }
        public TimeSpan? EntryTime { get; set; }
        public TimeSpan? DepartureTime { get; set; }
        public bool Status { get; set; }
        public Enums.Pet.Specie? VeterinaryAllowedSpecies { get; set; }

        public virtual ICollection<ServicePriceHistory> ServicesPriceHistoryCreatedBy { get; set; }
        public virtual ICollection<ServicePriceHistory> ServicesPriceHistoryDisabledBy { get; set; }
        public virtual ICollection<ServiceSchedule> ServiceSchedulesResponsibleFor { get; set; }

        public User()
        {
            ServicesPriceHistoryCreatedBy = new List<ServicePriceHistory>();
            ServicesPriceHistoryDisabledBy = new List<ServicePriceHistory>();
            ServiceSchedulesResponsibleFor = new List<ServiceSchedule>();
        }
    }
}
