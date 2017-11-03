using Common;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.LambdaOpertion;
using Common.Extend;
using DbOpertion.Models;
using System.Data;

namespace DbOpertion.Operation
{
    public partial class MemberShipCardOper : SingleTon<MemberShipCardOper>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CardName"></param>
        /// <param name="CardPassword"></param>
        /// <returns></returns>
        public bool MemberShip(string CardName, string CardPassword, IDbConnection connection, IDbTransaction transaction)
        {
            var query = new LambdaQuery<MemberShipCard>();
            query.Where(p => p.CardName == CardName && p.CardPassword == CardPassword && p.UserId == null);
            var count = query.GetQueryCount(connection, transaction);
            return count > 0 ? true : false;
        }

        /// <summary>
        /// ���ÿ�Ƭ���û�ID
        /// </summary>
        /// <param name="UserID">�û�Id</param>
        /// <param name="CardName">����</param>
        /// <returns></returns>
        public bool SetMemberShipUser(int UserID, string CardName, IDbConnection connection, IDbTransaction transaction)
        {
            var query = new LambdaUpdate<MemberShipCard>();
            query.Where(p => p.CardName == CardName);
            query.Set(p => p.UserId == UserID);
            return query.GetUpdateResult(connection, transaction);
        }

        /// <summary>
        /// ���ݿ���ɸѡδʹ�õĿ�Ƭ
        /// </summary>
        /// <param name="UserID">�û�Id</param>
        /// <param name="CardName">����</param>
        /// <returns></returns>
        public MemberShipCard SelectMemberShipByCardName(string CardName, IDbConnection connection, IDbTransaction transaction)
        {
            var query = new LambdaQuery<MemberShipCard>();
            query.Where(p => p.CardName == CardName && p.UserId == null);
            return query.GetQueryList(connection, transaction).FirstOrDefault();
        }
    }
}
