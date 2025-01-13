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

        [PersonalData]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [PersonalData]
        public string Email { get; set; }

        public virtual ICollection<Event> CreatedEvents { get; set; }

        public virtual ICollection<Event> EventsToAttend { get; set; }

    }
}
