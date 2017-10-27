using Common.Enum_My;
using Common.Helper.LambdaOpertion;
using Common.Helper.SqlOpertion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;

namespace Common.LambdaOpertion.Base
{
    public class LambdaBase<T> where T : class, new()
    {
        private static string SqlText = "SqlHelper";
        public LambdaBase()
        {
            SqlHelper = Common.Helper.SqlHelper.GetSqlServerHelper(SqlText);
        }

        public LambdaBase(SqlOpertionHelper helper)
        {
            SqlHelper = helper;
            SqlHelper.CreatConn();
        }

        /// <summary>
        /// where条件
        /// </summary>
        protected List<string> WhereCondition = new List<string>();
        /// <summary>
        /// 分组字段
        /// </summary>
        protected List<IDbDataParameter> List_SqlParameter = new List<IDbDataParameter>();

        protected SqlOpertionHelper SqlHelper = null;

        /// <summary>
        /// 获得方法名称
        /// </summary>
        /// <param name="item"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        protected string GetPropertyMethod(Expression item, out string methodName)
        {
            //转换为方法表达式
            var method = item as MethodCallExpression;
            MemberExpression memberExpression;            //获取访问属性表达式
            if (method.Arguments[0] is UnaryExpression)
            {
                memberExpression = (method.Arguments[0] as UnaryExpression).Operand as MemberExpression;
            }
            else
            {
                memberExpression = method.Arguments[0] as MemberExpression;
            }
            methodName = method.Method.Name;//调用的方法名
            return memberExpression.Member.Name;//返回访问的属性名
        }

        /// <summary>
        /// 序列化表达式
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        protected string FormatExpression(Expression<Func<T, bool>> expression)
        {
            string condition;
            if (expression == null)
                return "";
            condition = ExpressionAnalysis.Instance.RouteExpressionHandler(expression.Body, this.SqlHelper, Enum_Opertion.Where, ref List_SqlParameter);
            return condition;
        }

        /// <summary>
        /// 序列化表达式
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        protected string FormatSetExpression(Expression<Func<T, bool>> expression)
        {
            string condition;
            if (expression == null)
                return "";
            condition = ExpressionAnalysis.Instance.RouteExpressionHandler(expression.Body, this.SqlHelper, Enum_Opertion.Set, ref List_SqlParameter);
            return condition;
        }
    }
}

