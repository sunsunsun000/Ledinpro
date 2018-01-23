using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ledinpro.Data;
using Ledinpro.Models;
using Ledinpro.Domain.IRepositories;

namespace Ledinpro.Repositories
{
    /// <summary>
    /// 用户管理仓储实现
    /// </summary>
    public class UserRepository : IUserRepository
    {
        public ApplicationUser CheckUser(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
