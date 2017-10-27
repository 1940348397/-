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
    public class LambdaUpdate<T> : LambdaBase<T> where T : class, new()
    {
        public LambdaUpdate() : base()
        {

        }

        public LambdaUpdate(SqlOpertionHelper helper) : base(helper)
        {

        }

        /// <summary>
        /// where条件
        /// </summary>
        protected List<string> SetCondition = new List<string>();

        public LambdaUpdate<T> Where(Expression<Func<T, bool>> expression)
        {
            if (expression == null)
                return this;
            string condition = FormatExpression(expression);
            WhereCondition.Add(condition);
            return this;
        }

        public LambdaUpdate<T> Set(Expression<Func<T, bool>> expression)
        {
            if (expression == null)
                return this;
            string condition = FormatSetExpression(expression);
            SetCondition.Add(condition);
            return this;
        }

        private string GetUpdateSql()
        {
            string tableName = typeof(T).Name;
            StringBuilder WhereBulider = new StringBuilder();
            StringBuilder SetBulider = new StringBuilder();
            #region
            if (SetCondition.Count > 0)
            {
                foreach (var item in SetCondition)
                {
                    SetBulider.Append(item).Append(",");
                }
                SetBulider.Remove(SetBulider.Length - 1, 1);
            }
            else
            {
                return null;
            }
            #endregion
            #region Where条件
            if (WhereCondition.Count > 0)
            {
                foreach (var item in WhereCondition)
                {
                    WhereBulider.Append(item).Append(" and ");
                }
                WhereBulider.Remove(WhereBulider.Length - 5, 5);
            }
            else
            {
                return null;
            }
            #endregion
            var sql = string.Format("update {0} set {1} where {2}", tableName, SetBulider.ToString(), WhereBulider.ToString());
            return sql;
        }

        public bool GetUpdateResult(IDbConnection connection, IDbTransaction transaction = null)
        {
            string Sql = GetUpdateSql();
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
