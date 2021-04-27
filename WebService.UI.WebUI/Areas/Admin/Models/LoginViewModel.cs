using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.UI.WebUI.Areas.Admin.Models
{
    public class LoginViewModel
    {
        [Display(Name ="UserName")]
        [MaxLength(100,ErrorMessage ="Max UserName 100 Characters")]
        [MinLength(2,ErrorMessage ="Min Username 2 characters")]
        [Required(ErrorMessage ="UserName Required")]
        [UIHint("UserName")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [MaxLength(50, ErrorMessage = "Max Password 50 Characters")]
        [MinLength(2, ErrorMessage = "Min Password 2 characters")]
        [Required(ErrorMessage = "Password Required")]
        [UIHint("Password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
