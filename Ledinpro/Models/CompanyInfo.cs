using System;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    public class CompanyInfo
    {
        public int Id
        {
            get;
            set;
        }

        [Required(ErrorMessage = "请输入公司名称！")]
        [MaxLength(500)]
        [Display(Name = "公司名称")]
        public string Name
        {
            get;
            set;
        }

        [Required(ErrorMessage = "请输入公司地址！")]
        [MaxLength(1000)]
        [Display(Name = "公司地址")]
        public string Address
        {
            get;
            set;
        }

        [Required(ErrorMessage = "请输入公司电话！")]
        [MaxLength(64)]
        [Display(Name = "公司电话")]
        public string Phone
        {
            get;
            set;
        }

        [Required(ErrorMessage = "请输入公司邮箱！")]
        [MaxLength(64)]
        [Display(Name = "公司邮箱")]
        public string Email
        {
            get;
            set;
        }

        [Required(ErrorMessage = "请输入公司介绍！")]
        [Display(Name = "公司简介")]
        public string Description
        {
            get;
            set;
        }

        [Display(Name = "背景图片")]
        public string BackgroundImage
        {
            get;
            set;
        }
    }
}
