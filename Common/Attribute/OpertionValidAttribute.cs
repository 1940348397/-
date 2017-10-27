using System.ComponentModel.DataAnnotations;
using Common.Enum_My;

namespace Common.Attribute
{
    /// <summary>
    /// 操作验证
    /// </summary>
    public class OpertionValidAttribute : ValidationAttribute
    {
        /// <summary>
        /// 删除
        /// </summary>
        public bool Delete { get; set; }
        /// <summary>
        /// 插入
        /// </summary>
        public bool Insert { get; set; }
        /// <summary>
        /// 修改
        /// </summary>
        public bool Update { get; set; }
        public override bool IsValid(object value)
        {
            bool flag = true;
            if (value == null)
            {
                return false;
            }
            if (Delete)
            {
                if (value.ToString().ToLower() == Enum_Opertion.Delete.Enum_GetString())
                {
                    flag = false;
                }
            }
            if (Insert)
            {
                if (value.ToString().ToLower() == Enum_Opertion.Insert.Enum_GetString())
                {
                    flag = false;
                }
            }
            if (Update)
            {
                if (value.ToString().ToLower() == Enum_Opertion.Update.Enum_GetString())
                {
                    flag = false;
                }
            }
            if (flag)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
