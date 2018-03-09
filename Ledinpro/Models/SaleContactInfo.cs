using System;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    /// <summary>
    /// 业务员联系信息
    /// </summary>
    public class SaleContactInfo : BaseEntity
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "请输入姓名！")]
        [MaxLength(64)]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [MaxLength(64)]
        [Display(Name = "昵称")]
        public string NickName { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [Required(ErrorMessage = "请输入电话！")]
        [MaxLength(64)]
        [Display(Name = "电话")]
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Required(ErrorMessage = "请输入邮箱！")]
        [MaxLength(64)]
        [Display(Name = "邮箱")]
        public string Email { get; set; }

        /// <summary>
        /// Skype
        /// </summary>
        [Required(ErrorMessage = "请输入Skype！")]
        [MaxLength(64)]
        [Display(Name = "Skype")]
        public string Skype { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        [Display(Name = "图片")]
        public string PicturePath { get; set; }

        /// <summary>
        /// 是否展示
        /// </summary>
        [Display(Name = "是否展示")]
        public bool IsShow { get; set; }
    }
}
