using System;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    public class Carousel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "请输入名称！")]
        [MaxLength(64)]
        [Display(Name = "名称")]
        public string Name
        {
            get;
            set;
        }

        [Display(Name = "标题")]
        public string Title
        {
            get;
            set;
        }

        [Display(Name = "描述")]
        public string Description
        {
            get;
            set;
        }

        [Required(ErrorMessage = "请添加轮播图片！")]
        [Display(Name = "图片")]
        public string PicturePath
        {
            get;
            set;
        }

        [Display(Name = "手机版图片")]
        public string MobilePicturePath
        {
            get;
            set;
        }

        [Display(Name = "排序编号")]
        public string SortNumber
        {
            get;
            set;
        }

        [Display(Name = "关联产品")]
        public int RelativeProductId
        {
            get;
            set;
        }
    }
}
