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
using System.Data.SqlClient;

namespace DbOpertion.Operation
{
    public partial class MemberShipCardOper : SingleTon<MemberShipCardOper>
    {

        /// <summary>
        /// 新增会员卡
        /// </summary>
        /// <param name="CardName"></param>
        /// <param name="TypeImage"></param>
        /// <param name="IsUser"></param>
        /// <param name="IsDelete"></param>
        /// <returns></returns>
        public bool AddMemberCard(string CardName, string TypeImage, bool IsUser, bool IsDelete)
        {
            var insert = new LambdaInsert<MemberShipCard>();
            insert.Insert(p => p.CardName == CardName);
            return insert.GetInsertResult();
        }

        /// <summary>
        /// 根据分页筛选数据
        /// </summary>
        ///  <param name="Key">主键</param>
        ///  <param name="start">开始数据</param>
        ///  <param name="PageSize">页面长度</param>
        ///  <param name="desc">排序</param>
        /// <returns>对象列表</returns>
        public List<MemberShipCard> SelectByPage(string SearchKey, string Key, int start, int PageSize, bool desc = true)
        {
            var query = new LambdaQuery<MemberShipCard>();
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
            var query = new LambdaQuery<MemberShipCard>();
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
        /// <summary>
        /// 根据类型ID查找对应的卡片
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //public List<MemberShipCard> SelectMemCardByTypeId(int MemberShipTypeId, string SearchKey, string Key, int start, int PageSize, bool desc = true)
        //{
        //    var query = new LambdaQuery<MemberShipCard>();
        //    query.Where(p => p.MemberShipTypeId == MemberShipTypeId);
        //    if (Key != null)
        //    {
        //        query.OrderByKey(Key, desc);
        //    }
        //    if (!SearchKey.IsNullOrEmpty())
        //    {

        //        query.Where(p => p.CardName.Contains(SearchKey) || p.CardPassword.Contains(SearchKey));
        //    }
        //    return query.GetQueryPageList(start, PageSize);
        //}
        public List<MemberCardByTypeInfo> SelectMemCardByTypeId(int MemberShipTypeId, string SearchKey, string Key, int start, int PageSize, bool desc = true)
        {
            List<SqlParameter> parmList = new List<SqlParameter>();
            string SqlWhereLike = null;
            if (!SearchKey.IsNullOrEmpty())
            {
                parmList.Add(new SqlParameter("@CardName", "%" + SearchKey + "%"));
                parmList.Add(new SqlParameter("@UserNickName", "%" + SearchKey + "%"));
                parmList.Add(new SqlParameter("@MemberShipCardId", "%" + SearchKey + "%"));
                parmList.Add(new SqlParameter("@MemberShipTypeId", "%" + SearchKey + "%"));
                parmList.Add(new SqlParameter("@ReleaseDate", "%" + SearchKey + "%"));
                SqlWhereLike = @" and (CardName like @CardName or
                                         UserNickName like @UserNickName or MemberShipCardId like @MemberShipCardId or
                                         MemberShipTypeId like @MemberShipTypeId or ReleaseDate like @ReleaseDate)";
            }
            parmList.Add(new SqlParameter("@MemberShipTypeId", MemberShipTypeId));
            string sql = string.Format(@"select a.CardName,a.ReleaseDate,a.MemberShipTypeId,a.MemberShipCardId,a.IsUser,b.UserNickName,a.UserId from MemberShipCard a 
                                         left join TUser b on a.UserId=b.UserId
                                         where MemberShipTypeId=@MemberShipTypeId " + SqlWhereLike);
            return SqlOpertion.Instance.GetQueryPage<MemberCardByTypeInfo>(sql, parmList, Key, desc, start, PageSize);
        }

        /// <summary>
        /// 根据类型ID查找对应的卡片
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public List<MemberShipCard> SelectMemCardByTypeIdCount(int MemberShipTypeId, string SearchKey, string Key, int start, int PageSize, bool desc = true)
        {
            var query = new LambdaQuery<MemberShipCard>();
            query.Where(p => p.MemberShipTypeId == MemberShipTypeId);
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            if (!SearchKey.IsNullOrEmpty())
            {

                query.Where(p => p.CardName.Contains(SearchKey) || p.CardPassword.Contains(SearchKey));
            }
            return query.GetQueryPageList(start, PageSize);
        }

        /// <summary>
        /// 根据类型ID查找对应的卡片
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public List<MemberShipCard> SelectMemCardByTypeIdAllCount(int MemberShipTypeId, string SearchKey, string Key, int start, int PageSize, bool desc = true)
        {
            var query = new LambdaQuery<MemberShipCard>();
            query.Where(p => p.MemberShipTypeId == MemberShipTypeId);
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            if (!SearchKey.IsNullOrEmpty())
            {

                query.Where(p => p.CardName.Contains(SearchKey) || p.CardPassword.Contains(SearchKey));
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
        public List<MemberShipCard> SelectByPageByMemberCard(int MemberShipTypeId, string SearchKey, string Key, int start, int PageSize, bool desc = true)
        {
            var query = new LambdaQuery<MemberShipCard>();
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            query.Where(p => p.MemberShipTypeId==MemberShipTypeId);
            if (!SearchKey.IsNullOrEmpty())
            {

                query.Where(p => p.CardName.Contains(SearchKey) || p.CardPassword.Contains(SearchKey));
            }
            return query.GetQueryPageList(start, PageSize);
        }
     
        /// <summary>
        /// 筛选根据类型ID查询的会员卡数目
        /// </summary>
        /// <param name="SearchKey"></param>
        /// <param name="Key"></param>
        /// <param name="desc"></param>
        /// <returns></returns>

        public int SelectMemberCardCountByTypeID(int MemberShipTypeId, string SearchKey)
        {
            var query = new LambdaQuery<MemberShipCard>();
            query.Where(p => p.MemberShipTypeId == MemberShipTypeId);
            if (!SearchKey.IsNullOrEmpty())
            {

                query.Where(p => p.CardName.Contains(SearchKey) || p.CardPassword.Contains(SearchKey));
            }
            return query.GetQueryCount();
            
        }
    }
}
