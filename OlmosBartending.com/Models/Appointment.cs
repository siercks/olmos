using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OlmosBartending.com.Models
{


    public class Appointment
    {
        [Display(Name = "Booking Request")]
        [Required(ErrorMessage ="Field cannot be empty.")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int EventId { get; set; }
        [Display(Name = "Your Name")]
        [Required(ErrorMessage = "Bookings cannot be made without a name.")]
        public string? CustomerName { get; set; }
        [Display(Name = "Your Email")]
        public string? CustomerEmail { get; set; }
        [Display(Name = "Event Type")]
        [Required(ErrorMessage = "Bookings cannot be made without a requested service.")]
        public string? ServiceRequested { get; set; }
        [Display(Name = "Event Date")]
        [Required(ErrorMessage = "Bookings cannot be made without a date and time entered.")]
        public DateTime DateRequested { get; set; }
        [Display(Name = "Event Starts At:")]
        public TimeOnly TimeStart { get; set; }
        [Display(Name = "Event Ends At:")]
        [Required(ErrorMessage = "Bookings cannot be made without a requested end time.")]
        public TimeOnly TimeEnd { get; set; }
        [Display(Name = "Message (Optional)")]
        public string? OptionalMessage { get; set; }

    }
}