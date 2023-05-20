using System.ComponentModel.DataAnnotations;

namespace CodifinAPI.Models
{
    public class UserRequest
    {
        [Required]
        public  string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
