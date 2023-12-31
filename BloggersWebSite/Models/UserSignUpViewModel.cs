using System.ComponentModel.DataAnnotations;

namespace BloggersWebSite.Models
{
    public class UserSignUpViewModel
    {
        [Required(ErrorMessage = "Ad Sotyad Zorunlu Alan")]
        [Display(Name = "Ad Soyad")]
        public string NameSurname{ get; set; }

        [Required(ErrorMessage = "Şifre Zorunlu Alan")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrar"), Compare( "Password" ,ErrorMessage = "Şifreler Eşleşmiyor!")]
        public string PasswordConfirm { get; set; }

        [Display(Name = "Mail Adresi"), Required(ErrorMessage = "Mail Adresi Zorunlu Alan")]
        public string Mail { get; set; }
        
        [Display(Name = "Kullanıcı Adı"), Required(ErrorMessage = "Kullanıcı Adı Zorunlu Alan")]
        public string UserName { get; set; }
    }
}
