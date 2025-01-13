using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    internal class User : IdentityUser
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            CreatedEvents = new HashSet<Event>();
            EventsToAttend = new HashSet<Participation>();
            Reviews = new HashSet<EventReview>();
            Reports = new HashSet<EventReport>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [PersonalData]
        public string FirstName { get; set; }

        [Required]
        [PersonalData]
        public string LastName { get; set; }

        [PersonalData]
        public string PhoneNumber { get; set; }

        [Required]
        [PersonalData]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [PersonalData]
        public string Email { get; set; }

        public virtual ICollection<Event> CreatedEvents { get; set; }

        public virtual ICollection<Participation> EventsToAttend { get; set; }

        public virtual ICollection<EventReview> Reviews { get; set; }

        public virtual ICollection<EventReport> Reports { get; set; }
    }
}
