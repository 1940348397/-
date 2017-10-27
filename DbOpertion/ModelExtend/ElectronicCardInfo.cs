using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.Models
{
    public class ElectronicCardInfo
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 卡余额
        /// </summary>
        public string CaerMoney { get; set; }
        /// <summary>
        /// 电子储值卡类型Id
        /// </summary>
        public int ElectronicTypeId { get; set; }
        /// <summary>
        /// 是否使用
        /// </summary>
        public bool IsUser { get; set; }
        /// <summary>
        /// 是否失效
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserNickName { get; set; }
        public string UserName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string UserPhone { get; set; }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string UserEmail { get; set; }
        public int ElectronicId { get; set; }
    }
}
