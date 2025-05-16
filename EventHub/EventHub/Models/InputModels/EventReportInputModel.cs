using System.ComponentModel.DataAnnotations;

namespace EventHub.Models.InputModels
{
    public class EventReportInputModel
    {
        [Required]
        public string EventId { get; set; }

        [Required]
        [Display(Name = "Decsription")]
        [StringLength(maximumLength: 200, ErrorMessage = "Description cannot be longer than 200 characters.")]
        public string Description { get; set; }
    }
}
