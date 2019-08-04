using Ruanmou.Bussiness.Interface;
using Ruanmou.EF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.Bussiness.Service
{
    public abstract class BaseService : IBaseService
    {
        private DbContext _DBContext { get; set; }
        public BaseService(DbContext jdContext)
        {
            this._DBContext = jdContext;
        }


        public T Find<T>(int id) where T : class
        {
            T t = this._DBContext.Set<T>().Find(id);
            return t;
        }

        public void Add<T>(T t) where T : class
        { }

        public void Update<T>(T t) where T : class
        { }

        public void Delete<T>(T t) where T : class
        { }

        public void List<T>(T t) where T : class
        { }



        public void Dispose()
        {
            this._DBContext.Dispose();
        }
    }
}
