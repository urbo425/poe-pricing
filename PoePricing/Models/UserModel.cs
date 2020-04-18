using System.ComponentModel.DataAnnotations;

namespace PoePricing.Models
{
    public class UserModel
    {
        [Required]
        public string PoeSessionId { get; set; }
    }
}