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
    public partial class AUserOper : SingleTon<AUserOper>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <returns>对象列表</returns>
        public List<AUser> LoginOn(string UserName, string PassWord)
        {
            var query = new LambdaQuery<AUser>();
            query.Where(p => p.UserName == UserName || p.UserPhone == UserName);
            query.Where(p => p.UserPassword == PassWord);
            return query.GetQueryList();
        }

        /// <summary>
        /// 根据用户Id筛选用户
        /// </summary>
        /// <param name="UserId">用户Id</param>
        /// <returns>对象列表</returns>
        public List<AUser> SelectById(int UserId)
        {
            var query = new LambdaQuery<AUser>();
            query.Where(p => p.UserId == UserId);
            return query.GetQueryList();
        }

        /// <summary>
        /// 根据用户手机筛选用户
        /// </summary>
        /// <param name="UserPhone">用户手机</param>
        /// <returns>对象</returns>
        public AUser SelectByPhone(string UserPhone)
        {
            var query = new LambdaQuery<AUser>();
            query.Where(p => p.UserPhone == UserPhone);
            var List_User = query.GetQueryList();
            return List_User == null ? null : List_User.FirstOrDefault();
        }
    }
}
