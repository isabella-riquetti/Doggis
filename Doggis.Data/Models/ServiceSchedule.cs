using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Models
{
    public class ServiceSchedule
    {
        public Guid ID { get; set; }
        public Guid ServiceID { get; set; }
        public DateTime Schedule { get; set; }
        public Guid ClientID { get; set; }
        public Guid PetID { get; set; }
        public Guid ResponsibleID { get; set; }
        public bool Finished { get; set; }

        public virtual Service Service { get; set; }
        public virtual Client Client { get; set; }
        public virtual Pet Pet { get; set; }
        public virtual User Responsible { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<UserAvaliation> Avaliations { get; set; }

        public ServiceSchedule()
        {
            OrderItems = new List<OrderItem>();
            Avaliations = new List<UserAvaliation>();
        }
    }
}
