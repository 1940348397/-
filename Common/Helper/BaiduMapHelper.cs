using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    /// <summary>
    /// 百度地图帮助类
    /// </summary>
    public class BaiduMapHelper : SingleTon<BaiduMapHelper>
    {
        private string BaiDuAK = ConfigurationManager.AppSettings["BaiDuAK"];
        
        /// <summary>
        /// 计算距离
        /// </summary>
        /// <param name="longitude1">经度1</param>
        /// <param name="latitude1">纬度1</param>
        /// <param name="longitude2">经度2</param>
        /// <param name="latitude2">纬度2</param>
        /// <returns></returns>
        public double getDistance(double longitude1, double latitude1, double longitude2, double latitude2)
        {
            
            // 维度
            double lat1 = (Math.PI / 180) * latitude1;
            double lat2 = (Math.PI / 180) * latitude2;
            // 经度
            double lon1 = (Math.PI / 180) * longitude1;
            double lon2 = (Math.PI / 180) * longitude2;
            // 地球半径
            double R = 6371;
            // 两点间距离 km，如果想要米的话，结果*1000就可以了
            double d = Math.Acos(Math.Sin(lat1) * Math.Sin(lat2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(lon2 - lon1)) * R;
            return d * 1000;
        }

        /// <summary>
        /// 使用Get方式进行异步通信
        /// </summary>
        public async void GET_HttpClient(string url)
        {
            var responseString = await url.GetStringAsync();
        }

        /// <summary>
        /// 使用Post方式进行异步通信
        /// </summary>
        public async void Post_HttpClient(string url, object data)
        {
            var responseString = await url.PostUrlEncodedAsync(data).ReceiveString();
        }
    }
}
