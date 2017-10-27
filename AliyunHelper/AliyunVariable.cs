using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliyunHelper
{
    public static class AliyunVariable
    {
        /// <summary>
        /// 阿里云AccessKeyId
        /// </summary>
        public static string AliyunAccessKeyId = ConfigurationManager.AppSettings["AliyunAccessKeyId"];
        /// <summary>
        /// 阿里云AccessKeySecret
        /// </summary>
        public static string AliyunAccessKeySecret = ConfigurationManager.AppSettings["AliyunAccessKeySecret"];
        /// <summary>
        /// 阿里云签名
        /// </summary>
        public static string AliyunSignName = ConfigurationManager.AppSettings["AliyunSignName"];
    }
}
