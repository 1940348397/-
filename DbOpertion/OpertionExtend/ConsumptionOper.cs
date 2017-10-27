using Common;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.LambdaOpertion;
using Common.Extend;
using DbOpertion.Models;

namespace DbOpertion.Operation
{
    public partial class ConsumptionOper : SingleTon<ConsumptionOper>
    {

        /// <summary>
        /// 筛选用户数据根据Id
        /// </summary>
        ///  <param name="Key">主键</param>
        ///  <param name="desc">排序</param>
        /// <returns>对象列表</returns>
        public List<Consumption> SelectByUserId(int UserId, string Key, bool desc = true)
        {
            var query = new LambdaQuery<Consumption>();
            query.Where(p => p.UserId == UserId);
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
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
        public List<Consumption> SelectPageByUserId(int UserId, string SearchKey, string Key, int start, int PageSize, bool desc = true)
        {
            var query = new LambdaQuery<Consumption>();
            query.Where(p => p.UserId == UserId);
            if (!SearchKey.IsNullOrEmpty())
            {
                query.Where(p => p.ShopName.Contains(SearchKey));
            }
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            return query.GetQueryPageList(start, PageSize);
        }
        ///<summary>
        /// 根据分页筛选数据
        /// </summary>
        /// <param name="UserId">用户Id</param>
        /// <param name="SearchKey">搜索关键字</param>
        /// <param name="Key">排序主键</param>
        /// <param name="desc">排序</param>
        /// <returns></returns>
        public int SelectByUserIdCount(int UserId, string SearchKey, string Key, bool desc = true)
        {
            var query = new LambdaQuery<Consumption>();
            query.Where(p => p.UserId == UserId);
            if (!SearchKey.IsNullOrEmpty())
            {
                query.Where(p => p.ShopName.Contains(SearchKey));
            }
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            return query.GetQueryCount();
        }

        /// <summary>
        /// 根据分页筛选数据
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="Key">排序主键</param>
        /// <param name="desc">排序</param>
        /// <returns></returns>
        public int SelectByUserIdCount(int UserId, string Key, bool desc = true)
        {
            var query = new LambdaQuery<Consumption>();
            query.Where(p => p.UserId == UserId);
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            return query.GetQueryCount();
        }
        /// <summary>
        /// 根据电子储值卡Id查找对应的会员的消费记录
        /// </summary>
        /// <param name="ElectronicId">电子储值卡Id</param>
        /// <param name="SearchKey">搜索关键字</param>
        /// <param name="Key">排序主键</param>
        /// <param name="start">开始条数</param>
        /// <param name="PageSize">页面长度</param>
        /// <param name="desc">排序</param>
        /// <returns></returns>
        public List<Consumption> SelectConsumptionListById(int ElectronicId, string SearchKey, string Key, int start, int PageSize, bool desc = true)
        {
            var query = new LambdaQuery<Consumption>();
            query.Where(p => p.ElectronicId == ElectronicId);
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            if (!SearchKey.IsNullOrEmpty())
            {
                query.Where(p => p.ShopName.Contains(SearchKey) || p.ShopMoney.Contains(SearchKey) || p.ShopType.Contains(SearchKey) || p.ShopTime.Contains(SearchKey));
            }
            return query.GetQueryPageList(start, PageSize);
        }
        /// <summary>
        /// 根据分页筛选数据
        /// </summary>
        /// <param name="ElectronicId">电子储值卡Id</param>
        /// <param name="SearchKey">搜索关键字</param>
        /// <returns></returns>
        public int SelectConsumptionCount(int ElectronicId, string SearchKey)
        {
            var query = new LambdaQuery<Consumption>();
            query.Where(p => p.ElectronicId == ElectronicId);
            if (!SearchKey.IsNullOrEmpty())
            {
                query.Where(p => p.ShopName.Contains(SearchKey) || p.ShopMoney.Contains(SearchKey) || p.ShopType.Contains(SearchKey) || p.ShopTime.Contains(SearchKey));
            }
            return query.GetQueryCount();
        }
    }
}
