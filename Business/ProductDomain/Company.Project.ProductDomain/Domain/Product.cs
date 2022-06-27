using Company.Project.Core.Domain.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Company.Project.ProductDomain.Domain
{
    public class Product : DomainBase
    {
        public string UserId { get; set; }
        //public int EventId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        [DisplayFormat(DataFormatString = "{0:HH:MM}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [Required]
        //public EventType Type { get; set; }
        public string Type { get; set; }

        [Range(0, 4, ErrorMessage = "Can't exceed 4 hours")]
        [Display(Name = "Duration in hours")]
        public int Duration { get; set; }

        [MaxLength(50, ErrorMessage = "Can't exceed 50 chars")]
        public string Description { get; set; }

        [MaxLength(500, ErrorMessage = "Can't exceed 500 chars")]
        [Display(Name = "Other Details")]
        public string OtherDetails { get; set; }

        [Display(Name = "Invite Others")]
        public string InviteByEmail { get; set; }

        //public Comments Comment { get; set; }
        public IList<Comments> Comments { get; set; }
        protected override IEnumerable<ValidationResult> OnValidateWhileCreate()
        {
            //Implement custom rule
            return null;
        }
    }
}
