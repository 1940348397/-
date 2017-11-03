using Common;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.LambdaOpertion;
using Common.Extend;
using DbOpertion.Models;
using System.Data.SqlClient;
using Common.Helper;
using System.Data;

namespace DbOpertion.Operation
{
    public partial class ElectronicCardOper : SingleTon<ElectronicCardOper>
    {
        public string linq = "linq";
        /// <summary>
        /// ���ݵ��Ӵ�ֵ��������ID��ѯ��Ӧ�Ŀ�Ƭ��Ϣ
        /// </summary>
        /// <param name="card">���Ӵ�ֵ��ʵ����</param>
        /// <param name="user">�û�ʵ����</param>
        /// <returns></returns>
        //public List<ElectronicCardInfo> Get_ElectronicCardByTypeId1(int ElectronicTypeId,  string SearchKey,bool OrdeyBy,  int start, int PageSize)
        //{
        //    List<SqlParameter> parmList = new List<SqlParameter>();
        //    parmList.Add(new SqlParameter("@ElectronicTypeId", ElectronicTypeId));
        //    parmList.Add(new SqlParameter("@CaerMoney", "'%" + SearchKey + "%'"));
        //    parmList.Add(new SqlParameter("@UserNickName", "'%" + SearchKey + "%'"));
        //    parmList.Add(new SqlParameter("@UserPhone", "'%" + SearchKey + "%'"));
        //    parmList.Add(new SqlParameter("@UserEmail", "'%" + SearchKey + "%'"));
        //    string sql = string.Format(@"* from ElectronicCard a 
        //                                 left join AUser b on a.UserId=b.UserId
        //                                 where ElectronicTypeId=@ElectronicTypeId and CaerMoney like @CaerMoney or
        //                                 UserNickName like @UserNickName or UserPhone like @UserPhone or 
        //                                 UserEmail like @UserEmail+ +asc");
        //    return SqlOpertion.Instance.GetQueryPage<ElectronicCardInfo>(sql, parmList, OrdeyBy, start, PageSize);
        //}
        /// <summary>
        /// ���ݵ��Ӵ�ֵ��������ID��ѯ��Ӧ�Ŀ�Ƭ��Ϣ
        /// </summary>
        /// <param name="card">���Ӵ�ֵ��ʵ����</param>
        /// <param name="user">�û�ʵ����</param>
        /// <returns></returns>
        public List<ElectronicCardInfo> Get_ElectronicCardByTypeId(int ElectronicTypeId, string SearchKey, string Key, int start, int PageSize, bool desc = true)
        {
            List<SqlParameter> parmList = new List<SqlParameter>();
            string SqlWhereLike = null;
            if (!SearchKey.IsNullOrEmpty())
            {
                parmList.Add(new SqlParameter("@CaerMoney", "'%" + SearchKey + "%'"));
                parmList.Add(new SqlParameter("@UserNickName", "'%" + SearchKey + "%'"));
                parmList.Add(new SqlParameter("@UserPhone", "'%" + SearchKey + "%'"));
                parmList.Add(new SqlParameter("@UserEmail", "'%" + SearchKey + "%'"));
                SqlWhereLike = @" and CaerMoney like @CaerMoney or
                                         UserNickName like @UserNickName or UserPhone like @UserPhone or
                                         UserEmail like @UserEmail";
            }
            parmList.Add(new SqlParameter("@ElectronicTypeId", ElectronicTypeId));
            string sql = string.Format(@"select b.UserId,a.CaerMoney,a.ElectronicTypeId,a.ElectronicId,a.IsUser,a.IsDelete,b.UserNickName from ElectronicCard a 
                                         left join AUser b on a.UserId=b.UserId
                                         where ElectronicTypeId=@ElectronicTypeId " + SqlWhereLike);
            return SqlOpertion.Instance.GetQueryPage<ElectronicCardInfo>(sql, parmList, Key, desc, start, PageSize);
        }

        /// <summary>
        /// ��������
        /// </summary>
        ///  <param name="Key">����</param>
        ///  <param name="start">��ʼ����</param>
        ///  <param name="PageSize">ҳ�泤��</param>
        ///  <param name="desc">����</param>
        /// <returns>�����б�</returns>
        public int SelectSearchCount(int ElectronicTypeId, string SearchKey)
        {
            List<SqlParameter> parmList = new List<SqlParameter>();
            string SqlWhereLike = null;
            if (!SearchKey.IsNullOrEmpty())
            {
                parmList.Add(new SqlParameter("@CaerMoney", "'%" + SearchKey + "%'"));
                parmList.Add(new SqlParameter("@UserNickName", "'%" + SearchKey + "%'"));
                parmList.Add(new SqlParameter("@UserPhone", "'%" + SearchKey + "%'"));
                parmList.Add(new SqlParameter("@UserEmail", "'%" + SearchKey + "%'"));
                SqlWhereLike = @" and CaerMoney like @CaerMoney or
                                         UserNickName like @UserNickName or UserPhone like @UserPhone or
                                         UserEmail like @UserEmail";
            }
            parmList.Add(new SqlParameter("@ElectronicTypeId", ElectronicTypeId));
            string sql = string.Format(@"select a.UserId,a.CaerMoney,a.ElectronicTypeId,a.ElectronicId,a.IsUser,a.IsDelete from ElectronicCard a 
                                         left join AUser b on a.UserId=b.UserId
                                         where ElectronicTypeId=@ElectronicTypeId " + SqlWhereLike);
            return SqlOpertion.Instance.GetQueryCount(sql, parmList);
        }
    }
}
