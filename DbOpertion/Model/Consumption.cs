using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Consumption
    {
        /// <summary>
        ///
        /// </summary>
        public Int32 ConsumptionId { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Int32? StoreId { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Int32? ElectronicId { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Int32? UserId { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String ShopName { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Decimal? ShopMoney { get; set; }
        /// <summary>
        ///
        /// </summary>
        public DateTime? ShopTime { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Int32? ShopType { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Boolean? IsDelete { get; set; }
        /// <summary>
        /// 获取对应主键
        /// </summary>
        public string GetBuilderPrimaryKey()
        {
            return "ConsumptionId";
        }

    }
}
