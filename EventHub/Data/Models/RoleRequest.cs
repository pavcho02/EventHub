using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class RoleRequest
    {
        [Key]
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Description cannot be longer than 200 characters.")]
        public string Description { get; set; }
    }
}