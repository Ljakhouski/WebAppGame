using System.ComponentModel.DataAnnotations;

namespace FormApp.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
