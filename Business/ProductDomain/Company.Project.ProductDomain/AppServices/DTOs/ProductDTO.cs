using Company.Project.Core.AppServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Company.Project.ProductDomain.AppServices.DTOs
{
    public class ProductDTO : DtoBase
    {
        public string UserId { get; set; }
        //public int EventId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date,ErrorMessage = "Please enter date of event")]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [DataType(DataType.Time,ErrorMessage = "Please enter start timing of event")]
        [Display(Name = "Start Time")]
        [DisplayFormat(DataFormatString = "{0:HH:MM}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [Required]
        public string Type { get; set; }

        [Range(0, 4)]
        [Display(Name = "Duration in hours")]
        public int Duration { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        [MaxLength(500)]
        [Display(Name = "Other Details")]
        public string OtherDetails { get; set; }

        [Display(Name = "Invite Others")]
        public string InviteByEmail { get; set; }

    }
}
