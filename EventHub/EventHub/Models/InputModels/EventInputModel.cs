using Data.Enums;
using Data.Models;
using System.ComponentModel.DataAnnotations;

namespace EventHub.Models.InputModels
{
    public class EventInputModel
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Start time")]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Target Audience")]
        public TargetAudience TargetAudience { get; set; }

        [Required]
        [Display(Name = "Event Type")]
        public EventType EventType { get; set; }

        public EventInputModel(string title, string description, DateTime startTime,
                    string location, TargetAudience targetAudience, EventType eventType)
        {
            Title = title;
            Description = description;
            StartTime = startTime;
            Location = location;
            TargetAudience = targetAudience;
            EventType = eventType;
        }

        public EventInputModel()
        {
            
        }
    }
}
