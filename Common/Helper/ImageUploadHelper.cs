using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common.Helper
{
    public class ImageUploadHelper : SingleTon<ImageUploadHelper>
    {

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="Content"></param>
        /// <returns></returns>
        public Dictionary<string, string> ReadAsMultipart(HttpContent Content)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string root = HttpContext.Current.Server.MapPath("~/Content/UserImage");//指定要将文件存入的服务器物理位置
            dic.Add("path", root);
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);//创建该文件
            }
            return dic;
        }

        //解析base64编码获取图片
        public Bitmap Base64ToImg(string base64Code)
        {
            MemoryStream stream = new MemoryStream(Convert.FromBase64String(base64Code));
            return new Bitmap(stream);
        }
    }
}
