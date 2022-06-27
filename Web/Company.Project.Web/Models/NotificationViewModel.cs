using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Models
{
    public class NotificationViewModel
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public DateTime Date { get; set; }
    }
}
