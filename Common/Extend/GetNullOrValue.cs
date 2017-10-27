using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extend
{
    /// <summary>
    /// 可为空类型获得值
    /// </summary>
    public static class GetNullOrValue
    {
        public static bool GetNullORValue(this bool? s)
        {
            if (s == null)
            {
                return false;
            }
            else
            {
                return s.Value;
            }
        }

        public static DateTime GetNullORValue(this DateTime? s)
        {
            if (s == null)
            {
                return new DateTime();
            }
            else
            {
                return s.Value;
            }
        }

        public static int GetNullORValue(this int? s)
        {
            if (s == null)
            {
                return 0;
            }
            else
            {
                return s.Value;
            }
        }

        public static double GetNullORValue(this double? s)
        {
            if (s == null)
            {
                return 0;
            }
            else
            {
                return s.Value;
            }
        }
    }
}
