using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbOpertion.Models;
using DbOpertion.Operation;
using Common;
using Common.Helper;
using System.Configuration;
using Common.Result;

namespace DbOpertion.Cache
{
    /// <summary>
    /// 会员用户缓存
    /// </summary>
    public partial class Cache_TUser : SingleTon<Cache_TUser>
    {
        /// <summary>
        /// 筛选全部会员用户信息
        /// </summary>
        public List<TUser> SelectMemberUser(string searchKey, string Key, int PageNo, int PageSize, DataTablesOrderDir? desc)
        {
            bool order = false;
            if (desc == DataTablesOrderDir.Asc)
            {
                order = false;
            }
            else if (desc == DataTablesOrderDir.Desc)
            {
                order = true;
            }
            return TUserOper.Instance.SelectByPage(searchKey, Key, PageNo, PageSize, order);
        }

        /// <summary>
        /// 筛选全部会员用户数目
        /// </summary>
        //public int SelectMemberUserCount(string Key, DataTablesOrderDir? desc)
        //{
        //    bool order = false;
        //    if (desc == DataTablesOrderDir.Asc)
        //    {
        //        order = false;
        //    }
        //    else if (desc == DataTablesOrderDir.Desc)
        //    {
        //        order = true;
        //    }
        //    return TUserOper.Instance.SelectCount(Key, order);
        //}

        /// <summary>
        /// 筛选全部会员用户数目
        /// </summary>
        public int SelectMemberUserCount(string SearchKey, string Key, DataTablesOrderDir? desc)
        {
            bool order = false;
            if (desc == DataTablesOrderDir.Asc)
            {
                order = false;
            }
            else if (desc == DataTablesOrderDir.Desc)
            {
                order = true;
            }
            return TUserOper.Instance.SelectCount(SearchKey, Key, order);
        }

        /// <summary>
        /// 会员用户登入信息
        /// </summary>
        /// <param name="UserName">用户名称</param>
        /// <param name="UserPassWord">用户密码</param>
        public TUser MemberUserLogin(string UserName, string UserPassWord)
        {
            string PassWordMd5 = MD5Helper.StrToMD5WithKey(UserPassWord);
            var list = TUserOper.Instance.LoginOn(UserName, PassWordMd5);
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        /// <summary>
        /// 根据后台用户id筛选用户信息
        /// </summary>
        /// <param name="UserId">用户Id</param>
        /// <returns></returns>
        public TUser MemberGetUserInfo(int UserId)
        {
            var List_User = TUserOper.Instance.SelectById(UserId);
            TUser user;
            if (List_User != null && List_User.Count != 0)
            {
                user = List_User.FirstOrDefault();
            }
            else
            {
                user = null;
            }
            return user;
        }

        /// <summary>
        /// 根据用户手机筛选用户
        /// </summary>
        /// <param name="UserPhone">用户手机号码</param>
        /// <returns></returns>
        public TUser SelectByPhone(string UserPhone)
        {
            return TUserOper.Instance.SelectByPhone(UserPhone);
        }

        /// <summary>
        /// 设置用户注册验证码
        /// </summary>
        /// <param name="phone">用户手机号码</param>
        /// <returns></returns>
        public string SetMemberCode(string phone)
        {
            if (MemCacheHelper1.Instance.reader.Get("MemberResetCode_Phone=" + phone) == null)
            {
                string VerificationCode = RandHelper.Instance.Number(6);
                MemCacheHelper1.Instance.writer.Add("MemberResetCode_Phone=" + phone, VerificationCode, 1);
                MemCacheHelper1.Instance.writer.Add("MemberCode_Phone=" + phone, VerificationCode, 10);
                return VerificationCode;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取用户注册验证码
        /// </summary>
        /// <param name="phone">用户手机号码</param>
        /// <returns></returns>
        public string GetMemberCode(string phone)
        {
            var code = MemCacheHelper1.Instance.reader.Get("MemberCode_Phone=" + phone);
            return code.ToString();
        }

        /// <summary>
        /// 用户注册验证码是否能重置
        /// </summary>
        /// <param name="Phone">用户手机</param>
        /// <returns></returns>
        public bool GetUserResetCode(string Phone)
        {
            var phone = MemCacheHelper1.Instance.reader.Get("MemberResetCode_Phone=" + Phone);
            return phone == null;
        }

        /// <summary>
        /// 清除注册缓存
        /// </summary>
        /// <param name="phone">用户手机号码</param>
        /// <returns></returns>
        public void ClearMemberCode(string phone)
        {
            MemCacheHelper1.Instance.writer.Remove("MemberResetCode_Phone=" + phone);
            MemCacheHelper1.Instance.writer.Remove("MemberCode_Phone=" + phone);
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="UserId">用户Id</param>
        /// <returns></returns>
        public bool UpdateUserInfo(TUser UserInfo)
        {
            var flag = TUserOper.Instance.Update(UserInfo);
            return flag;
        }


    }
}
