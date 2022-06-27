using Company.Project.Core.AppServices;
using Company.Project.Core.Domain.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Company.Project.ProductDomain.Domain
{
    public class Comments: DomainBase
    {
        public string CommentAdded { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        

        [ForeignKey("Product")]
        public int EventId { get; set; } public Product Product { get; set; }

        protected override IEnumerable<ValidationResult> OnValidateWhileCreate()
        {
            //Implement custom rule
            return null;
        }
    }
}
