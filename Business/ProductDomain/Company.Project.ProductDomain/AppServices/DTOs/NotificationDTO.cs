using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.ProductDomain.AppServices.DTOs
{
    public class NotificationDTO
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public DateTime Date { get; set; }
    }
}
