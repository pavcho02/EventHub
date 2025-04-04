using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class EventReport
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public string EventId { get; set; }
        public virtual Event Event { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Description cannot be longer than 200 characters.")]
        public string Description { get; set; }
    }
}
