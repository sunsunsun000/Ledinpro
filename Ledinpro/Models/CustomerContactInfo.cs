using System;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    /// <summary>
    /// 客户留言
    /// </summary>
    public class CustomerContactInfo : BaseEntity
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "Please input name!")]
        [Display(Name = "姓名")]
        [StringLength(32)]
        public string Name { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Required(ErrorMessage = "Please input Email!")]
        [Display(Name = "邮箱")]
        [EmailAddress(ErrorMessage = "Please input a valid e-mail address!")]
        [StringLength(32)]
        public string Email { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        [Required(ErrorMessage = "Please input Message!")]
        [Display(Name = "信息")]
        public string Message { get; set; }

        /// <summary>
        /// 自由项
        /// </summary>
        [Display(Name = "自由项")]
        public string Free { get; set; }
    }
}