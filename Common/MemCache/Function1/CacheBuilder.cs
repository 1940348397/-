namespace Common.MemCache.EnyimCache
{

    public class CacheBuilder
    {

        public static ICacheReaderService GetReaderService()
        {
            return new CacheReaderService();
        }

        public static ICacheWriterService GetWriterService()
        {
            return new CacheWriterService();
        }

        public static ICacheWriterService GetWriterService(int timeout)
        {
            return new CacheWriterService(timeout);
        }
    }
}
