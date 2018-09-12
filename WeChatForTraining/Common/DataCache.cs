using System;
using System.Web;
using System.Collections;
using System.Configuration;
namespace Lythen.Common
{
    /// <summary>
    /// ������صĲ����࣬���ʺϻ���ֻ��������
    /// </summary>
    public class DataCache
    {
        /// <summary>
        /// ��ȡ��ǰӦ�ó���ָ��CacheKey��Cacheֵ
        /// </summary>
        /// <param name="CacheKey">�����</param>
        public static object GetCache(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[CacheKey];
        }

        /// <summary>
        /// ���õ�ǰӦ�ó���ָ��CacheKey��Cacheֵ
        /// </summary>
        /// <param name="CacheKey">�����</param>
        /// <param name="objObject">�������</param>
        public static void SetCache(string CacheKey, object objObject)
        {
            SetCache(CacheKey, objObject, DateTime.Now.AddSeconds(PageValidate.FilterLongParam(ConfigurationManager.AppSettings["DataTableCache"])), System.Web.Caching.Cache.NoSlidingExpiration);
            //System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            //objCache.Insert(CacheKey, objObject);
        }

        /// <summary>
        /// ���õ�ǰӦ�ó���ָ��CacheKey��Cacheֵ
        /// </summary>
        /// <param name="CacheKey">�����</param>
        /// <param name="objObject">�������</param>
        /// <param name="absoluteExpiration">������󽫵��ڲ����ӻ������Ƴ���ʱ��</param>
        /// <param name="slidingExpiration">���һ�η��ʻ������ʱ��ö�����ʱ֮���ʱ����</param>
        public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, null, absoluteExpiration, slidingExpiration);
        }

        /// <summary>
        /// �����ǰӦ�ó���ָ��CacheKey��Cacheֵ
        /// <param name="CacheKey">�����</param>
        /// </summary>
        public static void RemoveCache(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Remove(CacheKey);
        }

        /// <summary>
        /// ������л���
        /// </summary>
        public static void RemoveAllCache()
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            IDictionaryEnumerator enumCache = objCache.GetEnumerator();
            while (enumCache.MoveNext())
            {
                objCache.Remove(enumCache.Key.ToString());
            }
        }
        public static void RemoveCacheBySearch(string KeyWord)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            IDictionaryEnumerator enumCache = objCache.GetEnumerator();
            while (enumCache.MoveNext())
            {
                if (enumCache.Key.ToString().Contains(KeyWord))
                    objCache.Remove(enumCache.Key.ToString());
            }
        }
    }
}
