using Company.Project.Core.WebMVC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Models
{
    public class EventViewModel : ViewModel
    {
        [Required(ErrorMessage = "Title of book is required")]
        [DisplayName("Enter title of the book")]
        public string TitleOfBook { get; set; }

        
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please select a date for event")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please enter location of your event")]
        public string Location { get; set; }

        [Required(ErrorMessage = "When event is going to start?")]
        [DataType(DataType.Time)]
        [DisplayName("Start Time")]
        public TimeSpan StartTime { get; set; }

        [DisplayName("Tick this if you want your event to be private")]
        public bool Type { get; set; } //true => private, false => public

        [Range(1,4, ErrorMessage = "Duration of event must be between 1 hour to 4 hours")]
        [DisplayName("Duration of event in hours")]
        public int DurationInHours { get; set; }

        [MaxLength(50, ErrorMessage = "Description cannot exceed 50 characters")]
        public string Description { get; set; }

        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        [DisplayName("Other Details")]
        public string OtherDetails { get; set; }

        public string UserID { get; set; }

        public virtual ICollection<CommentViewModel> Comments { get; set; }

        //[Required(ErrorMessage = "Enter comma separated valid email ids")]
        [DisplayName("Invite people by entering comma separated email ids")]
        public string InviteByEmail { get; set; }

    }
}
