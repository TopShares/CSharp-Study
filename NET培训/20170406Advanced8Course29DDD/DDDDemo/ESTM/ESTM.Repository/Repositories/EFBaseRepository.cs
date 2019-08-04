using ESTM.Domain;
using ESTM.Infrastructure.MEF;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ESTM.Repository
{
    //仓储的泛型实现类
    public class EFBaseRepository<TEntity> : IRepository<TEntity> where TEntity : AggregateRoot
    {
        [Import(typeof(IEFUnitOfWork))]
        public IEFUnitOfWork UnitOfWork { get; set; }

        public EFBaseRepository()
        {
            Regisgter.regisgter().ComposeParts(this);
        }

        public virtual IQueryable<TEntity> Entities
        {
            get { return UnitOfWork.context.Set<TEntity>(); }
        }

        public virtual TEntity GetByKey(object key)
        {
            return UnitOfWork.context.Set<TEntity>().Find(key);
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> express)
        {
            Func<TEntity, bool> lamada = express.Compile();
            return UnitOfWork.context.Set<TEntity>().Where(lamada).AsQueryable<TEntity>();
        }

        public virtual int Insert(TEntity entity)
        {
            UnitOfWork.RegisterNew(entity);
            return UnitOfWork.Commit();
        }

        public virtual int Insert(IEnumerable<TEntity> entities)
        {
            foreach (var obj in entities)
            {
                UnitOfWork.RegisterNew(obj);
            }
            return UnitOfWork.Commit();
        }

        public virtual int Delete(object id)
        {
            var obj = UnitOfWork.context.Set<TEntity>().Find(id);
            if (obj == null)
            {
                return 0;
            }
            UnitOfWork.RegisterDeleted(obj);
            return UnitOfWork.Commit();
        }

        public virtual int Delete(TEntity entity)
        {
            UnitOfWork.RegisterDeleted(entity);
            return UnitOfWork.Commit();
        }

        public virtual int Delete(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                UnitOfWork.RegisterDeleted(entity);
            }
            return UnitOfWork.Commit();
        }

        public virtual int Delete(Expression<Func<TEntity, bool>> express)
        {
            Func<TEntity, bool> lamada = express.Compile();
            var lstEntity = UnitOfWork.context.Set<TEntity>().Where(lamada);
            foreach (var entity in lstEntity)
            {
                UnitOfWork.RegisterDeleted(entity);
            }
            return UnitOfWork.Commit();
        }

        public virtual int Update(TEntity entity)
        {
            UnitOfWork.RegisterModified(entity);
            return UnitOfWork.Commit();
        }


    }
}
