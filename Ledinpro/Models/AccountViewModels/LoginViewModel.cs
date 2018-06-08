using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ledinpro.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please input email！")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please input password！")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me？")]
        public bool RememberMe { get; set; }
    }
}
