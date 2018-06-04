using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ledinpro.Domain.IRepositories;
using Ledinpro.Data;
using Ledinpro.Models;
using Microsoft.EntityFrameworkCore;

namespace Ledinpro.Repositories
{
    public abstract class LedinproRepositoryBase<TEntity, TPrimaryKey, TContext> : IRepository<TEntity, TPrimaryKey>
        where TEntity : BaseEntity<TPrimaryKey>
        where TContext : DbContext
    {
        /// <summary>
        /// 用户数据管理上下文
        /// </summary>
        protected readonly TContext _dbContext;

        /// <summary>
        /// 通过构造函数注入得到上下文实例
        /// </summary>
        /// <param name="dbContext">上下文实例</param>
        public LedinproRepositoryBase(TContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <returns></returns>
        public List<TEntity> GetAllList()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        /// <summary>
        /// 获取满足条件的实体集合
        /// </summary>
        /// <param name="predicate">lambda表达式</param>
        /// <returns></returns>
        public List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).ToList();
        }

        public TEntity Get(TPrimaryKey id)
        {
            return FirstOrDefault(CreateEqualityExpressionForId(id));
        }

        /// <summary>
        /// 根据lambda获取单个实体
        /// </summary>
        /// <param name="predicate">lambda表达式</param>
        /// <returns></returns>
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().FirstOrDefault(predicate);
        }

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public TEntity Insert(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return entity;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public TEntity Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        /// <summary>
        /// 新增或更新实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public TEntity InsertOrUpdate(TEntity entity)
        {
            if (Get(entity.Id) != null)
            {
                return Update(entity);
            }

            return Insert(entity);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">要删除的实体</param>
        /// <returns></returns>
        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">要删除的实体的Id</param>
        /// <returns></returns>
        public void Delete(TPrimaryKey id)
        {
            _dbContext.Set<TEntity>().Remove(Get(id));
        }

        /// <summary>
        /// 事务性保存
        /// </summary>
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 根据主键构造lambda表达式
        /// </summary>
        /// <param name="id">lambda表达式</param>
        /// <returns></returns>
        public static Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));
            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"), 
                Expression.Constant(id, typeof(TPrimaryKey)));

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }
    }

    /// <summary>
    /// 主键类型为Guid的仓储基类
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public abstract class LedinproRepositoryBase<TEntity, TContext> : LedinproRepositoryBase<TEntity, int, TContext>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        public LedinproRepositoryBase(TContext context) : base(context)
        {
        }
    }
}
