using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.Framework.Caching
{
    public class HashtableCache:ICache
    {
        private static IEnumerable<KeyValuePair<string, object>> HTCache = new List<KeyValuePair<string, object>>();

        public T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public void Add(string key, object data, int cacheTime = 30)
        {
            throw new NotImplementedException();
        }

        public bool Contains(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public object this[string key]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }
    }
}
