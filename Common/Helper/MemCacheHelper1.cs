using Common.MemCache.EnyimCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    public class MemCacheHelper1 : SingleTon<MemCacheHelper1>
    {
        public ICacheWriterService writer;
        public ICacheReaderService reader;
        public MemCacheHelper1()
        {    
            writer = CacheBuilder.GetWriterService();//writer 使用memcached默认过期时间
            reader = CacheBuilder.GetReaderService();//reader
            writer.TimeOut = 120;
        }
    }
}
