using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ledinpro.Models
{
    /// <summary>
    /// 泛型实体基类
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class BaseEntity<TPrimaryKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public TPrimaryKey Id { get; set; }

        /// <summary>
        /// 建立人
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDateTime { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public string LastEditUserName { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastEditDateTime { get; set; }
    }

    /// <summary>
    /// 定义默认主键类型为Guid的实体基类
    /// </summary>
    public abstract class BaseEntity : BaseEntity<Guid>
    {

    }
}
