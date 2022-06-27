using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Models
{
    public class CommentViewModel
    {
        [Required(ErrorMessage = "Comment filed is empty..")]
        public string CommentAdded { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM:dd}",ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        
        public int EventId { get; set; }
        public int Id { get; set; }
        public string UserId { get; set; }
    }
}
