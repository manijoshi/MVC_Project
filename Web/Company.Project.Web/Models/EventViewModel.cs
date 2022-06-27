
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Models
{
    public class EventViewModel
    {
        public string UserId { get; set; }
        public int Id { get; set; }
        //public int EventId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Please enter date of event")]

        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [DataType(DataType.Time, ErrorMessage = "Please enter start timing of event")]
        [Display(Name = "Start Time")]
        [DisplayFormat(DataFormatString ="{0:HH:MM}",ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [Required]
        //public EventType Type { get; set; }
        public string Type { get; set; }

        [Range(0,4,ErrorMessage = "Can't exceed 4 hours")]
        [Display(Name = "Duration in hours")]
        public int Duration { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        [MaxLength(500)]
        [Display(Name = "Other Details")]
        public string OtherDetails { get; set; }

        [Display(Name = "Invite Others")]
        public string InviteByEmail { get; set; }
        public string CommentAdded { get; set; }

    }
}
