using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            CreatedEvents = new HashSet<Event>();
            EventsToAttend = new HashSet<Participation>();
            Reviews = new HashSet<EventReview>();
            Reports = new HashSet<EventReport>();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateOnly DateOfBirth { get; set; }

        public virtual RoleRequest RoleRequest { get; set; }

        public virtual ICollection<Event> CreatedEvents { get; set; }

        public virtual ICollection<Participation> EventsToAttend { get; set; }

        public virtual ICollection<EventReview> Reviews { get; set; }

        public virtual ICollection<EventReport> Reports { get; set; }
    }
}
