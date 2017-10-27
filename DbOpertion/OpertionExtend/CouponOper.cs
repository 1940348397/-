using Common;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.LambdaOpertion;
using Common.Extend;
using DbOpertion.Models;
using Common.Result;

namespace DbOpertion.Operation
{
    public partial class CouponOper : SingleTon<CouponOper>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        ///  <param name="Key">主键</param>
        ///  <param name="desc">排序</param>
        /// <returns>对象列表</returns>
        public List<Coupon> SelectAll(string SearchKey, string Key, bool desc = true)
        {
            var query = new LambdaQuery<Coupon>();
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            if (!SearchKey.IsNullOrEmpty())
            {
                query.Where(p => p.CouponDescribe.Contains(SearchKey) || p.CouponName.Contains(SearchKey) || p.ExpirationDay.Contains(SearchKey));
            }
            return query.GetQueryList();
        }


        /// <summary>
        /// 根据分页筛选数据
        /// </summary>
        ///  <param name="Key">主键</param>
        ///  <param name="start">开始数据</param>
        ///  <param name="PageSize">页面长度</param>
        ///  <param name="desc">排序</param>
        /// <returns>对象列表</returns>
        public List<Coupon> SelectByPage(string SearchKey, string Key, int start, int PageSize, bool desc = true)
        {
            var query = new LambdaQuery<Coupon>();
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            if (!SearchKey.IsNullOrEmpty())
            {
                query.Where(p => p.CouponDescribe.Contains(SearchKey) || p.CouponName.Contains(SearchKey) || p.ExpirationDay.Contains(SearchKey));
            }
            return query.GetQueryPageList(start, PageSize);
        }


        /// <summary>
        /// 根据分页筛选数据
        /// </summary>
        ///  <param name="Key">主键</param>
        ///  <param name="start">开始数据</param>
        ///  <param name="PageSize">页面长度</param>
        ///  <param name="desc">排序</param>
        /// <returns>对象列表</returns>
        public List<Coupon> SelectByPageByMemberCard(List<int> List_Id, string SearchKey, string Key, int start, int PageSize, bool desc = true)
        {
            var query = new LambdaQuery<Coupon>();
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            query.Where(p => p.CouponId.ContainsIn(List_Id));
            if (!SearchKey.IsNullOrEmpty())
            {
               
                query.Where(p => p.CouponDescribe.Contains(SearchKey) || p.CouponName.Contains(SearchKey) || p.ExpirationDay.Contains(SearchKey));
            }
            return query.GetQueryPageList(start, PageSize);
        }
        /// <summary>
        /// 查找剩余部分的全部优惠券
        /// </summary>
        /// <param name="List_Id"></param>
        /// <param name="SearchKey"></param>
        /// <param name="Key"></param>
        /// <param name="start"></param>
        /// <param name="PageSize"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public List<Coupon> SelectByPageByAllMemberCard(List<int> List_Id, string SearchKey, string Key, int start, int PageSize, bool desc = true)
        {
            var query = new LambdaQuery<Coupon>();
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            query.Where(p => p.CouponId.ContainsNotIn(List_Id));
            if (!SearchKey.IsNullOrEmpty())
            {

                query.Where(p => p.CouponDescribe.Contains(SearchKey) || p.CouponName.Contains(SearchKey) || p.ExpirationDay.Contains(SearchKey));
            }
            return query.GetQueryPageList(start, PageSize);
        }
       /// <summary>
       /// 根据ID查找对应优惠券的数据的总条数
       /// </summary>
       /// <param name="List_Id"></param>
       /// <param name="SearchKey"></param>
       /// <returns></returns>
        public int SelectMemberCardCountByID(List<int> List_Id,string SearchKey)
        {
            var query = new LambdaQuery<Coupon>();
            query.Where(p => p.CouponId.ContainsIn(List_Id));
            if (!SearchKey.IsNullOrEmpty())
            {
                query.Where(p => p.CouponDescribe.Contains(SearchKey) || p.CouponName.Contains(SearchKey) || p.ExpirationDay.Contains(SearchKey));

            }
            return query.GetQueryCount();
        }

        /// <summary>
        /// 查找剩余优惠券的数据总条数
        /// </summary>
        ///  <param name="Key">主键</param>
        ///  <param name="start">开始数据</param>
        ///  <param name="PageSize">页面长度</param>
        ///  <param name="desc">排序</param>
        /// <returns>对象列表</returns>
        public int SelectAllMemberCardCount(List<int> List_Id, string SearchKey)
        {
            var query = new LambdaQuery<Coupon>();
            query.Where(p => p.CouponId.ContainsNotIn(List_Id));
            if (!SearchKey.IsNullOrEmpty())
            {

                query.Where(p => p.CouponDescribe.Contains(SearchKey) || p.CouponName.Contains(SearchKey) || p.ExpirationDay.Contains(SearchKey));
            }
            return query.GetQueryCount();
        }
        /// <summary>
        /// 根据分页筛选数据
        /// </summary>
        ///  <param name="SearchKey">搜索条件</param>
        /// <returns>对象列表</returns>
        public int SelectSearchCount(string SearchKey)
        {
            var query = new LambdaQuery<Coupon>();
            if (!SearchKey.IsNullOrEmpty())
            {
                query.Where(p => p.CouponDescribe.Contains(SearchKey) || p.CouponName.Contains(SearchKey) || p.ExpirationDay.Contains(SearchKey));
            }
            return query.GetQueryCount();
        }
        /// <summary>
        /// 根据卡片的名称查找优惠券的信息
        /// </summary>
        /// <param name="CouponName"></param>
        /// <returns></returns>
        public List<Coupon> SelectById(int CouponID)
        {
            var query = new LambdaQuery<Coupon>();
            query.Where(p => p.CouponId == CouponID);
            return query.GetQueryList();
        }
        /// <summary>
        /// 根据ID查找对应的详细信息
        /// </summary>
        /// <param name="SearchKey"></param>
        /// <param name="Key"></param>
        /// <param name="start"></param>
        /// <param name="PageSize"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public List<Coupon> SelectByCouponID(string SearchKey, string Key, int start, int PageSize, DataTablesOrderDir desc)
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

    }
}
