using System;
using System.ComponentModel.DataAnnotations;

namespace QBO_Events_Management.Models
{
	
	public class Event
	{
		public int eventID { get; set; }

        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Invalid Name")]
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Time)]
        [Required]
        public TimeSpan StartTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime EndDate { get; set; }

        [DataType(DataType.Time)]
        [Required]
        public TimeSpan EndTime { get; set; }

        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Invalid Venue")]
        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public String Venue { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Details { get; set; }

        [Display(Name = "Is Published?")]
        public bool IsPublished { get; set; }

        [Display(Name = "Is Cancelled?")]
        public bool IsCancelled { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date Added")]
        [Required]
        public DateTime DateAdded { get; set; }

    }
}