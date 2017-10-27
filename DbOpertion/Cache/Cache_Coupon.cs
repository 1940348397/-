using Common;
using Common.Result;
using DbOpertion.Models;
using DbOpertion.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.Cache
{
    /// <summary>
    /// 优惠卷缓存
    /// </summary>
    public partial class Cache_Coupon : SingleTon<Cache_Coupon>
    {
        /// <summary>
        /// 筛选全部
        /// </summary>
        /// <param name="Key">排序Key</param>
        /// <param name="desc">排序</param>
        /// <returns></returns>
        public List<Coupon> SelectAll(string Key, DataTablesOrderDir desc)
        {
            bool asc;
            if (desc == DataTablesOrderDir.Asc)
            {
                asc = true;
            }
            else
            {
                asc = false;
            }
            return CouponOper.Instance.SelectAll(Key, asc);
        }

        /// <summary>
        /// 筛选全部条数
        /// </summary>
        /// <returns></returns>
        public int SelectAllCount()
        {
            return CouponOper.Instance.SelectCount(null);
        }

        /// <summary>
        /// 分页筛选
        /// </summary>
        /// <param name="SearchKey">搜索主键</param>
        /// <param name="Key">排序主键</param>
        /// <param name="start">开始序号</param>
        /// <param name="PageSize">页面长度</param>
        /// <param name="desc">排序方式</param>
        /// <returns></returns>
        public List<Coupon> SelectByPage(string SearchKey, string Key, int start, int PageSize, DataTablesOrderDir desc)
        {
            bool asc;
            if (desc == DataTablesOrderDir.Asc)
            {
                asc = true;
            }
            else
            {
                asc = false;
            }
            return CouponOper.Instance.SelectByPage(SearchKey, Key, start, PageSize, asc);
        }

        /// <summary>
        /// 筛选搜索后的条数
        /// </summary>
        /// <returns></returns>
        public int SelectSearchCount(string SearchKey)
        {
            return CouponOper.Instance.SelectSearchCount(SearchKey);
        }
        /// <summary>
        /// 根据优惠券ID查找是否有对应的详细信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Coupon MemberGetCouponInfo(int CouponID)
        {
            var Coupon_List = CouponOper.Instance.SelectById(CouponID);
            Coupon card ;
            if (Coupon_List != null && Coupon_List.Count != 0)
            {
                card = Coupon_List.FirstOrDefault();
            }
            else
            {
                card = null;
            }
            return card;
        }
      
       
    }
}
