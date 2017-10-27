using System.ComponentModel.DataAnnotations;

namespace Common.Attribute
{
    /// <summary>
    /// 操作验证
    /// </summary>
    public class OpertionAttribute : ValidationAttribute
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
            if (Delete)
            {
                if (value.ToString().ToLower() == "delete")
                {
                    flag = false;
                }
            }
            if (Insert)
            {
                if (value.ToString().ToLower() == "insert")
                {
                    flag = false;
                }
            }
            if (Update)
            {
                if (value.ToString().ToLower() == "update")
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
