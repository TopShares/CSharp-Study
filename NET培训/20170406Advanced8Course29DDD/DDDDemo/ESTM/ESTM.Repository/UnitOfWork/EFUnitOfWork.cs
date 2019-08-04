using ESTM.Domain;
using ESTM.Infrastructure.MEF;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTM.Repository
{
    /// <summary>
    /// 工作单实现类
    /// </summary>
    [Export(typeof(IEFUnitOfWork))]
    public class EFUnitOfWork : IEFUnitOfWork
    {
        #region 属性
        //通过工作单元向外暴露的EF上下文对象
        public DbContext context { get { return EFContext; } }

        [Import(typeof(DbContext))]
        public DbContext EFContext { get; set; } 
        #endregion

        #region 构造函数
        public EFUnitOfWork()
        { 
            //注册MEF
            Regisgter.regisgter().ComposeParts(this);
        }
        #endregion

        #region IUnitOfWorkRepositoryContext接口
        public void RegisterNew<TEntity>(TEntity obj) where TEntity : AggregateRoot
        {
            var state = context.Entry(obj).State;
            if (state == EntityState.Detached)
            {
                context.Entry(obj).State = EntityState.Added;
            }
            IsCommitted = false;
        }

        public void RegisterModified<TEntity>(TEntity obj) where TEntity : AggregateRoot
        {
            if (context.Entry(obj).State == EntityState.Detached)
            {
                context.Set<TEntity>().Attach(obj);
            }
            context.Entry(obj).State = EntityState.Modified;
            IsCommitted = false;
        }

        public void RegisterDeleted<TEntity>(TEntity obj) where TEntity : AggregateRoot
        {
            context.Entry(obj).State = EntityState.Deleted;
            IsCommitted = false;
        } 
        #endregion

        #region IUnitOfWork接口

        public bool IsCommitted { get; set; }

        public int Commit()
        {
            if (IsCommitted)
            {
                return 0;
            }
            try
            {
                int result = context.SaveChanges();
                IsCommitted = true;
                return result;
            }
            catch (DbUpdateException e)
            {

                throw e;
            }
        }

        public void Rollback()
        {
            IsCommitted = false;
        } 
        #endregion

        #region IDisposable接口
        public void Dispose()
        {
            if (!IsCommitted)
            {
                Commit();
            }
            context.Dispose();
        } 
        #endregion
    }
}
