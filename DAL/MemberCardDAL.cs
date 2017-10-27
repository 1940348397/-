using Common.Extend;
using Common.Helper;
using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MemberCardDAL
    {
        public string linq = "linq";
        /// <summary>
        /// 根据优惠券名称查询是否有对应的用户
        /// </summary>
        /// <param name="CouponName">优惠券名称</param>
        /// <returns></returns>
        public DataTable GetUserIDandIsDelete(string CouponName)
        {
            List<SqlParameter> parmList = new List<SqlParameter>();
            parmList.Add(new SqlParameter("@CouponName", CouponName));
            string sql = @"select * from ElectronicCard a
                           left join AUser b on a.UserId = b.UserId
                            ";//where
            var sqlhelper = SqlHelper.GetSqlServerHelper(linq);
            return sqlhelper.ExecuteReader(sql, parmList.ToArray());//.ConvertToList<>()
            //            SELECT
            //    *
            //FROM

            //    ElectronicCard a
            //LEFT JOIN AUser b ON a.UserId = b.UserId
            //WHERE ElectronicTypeId = 2 and  LIKE '%123%' or UserNickName LIKE '%123%'


        }
        /// <summary>
        /// 根据电子储值卡的类型ID查询对应的卡片信息
        /// </summary>
        /// <param name="card">电子储值卡实体类</param>
        /// <param name="user">用户实体类</param>
        /// <returns></returns>
        public List<ElectronicCardInfo> Get_ElectronicCardByTypeId(int ElectronicTypeId,string SearchKey)
        {
            List<SqlParameter> parmList = new List<SqlParameter>();
            parmList.Add(new SqlParameter("@ElectronicTypeId", ElectronicTypeId));
            parmList.Add(new SqlParameter("@CaerMoney", "'%" + SearchKey + "%'"));
            parmList.Add(new SqlParameter("@UserNickName", "'%" + SearchKey + "%'"));
            parmList.Add(new SqlParameter("@UserPhone", "'%" + SearchKey + "%'"));
            parmList.Add(new SqlParameter("@UserEmail", "'%" + SearchKey + "%'"));
            string sql = string.Format(@"select  from ElectronicCard a 
                                         left join AUser b on a.UserId=b.UserId
                                         where ElectronicTypeId=@ElectronicTypeId and CaerMoney like @CaerMoney or
                                         UserNickName like @UserNickName or UserPhone like @UserPhone or 
                                         UserEmail like @UserEmail");
            var sqlHelper = SqlHelper.GetSqlServerHelper(linq);
            return sqlHelper.ExecuteReader(sql, parmList.ToArray()).ConvertToList<ElectronicCardInfo>();//.ConvertToList<T>();
        }
    }
}
