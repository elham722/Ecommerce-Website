using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShopCenter.MVC.Models
{
    public class CreateUserVM
    {
        [Required]
        [DisplayName("g")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
