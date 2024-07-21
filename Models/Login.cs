using System.ComponentModel.DataAnnotations;

namespace Heysundue.Models
{
    public class Login
    {
        [Required(ErrorMessage = "請輸入使用者名稱")]
        public string Username { get; set; }

        [Required(ErrorMessage = "請輸入密碼")]
        public string Password { get; set; }
    }
}
