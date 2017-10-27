using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Result
{
    /// <summary>
    /// datatable的返回类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataTableResponse<T>
    {
        /// <summary>
        /// DataTable请求服务器端次数
        /// </summary>
        public int draw { get; set; }
        /// <summary>
        /// 总共记录条数
        /// </summary>
        public int recordsTotal { get; set; }
        /// <summary>
        /// 筛选后的记录条数
        /// </summary>
        public int recordsFiltered { get; set; }
        /// <summary>
        /// 列表
        /// </summary>
        public List<T> data { get; set; }
        /// <summary>
        /// 获得
        /// </summary>
        /// <returns></returns>
        public object GetObject()
        {
            return (object)this;
        }
    }

    /// <summary>
    /// datatable的请求类型
    /// </summary>
    public class DataTableRequest
    {
        /// <summary>
        ///     请求次数计数器
        /// </summary>
        public int Draw { get; set; }

        /// <summary>
        ///     第一条数据的起始位置
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        ///     每页显示的数据条数
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        ///     数据列
        /// </summary>
        public List<DataTablesColumns> Columns { get; set; }

        /// <summary>
        ///     排序
        /// </summary>
        public List<DataTablesOrder> Order { get; set; }

        /// <summary>
        ///     搜索
        /// </summary>
        public DataTablesSearch Search { get; set; }

        /// <summary>
        ///  搜索关键字
        /// </summary>
        public string SearchKey { get; set; }

        /// <summary>
        ///     排序字段
        /// </summary>
        public string OrderBy
        {
            get
            {
                return Columns != null && Columns.Any() && Order != null && Order.Any()
                    ? Columns[Order[0].Column].Data
                    : string.Empty;
            }
        }

        /// <summary>
        ///     排序模式
        /// </summary>
        public DataTablesOrderDir OrderDir
        {
            get
            {
                return Order != null && Order.Any()
                    ? Order[0].Dir
                    : DataTablesOrderDir.Desc;
            }
        }
    }

    /// <summary>
    ///     排序
    /// </summary>
    public class DataTablesOrder
    {
        /// <summary>
        ///     排序的列的索引
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        ///     排序模式
        /// </summary>
        public DataTablesOrderDir Dir { get; set; }
    }

    /// <summary>
    ///     排序模式
    /// </summary>
    public enum DataTablesOrderDir
    {
        /// <summary>
        ///     正序
        /// </summary>
        Asc,

        /// <summary>
        ///     倒序
        /// </summary>
        Desc
    }

    /// <summary>
    ///     数据列
    /// </summary>
    public class DataTablesColumns
    {
        /// <summary>
        ///     数据源
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        ///     名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     是否可以被搜索
        /// </summary>
        public bool Searchable { get; set; }

        /// <summary>
        ///     是否可以排序
        /// </summary>
        public bool Orderable { get; set; }

        /// <summary>
        ///     搜索
        /// </summary>
        public DataTablesSearch Search { get; set; }
    }

    /// <summary>
    ///     搜索
    /// </summary>
    public class DataTablesSearch
    {
        /// <summary>
        ///     全局的搜索条件的值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        ///     是否为正则表达式处理
        /// </summary>
        public bool Regex { get; set; }
    }
}
