using System;
using System.Collections;
using System.Web;
using System.Web.Caching;
using System.Configuration;

namespace Common.Helper
{
    /// <summary>
    /// 缓存帮助类
    /// </summary>
    public class CacheHelper : SingleTon<CacheHelper>
    {
        /// <summary>
        /// 通用表Cache过期时间
        /// </summary>
        public int CacheOutTime = int.Parse(ConfigurationManager.AppSettings["CacheOutTime"]);
        /// <summary>
        /// 标签表Cache过期时间
        /// </summary>
        public int TagCacheOutTime = int.Parse(ConfigurationManager.AppSettings["TagCacheOutTime"]);
        /// <summary>
        /// 用户表Cache过期时间
        /// </summary>
        public int UserCacheOutTime = int.Parse(ConfigurationManager.AppSettings["UserCacheOutTime"]);
        /// <summary>
        /// 数据字典表Cache过期时间
        /// </summary>
        public int DataDictionaryCacheOutTime = int.Parse(ConfigurationManager.AppSettings["DataDictionaryCacheOutTime"]);
        /// <summary>
        /// 数据字典表Cache过期时间
        /// </summary>
        public int SportCacheOutTime = int.Parse(ConfigurationManager.AppSettings["SportCacheOutTime"]);
        private Cache CurrentCache
        {
            get { return HttpRuntime.Cache; }
        }

        /// <summary>
        /// 设置数据缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="obj">值</param>
        /// <param name="time">时间差</param>
        public void SetCache(string key, object obj)
        {
            if (obj != null)
            {
                CurrentCache.Insert(key, obj);
            }
        }

        /// <summary>
        /// 设置数据缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="obj">值</param>
        /// <param name="minutes">分钟</param>
        public void SetCache(string key, object obj, int minutes)
        {
            if (obj != null)
            {
                CurrentCache.Insert(key, obj, null, DateTime.Now.AddMinutes(minutes), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.NotRemovable, null);
            }
        }

        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        /// <param name="CacheKey">指定Key</param>
        public void RemoveCache(string CacheKey)
        {
            CurrentCache.Remove(CacheKey);
        }

        /// <summary>
        /// 移除全部缓存
        /// </summary>
        public void RemoveAllCache()
        {
            System.Web.Caching.Cache _cache = HttpRuntime.Cache;
            IDictionaryEnumerator CacheEnum = _cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                CurrentCache.Remove(CacheEnum.Key.ToString());
            }
        }

        /// <summary>
        /// 获取数据缓存
        /// </summary>
        /// <param name="Key">键</param>
        public object GetCache(string Key)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            var cache = CurrentCache.Get(Key);
            if (cache != null)
            {
                return cache;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取数据缓存
        /// </summary>
        /// <typeparam name="T">所转换类型</typeparam>
        /// <param name="Key">键</param>
        /// <returns></returns>
        public T GetCache<T>(string Key)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            var cache = CurrentCache.Get(Key);
            if (cache != null)
            {
                return (T)cache;
            }
            else
            {
                return default(T);
            }
        }
    }
}
