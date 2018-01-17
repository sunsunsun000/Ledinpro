using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    public class ProductScene
    {
        public int Id
        {
            get;
            set;
        }

        [Required(ErrorMessage = "请输入场景名称！")]
        [MaxLength(255)]
        [Display(Name = "名称")]
        public string Name
        {
            get;
            set;
        }

        [Required(ErrorMessage = "请输入场景描述！")]
        [MaxLength(500)]
        [Display(Name = "描述")]
        public string Description
        {
            get;
            set;
        }

        [Display(Name = "场景图片")]
        public string PicturePath
        {
            get;
            set;
        }

        [Display(Name = "手机版场景图片")]
        public string MobilePicturePath
        {
            get;
            set;
        }

        // 场景类型
        public string SceneType
        {
            get;
            set;
        }

        // 场景包含的产品
        public ICollection<Product> Products
        {
            get;
            set;
        }
    }
}
