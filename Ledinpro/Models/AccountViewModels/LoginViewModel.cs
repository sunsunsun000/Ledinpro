using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ledinpro.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "请输入邮箱！")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "请输入密码！")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "记住我？")]
        public bool RememberMe { get; set; }
    }
}
