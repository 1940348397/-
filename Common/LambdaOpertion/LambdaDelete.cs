using Common.Helper.SqlOpertion;
using Common.LambdaOpertion.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;


namespace Common.LambdaOpertion
{
    /// <summary>
    /// Lambda查询
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LambdaDelete<T> : LambdaBase<T> where T : class, new()
    {
        public LambdaDelete() : base()
        {

        }

        public LambdaDelete(SqlOpertionHelper helper) : base(helper)
        {

        }

        public LambdaDelete<T> Where(Expression<Func<T, bool>> expression)
        {
            if (expression == null)
                return this;
            string condition = FormatExpression(expression);
            WhereCondition.Add(condition);
            return this;
        }

        private string GetDeleteSql()
        {
            string tableName = typeof(T).Name;
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
                return null;
            }
            #endregion
            var sql = string.Format("delete from {0}  where {1}", tableName, WhereBulider.ToString());
            return sql;
        }

        public bool GetDeleteResult(IDbConnection connection = null, IDbTransaction transaction = null)
        {
            string Sql = GetDeleteSql();
            int Count = 0;
            if (Sql != null)
            {
                if (transaction == null)
                {
                    Count = SqlHelper.ExecuteNonQuery(Sql, List_SqlParameter.ToArray());
                }
                else
                {
                    Count = SqlHelper.ExecuteNonQuery(Sql, List_SqlParameter.ToArray(), connection, transaction);
                }

            }
            return Count > 0;
        }

    }
}
