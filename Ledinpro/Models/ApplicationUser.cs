using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Ledinpro.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    // 可以在这个类里面增加自定义的用户属性
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Gender { get; set; }
    }
}
