using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    public class ApplicationScene
    {
        public int ID { get; set; }

        [Display(Name = "场景名称")]
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Display(Name = "场景描述")]
        [Required]
        [StringLength(256)]
        public string Description { get; set; }

        [Display(Name = "电脑场景图片")]
        public string PicturePath { get; set; }

        [Display(Name = "手机场景图片")]
        public string MobilePicturePath { get; set; }
    }
}
