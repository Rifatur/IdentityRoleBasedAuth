using System.ComponentModel.DataAnnotations;

namespace RoleBaseAuth.Models.DTOs
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
