using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extend
{
    public static class LambdaFunction
    {
        /// <summary>
        /// 日期的Contains方法
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool Contains(this DateTime s, string SerachKey)
        {
            string DateTimeString = s.ToString("yyyy-MM-dd HH:mm:ss.fff");
            if (DateTimeString.Contains((SerachKey)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 日期的Contains方法
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool Contains(this DateTime? s, string SerachKey)
        {
            if (s == null)
            {
                return false;
            }
            string DateTimeString = s.Value.ToString("yyyy-MM-dd HH:mm:ss.fff");
            if (DateTimeString.Contains((SerachKey)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 日期的Contains方法
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool Contains(this decimal? s, string SerachKey)
        {
            if (s == null)
            {
                return false;
            }
            string DecimalString = s.Value.ToString();
            if (DecimalString.Contains((SerachKey)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 日期的Contains方法
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool Contains(this int? s, string SerachKey)
        {
            if (s == null)
            {
                return false;
            }
            string IntString = s.Value.ToString();
            if (IntString.Contains((SerachKey)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 验证是否在列表内
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="List_Int">列表</param>
        /// <returns></returns>
        public static bool ContainsIn(this int Id, List<int> List_Int)
        {
            return List_Int.Contains(Id);
        }

        /// <summary>
        /// 验证是否在列表内
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="List_Int">列表</param>
        /// <returns></returns>
        public static bool ContainsIn(this int? Id, List<int> List_Int)
        {
            return List_Int.Contains(Id.Value);
        }


        /// <summary>
        /// 验证是否在列表内
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="List_Int">列表</param>
        /// <returns></returns>
        public static bool ContainsNotIn(this int Id, List<int> List_Int)
        {
            return !List_Int.Contains(Id);
        }

        /// <summary>
        /// 验证是否在列表内
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="List_Int">列表</param>
        /// <returns></returns>
        public static bool ContainsNotIn(this int? Id, List<int> List_Int)
        {
            return !List_Int.Contains(Id.Value);
        }
    }
}
