using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 自定义实现的缓存
    /// 
    /// 非线程安全
    /// 过期清除
    /// </summary>
    public class CustomerCache : ICache
    {
        /// <summary>
        /// 过期问题
        /// </summary>
        private static Dictionary<string, KeyValuePair<object, DateTime>> _Dictionary = new Dictionary<string, KeyValuePair<object, DateTime>>();


        static CustomerCache()
        {
            new Action(() =>
            {
                while (true)
                {
                    Thread.Sleep(100);
                    foreach (var item in _Dictionary.Where(t => t.Value.Value < DateTime.Now))
                    {
                        _Dictionary.Remove(item.Key);
                    }
                }
            }).BeginInvoke(null, null);
        }


        public T Get<T>(string key)
        {
            if (_Dictionary.ContainsKey(key))//有没有key
            {
                KeyValuePair<object, DateTime> keyValue = _Dictionary[key];
                if (keyValue.Value > DateTime.Now)//有没有过期
                {
                    return (T)keyValue.Key;
                }
                else
                {
                    _Dictionary.Remove(key);//过期清除
                    return default(T);
                }
            }
            else
            {
                return default(T);
            }

        }

        /// <summary>
        /// KEY-VALUE-Time
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="cacheTime">分钟</param>
        public void Add(string key, object data, int cacheTime = 30 )
        {
            KeyValuePair<object, DateTime> keyValue = new KeyValuePair<object, DateTime>(data, DateTime.Now.AddMinutes(30));

            _Dictionary[key] = keyValue;
        }

        public bool Contains(string key)
        {
            if (_Dictionary.ContainsKey(key))//有没有key
            {
                KeyValuePair<object, DateTime> keyValue = _Dictionary[key];
                if (keyValue.Value > DateTime.Now)//有没有过期
                {
                    return true;
                }
                else
                {
                    _Dictionary.Remove(key);//过期清除
                    return false;
                }
            }
            else
                return false;
        }

        public void Remove(string key)
        {
            if (_Dictionary.ContainsKey(key))//有没有key
            {
                _Dictionary.Remove(key);
            }
        }

        public void RemoveAll()
        {
            _Dictionary = new Dictionary<string, KeyValuePair<object, DateTime>>();
        }

        public object this[string key]
        {
            get
            {
                return this.Get<object>(key);
            }
            set
            {
                this.Add(key, value);
            }
        }

        public int Count
        {
            get
            {
                return _Dictionary.Values.Count(t => t.Value > DateTime.Now);
            }
        }
    }
}
