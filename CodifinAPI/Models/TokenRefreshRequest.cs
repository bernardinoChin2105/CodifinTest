using System.ComponentModel.DataAnnotations;

namespace CodifinAPI.Models
{
    public class TokenRefreshRequest
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string RefreshToken { get; set; }
    }
}
