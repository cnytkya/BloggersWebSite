using System.ComponentModel.DataAnnotations;

namespace BloggersWebSite.Models
{
    public class UserSignViewModel
    {
        [Required(ErrorMessage ="Kullanıcı Adı Boş Geçilemez")]
        public string username{ get; set; } 
        [Required(ErrorMessage ="Şifre Boş Geçilemez")]
        public string password{ get; set; }
    }
}
