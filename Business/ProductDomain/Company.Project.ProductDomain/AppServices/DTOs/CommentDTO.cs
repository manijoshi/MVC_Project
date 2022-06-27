using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Company.Project.ProductDomain.AppServices.DTOs
{
    public class CommentDTO
    {
        
        public int EventId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        public string CommentAdded { get; set; }
        public string UserId { get; set; }

    }
}
