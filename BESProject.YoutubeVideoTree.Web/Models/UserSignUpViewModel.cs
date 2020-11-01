using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BESProject.YoutubeVideoTree.Web.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        public string UserName { get; set; }

        [Display(Name = "Adı")]
        [Required(ErrorMessage = "Ad boş geçilemez")]
        public string Name { get; set; }

        [Display(Name = "Soyadı")]
        [Required(ErrorMessage = "Soyadı boş geçilemez")]
        public string Surname { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Geçerli bir email adresi girin")]
        [Required(ErrorMessage = "Email boş geçilemez")]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre boş geçilemez")]
        public string Password { get; set; }
    }
}
