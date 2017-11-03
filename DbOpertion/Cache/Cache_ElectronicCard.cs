using Common;
using Common.Result;
using DbOpertion.Models;
using DbOpertion.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.Cache
{
    public partial class Cache_ElectronicCard : SingleTon<Cache_ElectronicCard>
    {
        /// <summary>
        /// 根据电子卡类型Id查找对应的卡片信息
        /// </summary>
        /// <param name="ElectronicTypeId">电子卡类型Id</param>
        /// <param name="SearchKey">搜索关键字</param>
        /// <param name="Key">主键</param>
        /// <param name="start">开始数据</param>
        /// <param name="pageSize">页面长度</param>
        /// <param name="desc">排序</param>
        /// <returns></returns>
        public Tuple<List<ElectronicCardInfo>, int, int> SelectElectronicCardList(int ElectronicTypeId, string SearchKey, string Key, int start, int pageSize, DataTablesOrderDir desc)
        {

            bool asc;
            if (desc == DataTablesOrderDir.Asc)
            {
                asc = true;
            }
            else
            {
                asc = false;

            }
            var list = ElectronicCardOper.Instance.Get_ElectronicCardByTypeId(ElectronicTypeId, SearchKey, Key, start, pageSize, asc);
            var All_Count = ElectronicCardOper.Instance.SelectSearchCount(ElectronicTypeId, null);
            var Count = ElectronicCardOper.Instance.SelectSearchCount(ElectronicTypeId, SearchKey);
            return new Tuple<List<ElectronicCardInfo>, int, int>(list, All_Count, Count);

        }
    }
}
