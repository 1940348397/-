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
    public class LambdaInsert<T> : LambdaBase<T> where T : class, new()
    {
        public LambdaInsert() : base()
        {

        }

        public LambdaInsert(SqlOpertionHelper helper) : base(helper)
        {

        }

        private List<string> InsertCondition = new List<string>();

        public LambdaInsert<T> Insert(Expression<Func<T, bool>> expression)
        {
            if (expression == null)
                return this;
            string condition = FormatSetExpression(expression);
            InsertCondition.Add(condition);
            return this;
        }

        private string GetInsertSql()
        {
            string tableName = typeof(T).Name;
            StringBuilder InsertBulider = new StringBuilder();
            StringBuilder ValuesBulider = new StringBuilder();
            #region Insert条件
            if (InsertCondition.Count > 0)
            {
                foreach (var condition in InsertCondition)
                {
                    var ConditionArray = condition.Split(',');
                    foreach (var item in ConditionArray)
                    {
                        var array = item.Split('=');
                        InsertBulider.Append(array[0]).Append(",");
                        ValuesBulider.Append(array[1]).Append(",");
                    }
                }
                InsertBulider.Remove(InsertBulider.Length - 1, 1);
                ValuesBulider.Remove(ValuesBulider.Length - 1, 1);
            }
            else
            {
                return null;
            }
            #endregion
            var sql = string.Format("Insert into {0} ({1}) values ({2})", tableName, InsertBulider.ToString(), ValuesBulider.ToString());
            return sql;
        }

        public bool GetInsertResult(IDbConnection connection = null, IDbTransaction transaction = null)
        {
            string Sql = GetInsertSql();
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
