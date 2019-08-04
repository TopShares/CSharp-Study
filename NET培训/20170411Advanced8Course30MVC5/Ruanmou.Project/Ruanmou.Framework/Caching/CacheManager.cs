using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ruanmou.Framework.Caching
{
    public class CacheManager
    {

        private CacheManager()
        { }

        private static ICache cache = null;

        static CacheManager()
        {
            //可以创建不同的cache对象
            cache = new MemoryCache();
            //cache = new HashtableCache();
        }
        public static T Get<T>(string key, Func<T> acquire)
        {
            return Get(key, 600, acquire);
        }

        public static T Get<T>(string key, int cacheTime, Func<T> acquire)
        {
            if (cache.Contains(key))
            {
                return cache.Get<T>(key);
            }
            else
            {
                var result = acquire();
                //if (result != null)
                cache.Add(key, result, cacheTime);
                return result;
            }
        }

        #region ICache
        /// <summary>
        /// 当前缓存数据项的个数
        /// </summary>
        public static int Count
        {
            get { return cache.Count; }
        }

        /// <summary>
        /// 如果缓存中已存在数据项键值，则返回true
        /// </summary>
        /// <param name="key">数据项键值</param>
        /// <returns>数据项是否存在</returns>
        public static bool Contains(string key)
        {
            return cache.Contains(key);
        }

        //public static object Get(string key)
        //{
        //    return cache.Get<T>(key);
        //}
        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetData<T>(string key)
        {
            return cache.Get<T>(key);
        }

        /// <summary>
        /// 添加缓存数据。
        /// 如果另一个相同键值的数据已经存在，原数据项将被删除，新数据项被添加。
        /// </summary>
        /// <param name="key">缓存数据的键值</param>
        /// <param name="value">缓存的数据，可以为null值</param>
        public static void Add(string key, object value)
        {
            cache.Add(key, value);
        }

        /// <summary>
        /// 添加缓存数据。
        /// 如果另一个相同键值的数据已经存在，原数据项将被删除，新数据项被添加。
        /// </summary>
        /// <param name="key">缓存数据的键值</param>
        /// <param name="value">缓存的数据，可以为null值</param>
        /// <param name="expiratTime">缓存过期时间间隔(单位：分钟)</param>
        public static void Add(string key, object value, int expiratTime = 600)
        {
            cache.Add(key, value, expiratTime);
        }

        ///// <summary>
        ///// 添加缓存数据。
        ///// </summary>
        ///// <param name="key">缓存数据的键值</param>
        ///// <param name="value">缓存的数据，可以为null值</param>
        ///// <param name="policy">数据过期策略(AbsoluteTime/ExtendedFormat/FileDependency/NeverExpired/SlidingTime)，可以为空</param>
        //public static void Add(string key, object value, ExpirationPolicy policy)
        //{
        //    cache.Add(key, value, CacheItemPriority.Normal, policy);
        //}

        ///// <summary>
        ///// 添加缓存数据。
        ///// 如果另一个相同键值的数据已经存在，原数据项将被删除，新数据项被添加。
        ///// </summary>
        ///// <param name="key">缓存数据的键值</param>
        ///// <param name="value">缓存的数据，可以为null值</param>
        ///// <param name="scavengingPriority">缓存数据清除优先级</param>
        ///// <param name="policy">数据过期策略(AbsoluteTime/ExtendedFormat/FileDependency/NeverExpired/SlidingTime)，可以为空</param>
        //public static void Add(string key, object value, CacheItemPriority scavengingPriority, ExpirationPolicy policy)
        //{
        //    cache.Add(key, value, scavengingPriority, policy);
        //}

        /// <summary>
        /// 删除缓存数据项
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            cache.Remove(key);
        }

        /// <summary>
        /// 删除所有缓存数据项
        /// </summary>
        public static void RemoveAll()
        {
            cache.RemoveAll();
        }
        #endregion

    }
}
