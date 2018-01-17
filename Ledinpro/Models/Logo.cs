using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ledinpro.Models
{
    public class Logo
    {
        public int ID 
        { 
            get; set; 
        }

        [Display(Name = "Logo类型")]
        public string LogoType 
        { 
            get; 
            set; 
        }

        [Display(Name = "Logo")]
        public string LogoPath 
        { 
            get; 
            set; 
        }

        [Display(Name = "是否使用")]
        public bool Active
        {
            get;
            set;
        }
    }
}
