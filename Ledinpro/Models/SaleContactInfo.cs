using System;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    public class SaleContactInfo
    {
        public int Id
        {
            get;
            set;
        }

        [Required(ErrorMessage = "请输入名字！")]
        [MaxLength(64)]
        [Display(Name = "名字")]
        public string Name
        {
            get;
            set;
        }

        [MaxLength(64)]
        [Display(Name = "昵称")]
        public string NickName
        {
            get;
            set;
        }

        [Required(ErrorMessage = "请输入电话！")]
        [MaxLength(64)]
        [Display(Name = "电话")]
        public string Phone
        {
            get;
            set;
        }

        [Required(ErrorMessage = "请输入邮箱！")]
        [MaxLength(64)]
        [Display(Name = "邮箱")]
        public string Email
        {
            get;
            set;
        }

        [Required(ErrorMessage = "请输入Skype！")]
        [MaxLength(64)]
        [Display(Name = "Skype")]
        public string Skype
        {
            get;
            set;
        }

        [Display(Name = "图片")]
        public string PicturePath
        {
            get;
            set;
        }

        [Display(Name = "是否显示")]
        public bool IsShow
        {
            get;
            set;
        }

        public string EditPerson
        {
            get;
            set;
        }

        public DateTime? EditTime
        {
            get;
            set;
        }
    }
}
