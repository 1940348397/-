using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class CouponCardRelation
    {
        /// <summary>
        ///
        /// </summary>
        public Int32 CouponCardRelationId { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Int32? MemberShipTypeId { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Int32? CouponId { get; set; }
        /// <summary>
        /// 获取对应主键
        /// </summary>
        public string GetBuilderPrimaryKey()
        {
            return "CouponCardRelationId";
        }

    }
}
