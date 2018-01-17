using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    public class Menu
    {
        public int ID { get; set; }

        [Display(Name = "标题")]
        [Required(ErrorMessage = "请输入标题！")]
        public string Title 
        { 
            get; 
            set; 
        }

        [Display(Name = "菜单链接")]
        [Required(ErrorMessage = "请输入链接!")]
        public string Link 
        { 
            get; set;
        }
    }
}
