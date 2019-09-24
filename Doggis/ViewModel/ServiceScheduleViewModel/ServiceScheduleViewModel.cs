using Doggis.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doggis.ViewModel
{
    public class ServiceScheduleViewModel
    {
        public Guid ID { get; set; }
        public string ServiceName { get; set; }
        public string PetName { get; set; }
        public DateTime Schedule { get; set; }
        public string ScheduleText { get; set; }
        public string ResponsibleName { get; set; }
        public int Score { get; set; }
        public bool Scored { get; internal set; }
        public string StatusText { get; internal set; }
    }
}