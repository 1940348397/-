using Common.MemCache.Function2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    public class MemCacheHelper2 : SingleTon<MemCacheHelper2>
    {
        public MemcachedClient Cache;
        public MemCacheHelper2()
        {
            Cache = MemcachedClient.GetInstance("MyConfigFileCache");
        }
    }
}
