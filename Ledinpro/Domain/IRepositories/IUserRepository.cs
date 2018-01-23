using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ledinpro.Models;

namespace Ledinpro.Domain.IRepositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// 检测用户是否存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        ApplicationUser CheckUser(string userName, string password);
    }
}
