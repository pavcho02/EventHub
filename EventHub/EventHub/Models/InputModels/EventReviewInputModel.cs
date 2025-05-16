using System.ComponentModel.DataAnnotations;

namespace EventHub.Models.InputModels
{
    public class EventReviewInputModel
    {
        [Required]
        public string EventId { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10!")]
        [Display(Name = "Rating")]
        public int Rating { get; set; }

        [Required]
        [StringLength(maximumLength: 200, ErrorMessage = "Comment cannot be longer than 200 characters.")]
        [Display(Name = "Comment")]
        public string Comment { get; set; }
    }
}
