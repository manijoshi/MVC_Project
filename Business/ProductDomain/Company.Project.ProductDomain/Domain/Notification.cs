using Company.Project.Core.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.ProductDomain.Domain
{
    public class Notification : DomainBase
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public DateTime Date { get; set; }
    }
}
