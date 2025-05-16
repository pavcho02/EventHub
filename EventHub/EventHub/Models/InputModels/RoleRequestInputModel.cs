using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace EventHub.Models.InputModels
{
    public class RoleRequestInputModel
    {
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
