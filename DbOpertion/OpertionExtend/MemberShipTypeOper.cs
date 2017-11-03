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
    public partial class MemberShipTypeOper : SingleTon<MemberShipTypeOper>
    {
        /// <summary>
        /// 根据分页筛选数据
        /// </summary>
        ///  <param name="Key">主键</param>
        ///  <param name="start">开始数据</param>
        ///  <param name="PageSize">页面长度</param>
        ///  <param name="desc">排序</param>
        /// <returns>对象列表</returns>
        public List<MemberShipType> SelectByPage(string SearchKey, string Key, int start, int PageSize, bool desc = true)
        {
            var query = new LambdaQuery<MemberShipType>();
            if (!SearchKey.IsNullOrEmpty())
            {
                query.Where(p => p.CardName.Contains(SearchKey));
            }
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            return query.GetQueryPageList(start, PageSize);
        }
        /// <summary>
        /// 根据分页筛选数据
        /// </summary>
        ///  <param name="Key">主键</param>
        ///  <param name="desc">排序</param>
        /// <returns>对象列表</returns>
        public int SelectCount(string SearchKey, string Key, bool desc = true)
        {
            var query = new LambdaQuery<MemberShipType>();
            if (!SearchKey.IsNullOrEmpty())
            {
                query.Where(p => p.CardName.Contains(SearchKey));

            }
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            return query.GetQueryCount();


        }
    }
}
