using Data.Enums;
using Data.Models;
using System.ComponentModel.DataAnnotations;

namespace EventHub.Models.InputModels
{
    public class EventInputModel
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public TargetAudience TargetAudience { get; set; }

        [Required]
        public EventType EventType { get; set; }
    }
}
