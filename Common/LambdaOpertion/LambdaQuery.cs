using Common.Helper.SqlOpertion;
using Common.LambdaOpertion.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using Common.Extend;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Common.LambdaOpertion
{
    /// <summary>
    /// Lambda查询
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LambdaQuery<T> : LambdaBase<T> where T : class, new()
    {
        public LambdaQuery() : base()
        {

        }

        public LambdaQuery(SqlOpertionHelper helper) : base(helper)
        {

        }
        /// <summary>
        /// 查询字段
        /// </summary>
        private List<string> QueryFields = new List<string>();
        /// <summary>
        /// 排序字段
        /// </summary>
        private List<string> OrderByFields = new List<string>();
        /// <summary>
        /// 分组字段
        /// </summary>
        private List<string> GroupByFields = new List<string>();

        public LambdaQuery<T> Select<TResult>(Expression<Func<T, TResult>> resultSelector)
        {
            string queryFullName = "";
            //转换为匿名对象表达式
            var newExpression = resultSelector.Body as NewExpression;
            int i = 0;
            //遍历所有参数
            foreach (var item in newExpression.Arguments)
            {
                //如果是静态方法
                if (item is MethodCallExpression)
                {
                    //获取构造的属性名
                    var memberName = newExpression.Members[i].Name;
                    string methodName;
                    string propertyName = GetPropertyMethod(item, out methodName);//获取方法名和属性名
                    queryFullName = string.Format("{0}({1}) as {2}", methodName, propertyName, memberName);
                }
                //直接属性
                else
                {
                    var memberExpression = item as MemberExpression;
                    if (memberExpression == null)
                    {
                        continue;
                    }
                    queryFullName = memberExpression.Member.Name;//返回属性名
                }
                QueryFields.Add(queryFullName);
            }
            return this;
        }

        public LambdaQuery<T> GroupBy<TResult>(Expression<Func<T, TResult>> resultSelector)
        {
            foreach (var item in (resultSelector.Body as NewExpression).Arguments)
            {
                var memberExpression = item as MemberExpression;
                GroupByFields.Add(memberExpression.Member.Name);
            }
            return this;
        }

        public LambdaQuery<T> OrderBy<TKey>(Expression<Func<T, TKey>> expression, bool desc = true)
        {
            string orderBy = "";
            string name;
            if (expression.Body is MethodCallExpression)//如果是方法
            {
                string methodName;
                string propertyName = GetPropertyMethod(expression.Body, out methodName);
                name = string.Format("{1}({0})", propertyName, methodName);
                orderBy = string.Format(" {0} {1}", name, desc ? "desc" : "asc");
            }
            else
            {
                MemberExpression mExp = (MemberExpression)expression.Body;
                if (!string.IsNullOrEmpty(orderBy))
                {
                    orderBy += ",";
                }
                name = mExp.Member.Name;
                orderBy = string.Format(" {0} {1}", name, desc ? "desc" : "asc");
            }
            OrderByFields.Add(orderBy);
            return this;
        }

        public LambdaQuery<T> OrderByKey(string Key, bool desc = true)
        {
            string orderBy = "";
            if (!string.IsNullOrEmpty(orderBy))
            {
                orderBy += ",";
            }
            orderBy = string.Format(" {0} {1}", Key, desc ? "desc" : "asc");
            OrderByFields.Add(orderBy);
            return this;
        }

        public LambdaQuery<T> Where(Expression<Func<T, bool>> expression)
        {
            if (expression == null)
                return this;
            string condition = FormatExpression(expression);
            WhereCondition.Add(condition);
            return this;
        }

        /// <summary>
        /// 获得查询Sql
        /// </summary>
        /// <returns></returns>
        private string GetQuerySql()
        {
            StringBuilder WhereBulider = new StringBuilder();
            #region Where条件
            if (WhereCondition.Count > 0)
            {
                foreach (var item in WhereCondition)
                {
                    WhereBulider.Append(item).Append(" and ");
                }
                WhereBulider.Remove(WhereBulider.Length - 5, 4);
            }
            else
            {
                WhereBulider.Append(" 1=1 ");
            }
            #endregion
            #region group判断
            if (GroupByFields.Count > 0)
            {
                WhereBulider.Append(" group by ");
                foreach (var item in GroupByFields)
                {
                    WhereBulider.Append(item).Append(",");
                }
                WhereBulider.Remove(WhereBulider.Length - 1, 1);
            }
            #endregion
            #region order判断
            if (OrderByFields.Count > 0)
            {
                WhereBulider.Append(" order by ");
                foreach (var item in OrderByFields)
                {
                    WhereBulider.Append(item).Append(",");
                }
                WhereBulider.Remove(WhereBulider.Length - 1, 1);
            }
            #endregion
            string tableName = typeof(T).Name;
            string fileds = null;
            if (QueryFields.Count == 0)
            {
                fileds = "*";
            }
            else
            {
                fileds = string.Join(",", QueryFields);
            }

            var sql = string.Format("select {0} from {1}  where {2}", fileds, tableName, WhereBulider.ToString());

            return sql;
        }

        /// <summary>
        /// 获得查询Sql
        /// </summary>
        /// <returns></returns>
        private string GetQueryCount()
        {
            StringBuilder WhereBulider = new StringBuilder();
            #region Where条件
            if (WhereCondition.Count > 0)
            {
                foreach (var item in WhereCondition)
                {
                    WhereBulider.Append(item).Append(" and ");
                }
                WhereBulider.Remove(WhereBulider.Length - 5, 4);
            }
            else
            {
                WhereBulider.Append(" 1=1 ");
            }
            #endregion
            string tableName = typeof(T).Name;
            string fileds = "count(*)";
            var sql = string.Format("select {0} from {1}  where {2}", fileds, tableName, WhereBulider.ToString());

            return sql;
        }

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="Start">开始条数</param>
        /// <param name="pageSize">页面长度</param>
        /// <returns></returns>
        private string GetQuerySqlByPage(int start, int pageSize)
        {
            StringBuilder WhereBulider = new StringBuilder();
            IDbDataParameter parameter = SqlHelper.GetParameter();
            #region Where条件
            if (WhereCondition.Count > 0)
            {
                foreach (var item in WhereCondition)
                {
                    WhereBulider.Append(item).Append(" and ");
                }
                WhereBulider.Remove(WhereBulider.Length - 5, 4);
            }
            else
            {
                WhereBulider.Append(" 1=1 ");
            }
            #endregion
            #region group判断
            if (GroupByFields.Count > 0)
            {
                WhereBulider.Append(" group by ");
                foreach (var item in GroupByFields)
                {
                    WhereBulider.Append(item).Append(",");
                }
                WhereBulider.Remove(WhereBulider.Length - 1, 1);
            }
            #endregion
            #region order判断
            if (OrderByFields.Count > 0)
            {
                WhereBulider.Append(" order by ");
                foreach (var item in OrderByFields)
                {
                    WhereBulider.Append(item).Append(",");
                }
                WhereBulider.Remove(WhereBulider.Length - 1, 1);
            }
            #endregion
            if (parameter is SqlParameter)
            {
                string tableName = typeof(T).Name;
                string fileds = null;
                if (QueryFields.Count == 0)
                {
                    fileds = "*";
                }
                else
                {
                    fileds = string.Join(",", QueryFields);
                }
                var sql = string.Format("select * from( select row_number()over(order by tempcolumn)temprownumber, * from(select top {0} tempcolumn=0,{1} from {2} where {3})t)tt where temprownumber>{4}", start + pageSize, fileds, tableName, WhereBulider.ToString(), start);

                return sql;
            }
            else if (parameter is MySqlParameter)
            {
                string tableName = typeof(T).Name;
                string fileds = null;
                if (QueryFields.Count == 0)
                {
                    fileds = "*";
                }
                else
                {
                    fileds = string.Join(",", QueryFields);
                }

                var sql = string.Format("select {0} from {1}  where {2} Limit {3},{4}", fileds, tableName, WhereBulider.ToString(), start, pageSize);
                return sql;
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// 获得查询列表
        /// </summary>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        public List<T> GetQueryList(IDbConnection connection = null, IDbTransaction transaction = null)
        {
            string Sql = GetQuerySql();
            DataTable table;
            if (transaction == null)
            {
                table = SqlHelper.ExecuteReader(Sql, List_SqlParameter.ToArray());
            }
            else
            {
                table = SqlHelper.ExecuteReader(Sql, List_SqlParameter.ToArray(), connection, transaction);
            }
            return table.ConvertToList<T>();
        }

        /// <summary>
        /// 获得查询列表
        /// </summary>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        public int GetQueryCount(IDbConnection connection = null, IDbTransaction transaction = null)
        {
            string Sql = GetQueryCount();
            DataTable table;
            if (transaction == null)
            {
                table = SqlHelper.ExecuteReader(Sql, List_SqlParameter.ToArray());
            }
            else
            {
                table = SqlHelper.ExecuteReader(Sql, List_SqlParameter.ToArray(), connection, transaction);
            }
            return (int)table.Rows[0][0];
        }

        /// <summary>
        /// 获得查询列表
        /// </summary>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        public List<T> GetQueryPageList(int start, int PageSize, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            string Sql = GetQuerySqlByPage(start, PageSize);
            DataTable table;
            if (transaction == null)
            {
                table = SqlHelper.ExecuteReader(Sql, List_SqlParameter.ToArray());
            }
            else
            {
                table = SqlHelper.ExecuteReader(Sql, List_SqlParameter.ToArray(), connection, transaction);
            }
            return table.ConvertToList<T>();
        }

    }
}
