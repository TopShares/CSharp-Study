using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.Bussiness.Interface
{
    public interface IBaseService : IDisposable
    {
        T Find<T>(int id) where T : class;
        void Add<T>(T t) where T : class;
        void Update<T>(T t) where T : class;
        void Delete<T>(T t) where T : class;
        void List<T>(T t) where T : class;
    }
}
