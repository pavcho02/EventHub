using Data.Enums;
using Data.Models;
using System.ComponentModel.DataAnnotations;

namespace EventHub.Models.InputModels
{
    public class EventUpdateModel
    {
        [Required]
        public string Id { get; set; }

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

        public EventUpdateModel(string id, string title, string description, DateTime startTime,
                    string location, TargetAudience targetAudience, EventType eventType)
        {
            Id = id;
            Title = title;
            Description = description;
            StartTime = startTime;
            Location = location;
            TargetAudience = targetAudience;
            EventType = eventType;
        }

        public EventUpdateModel()
        {
            
        }
    }
}
