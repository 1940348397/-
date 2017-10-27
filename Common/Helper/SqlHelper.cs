using System.Collections;
using System.Data;
using Common;
using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
using System.Data.SQLite;
using System;
using System.Diagnostics;
using System.Configuration;
using Common.Helper.SqlOpertion;
using System.Collections.Generic;
using System.Linq;

namespace Common.Helper
{
    public static class SqlHelperExt
    {
        public static int AddRange(this IDataParameterCollection coll, IDataParameter[] par)
        {
            int i = 0;
            foreach (var item in par)
            {
                coll.Add(item);
                i++;
            }
            return i;
        }
    }

    #region CreateSql必要参数
    public enum DateBaseType
    {
        //Oracle,SqlServer,MySql,Access,SqlLite
        NONE,
        ORACLE,
        SQLSERVER,
        MYSQL,
        ACCESS,
        SQLLITE
    }

    public class DBFactory
    {
        /// <summary>
        /// 建立Sql参数
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IDbDataParameter CreateDbSqlParameter(DateBaseType type)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            IDbDataParameter parameter = null;
            switch (type)
            {
                case DateBaseType.ORACLE:
                    parameter = new OracleParameter();
                    break;
                case DateBaseType.SQLSERVER:
                    parameter = new SqlParameter();
                    break;
                case DateBaseType.MYSQL:
                    parameter = new MySqlParameter();
                    break;
                case DateBaseType.ACCESS:
                    parameter = new OleDbParameter();
                    break;
                case DateBaseType.SQLLITE:
                    parameter = new SQLiteParameter();
                    break;
                case DateBaseType.NONE:
                    throw new Exception("未设置数据库类型");
                default:
                    throw new Exception("不支持该数据库类型");
            }
            sw.Stop();
            var a = sw.ElapsedMilliseconds;
            return parameter;
        }
        /// <summary>
        /// 建立SQL连接
        /// </summary>
        /// <param name="type"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IDbConnection CreateDbConnection(DateBaseType type, string connectionString)
        {
            IDbConnection conn = null;
            switch (type)
            {
                case DateBaseType.ORACLE:
                    conn = new OracleConnection(connectionString);
                    break;
                case DateBaseType.SQLSERVER:
                    conn = new SqlConnection(connectionString);
                    break;
                case DateBaseType.MYSQL:
                    conn = new MySqlConnection(connectionString);
                    break;
                case DateBaseType.ACCESS:
                    conn = new OleDbConnection(connectionString);
                    break;
                case DateBaseType.SQLLITE:
                    conn = new SQLiteConnection(connectionString);
                    break;
                case DateBaseType.NONE:
                    throw new Exception("未设置数据库类型");
                default:
                    throw new Exception("不支持该数据库类型");
            }
            return conn;
        }
        /// <summary>
        /// 建立Sql命令
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IDbCommand CreateDbCommand(DateBaseType type)
        {
            IDbCommand cmd = null;
            switch (type)
            {
                case DateBaseType.ORACLE:
                    cmd = new OracleCommand();
                    break;
                case DateBaseType.SQLSERVER:
                    cmd = new SqlCommand();
                    break;
                case DateBaseType.MYSQL:
                    cmd = new MySqlCommand();
                    break;
                case DateBaseType.ACCESS:
                    cmd = new OleDbCommand();
                    break;
                case DateBaseType.SQLLITE:
                    cmd = new SQLiteCommand();
                    break;
                case DateBaseType.NONE:
                    throw new Exception("未设置数据库类型");
                default:
                    throw new Exception("不支持该数据库类型");
            }
            return cmd;
        }
        /// <summary>
        /// 建立Sql命令
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IDbCommand CreateDbCommand(string sql, IDbConnection conn)
        {
            DateBaseType type = DateBaseType.NONE;
            if (conn is OracleConnection)
                type = DateBaseType.ORACLE;
            else if (conn is SqlConnection)
                type = DateBaseType.SQLSERVER;
            else if (conn is MySqlConnection)
                type = DateBaseType.MYSQL;
            else if (conn is OleDbConnection)
                type = DateBaseType.ACCESS;
            else if (conn is SQLiteConnection)
                type = DateBaseType.SQLLITE;

            IDbCommand cmd = null;
            switch (type)
            {
                case DateBaseType.ORACLE:
                    cmd = new OracleCommand(sql, (OracleConnection)conn);
                    break;
                case DateBaseType.SQLSERVER:
                    cmd = new SqlCommand(sql, (SqlConnection)conn);
                    break;
                case DateBaseType.MYSQL:
                    cmd = new MySqlCommand(sql, (MySqlConnection)conn);
                    break;
                case DateBaseType.ACCESS:
                    cmd = new OleDbCommand(sql, (OleDbConnection)conn);
                    break;
                case DateBaseType.SQLLITE:
                    cmd = new SQLiteCommand(sql, (SQLiteConnection)conn);
                    break;
                case DateBaseType.NONE:
                    throw new Exception("未设置数据库类型");
                default:
                    throw new Exception("不支持该数据库类型");
            }
            return cmd;
        }

        /// <summary>
        /// 建立Sql命令
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IDbTransaction CreateTransaction(IDbConnection conn)
        {
            DateBaseType type = DateBaseType.NONE;
            if (conn is OracleConnection)
                type = DateBaseType.ORACLE;
            else if (conn is SqlConnection)
                type = DateBaseType.SQLSERVER;
            else if (conn is MySqlConnection)
                type = DateBaseType.MYSQL;
            else if (conn is OleDbConnection)
                type = DateBaseType.ACCESS;
            else if (conn is SQLiteConnection)
                type = DateBaseType.SQLLITE;
            IDbTransaction tran = null;
            switch (type)
            {
                case DateBaseType.ORACLE:
                    {
                        OracleConnection connection = conn as OracleConnection;
                        tran = connection.BeginTransaction(IsolationLevel.RepeatableRead);
                    }
                    break;
                case DateBaseType.SQLSERVER:
                    {
                        SqlConnection connection = conn as SqlConnection;
                        tran = connection.BeginTransaction(IsolationLevel.RepeatableRead);
                    }
                    break;
                case DateBaseType.MYSQL:
                    {
                        MySqlConnection connection = conn as MySqlConnection;
                        tran = connection.BeginTransaction(IsolationLevel.RepeatableRead);
                    }
                    break;
                case DateBaseType.ACCESS:
                    {
                        OleDbConnection connection = conn as OleDbConnection;
                        tran = connection.BeginTransaction(IsolationLevel.RepeatableRead);
                    }
                    break;
                case DateBaseType.SQLLITE:
                    {
                        SQLiteConnection connection = conn as SQLiteConnection;
                        tran = connection.BeginTransaction(IsolationLevel.RepeatableRead);
                    }
                    break;
                case DateBaseType.NONE:
                    throw new Exception("未设置数据库类型");
                default:
                    throw new Exception("不支持该数据库类型");
            }
            return tran;
        }
    }
    #endregion

    public static class SqlHelper
    {
        private static Dictionary<string, SqlOpertionHelper> OracleHelperDic = new Dictionary<string, SqlOpertionHelper>();
        private static Dictionary<string, SqlOpertionHelper> SqlServerHelperDic = new Dictionary<string, SqlOpertionHelper>();
        private static Dictionary<string, SqlOpertionHelper> MySqlHelperDic = new Dictionary<string, SqlOpertionHelper>();
        private static Dictionary<string, SqlOpertionHelper> SqliteHelperDic = new Dictionary<string, SqlOpertionHelper>();
        private static Dictionary<string, SqlOpertionHelper> AccessHelperDic = new Dictionary<string, SqlOpertionHelper>();
        private static object LockObj = new object();

        /// <summary>
        /// 获得Oracle帮助类
        /// </summary>
        /// <returns></returns>
        public static SqlOpertionHelper GetOracleHelper(string KeyLock)
        {
            var Key = KeyLock.ToString();
            var OracleHelper = OracleHelperDic.Where(p => p.Key == Key).FirstOrDefault().Value;
            if (OracleHelper == null)
            {
                lock (LockObj)
                {
                    OracleHelper = OracleHelperDic.Where(p => p.Key == Key).FirstOrDefault().Value;
                    if (OracleHelper == null)
                    {
                        string sqlConnString = ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;
                        OracleHelper = new SqlOpertionHelper(sqlConnString, DateBaseType.ORACLE);
                        OracleHelperDic.Add(Key, OracleHelper);
                    }
                }
            }
            return OracleHelper;
        }

        /// <summary>
        /// 获得SqlServer帮助类
        /// </summary>
        public static SqlOpertionHelper GetSqlServerHelper(string KeyLock)
        {
            var Key = KeyLock.ToString();
            var SqlServerHelper = SqlServerHelperDic.Where(p => p.Key == Key).FirstOrDefault().Value;
            if (SqlServerHelper == null)
            {
                lock (LockObj)
                {
                    SqlServerHelper = SqlServerHelperDic.Where(p => p.Key == Key).FirstOrDefault().Value;
                    if (SqlServerHelper == null)
                    {
                        string sqlConnString = ConfigurationManager.ConnectionStrings["SqlServerConn"].ConnectionString;
                        SqlServerHelper = new SqlOpertionHelper(sqlConnString, DateBaseType.SQLSERVER);
                        SqlServerHelperDic.Add(Key, SqlServerHelper);
                    }
                }
            }
            return SqlServerHelper;
        }

        /// <summary>
        /// 获得MySql帮助类
        /// </summary>
        /// <returns></returns>
        public static SqlOpertionHelper GetMySqlHelper(string KeyLock)
        {
            var Key = KeyLock.ToString();
            var MySqlHelper = MySqlHelperDic.Where(p => p.Key == Key).FirstOrDefault().Value;
            if (MySqlHelper == null)
            {
                lock (LockObj)
                {
                    MySqlHelper = MySqlHelperDic.Where(p => p.Key == Key).FirstOrDefault().Value;
                    if (MySqlHelper == null)
                    {
                        string sqlConnString = ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;
                        MySqlHelper = new SqlOpertionHelper(sqlConnString, DateBaseType.MYSQL);
                        MySqlHelperDic.Add(Key, MySqlHelper);
                    }
                }
            }
            return MySqlHelper; ;
        }

        /// <summary>
        /// 获得Access帮助类
        /// </summary>
        /// <returns></returns>
        public static SqlOpertionHelper GetAccessHelper(string KeyLock)
        {
            var Key = KeyLock.ToString();
            var AccessHelper = AccessHelperDic.Where(p => p.Key == Key).FirstOrDefault().Value;
            if (AccessHelper == null)
            {
                lock (LockObj)
                {
                    AccessHelper = AccessHelperDic.Where(p => p.Key == Key).FirstOrDefault().Value;
                    if (AccessHelper == null)
                    {
                        string sqlConnString = ConfigurationManager.ConnectionStrings["AccessConn"].ConnectionString;
                        AccessHelper = new SqlOpertionHelper(sqlConnString, DateBaseType.ACCESS);
                        AccessHelperDic.Add(Key, AccessHelper);
                    }
                }
            }
            return AccessHelper;
        }


        /// <summary>
        /// 获得Sqlite帮助类
        /// </summary>
        /// <returns></returns>
        public static SqlOpertionHelper GetSqliteHelper(string KeyLock)
        {
            var Key = KeyLock.ToString();
            var SqliteHelper = SqliteHelperDic.Where(p => p.Key == Key).FirstOrDefault().Value;
            if (SqliteHelper == null)
            {
                lock (LockObj)
                {
                    SqliteHelper = SqliteHelperDic.Where(p => p.Key == Key).FirstOrDefault().Value;
                    if (SqliteHelper == null)
                    {
                        string sqlConnString = ConfigurationManager.ConnectionStrings["SqliteConn"].ConnectionString;
                        SqliteHelper = new SqlOpertionHelper(sqlConnString, DateBaseType.SQLLITE);
                        SqliteHelperDic.Add(Key, SqliteHelper);
                    }
                }
            }
            return SqliteHelper;
        }
    }
}

namespace Common.Helper.SqlOpertion
{
    #region SqlHelper
    public class SqlOpertionHelper
    {
        private IDbConnection conn = null;
        private DateBaseType type = DateBaseType.SQLSERVER;

        #region 创建数据库连接
        public SqlOpertionHelper(string connectionString, DateBaseType data_type)
        {
            type = data_type;
            conn = DBFactory.CreateDbConnection(type, connectionString);
        }
        /// <summary>
        /// 更改连接字符串
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        public void SetConnectionString(string connectionString)
        {
            conn = DBFactory.CreateDbConnection(type, connectionString);
        }
        #endregion

        #region 创建参数
        /// <summary>
        /// 创建参数
        /// </summary>
        public IDbDataParameter GetParameter()
        {
            return DBFactory.CreateDbSqlParameter(type);
        }

        /// <summary>
        /// 创建事务
        /// </summary>
        public IDbTransaction GetTransaction(IDbConnection connection = null)
        {
            if (connection == null)
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                return DBFactory.CreateTransaction(conn);
            }
            else
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                return DBFactory.CreateTransaction(connection);
            }
        }

        /// <summary>
        /// 获得连接
        /// </summary>
        public IDbConnection GetConnection()
        {
            var connection = DBFactory.CreateDbConnection(type, conn.ConnectionString);
            return connection;
        }
        #endregion

        #region 判断并打开conn
        /// <summary>
        /// 判断并打开conn
        /// </summary>
        /// <returns></returns>
        public IDbConnection CreatConn()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        /// <summary>
        /// 判断并打开conn
        /// </summary>
        /// <returns></returns>
        public IDbConnection CreatConn(IDbConnection connection)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }

        #endregion

        #region 执行查询sql语句
        /// <summary>
        /// 执行查询sql语句
        /// </summary>
        /// <param name="sql">查询sql语句</param>
        /// <returns>返回一个表</returns>
        public DataTable ExecuteReader(string sql)
        {
            DataTable dt = new DataTable();
            using (var connection = DBFactory.CreateDbConnection(type, conn.ConnectionString))
            {
                connection.Open();
                using (var cmd = DBFactory.CreateDbCommand(sql, connection))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr);
                    }
                }
                connection.Close();
            }
            return dt;
        }

        /// <summary>
        /// 执行查询sql语句
        /// </summary>
        /// <param name="sql">查询sql语句</param>
        /// <returns>返回一个表</returns>
        public DataTable ExecuteReader(string sql, IDbConnection connection, IDbTransaction transaction)
        {
            DataTable dt = new DataTable();
            using (var cmd = DBFactory.CreateDbCommand(sql, CreatConn(connection)))
            {
                cmd.Transaction = transaction;
                using (var dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);
                }
            }
            return dt;
        }
        #endregion

        #region 执行查询带参的sql语句
        /// <summary>
        /// 执行查询带参的sql语句
        /// </summary>
        /// <param name="sql">查询sql语句</param>
        /// <param name="par">sql语句中的参数</param>
        /// <returns>返回一个表</returns>
        public DataTable ExecuteReader(string sql, IDataParameter[] par)
        {
            DataTable dt = new DataTable();
            using (var connection = DBFactory.CreateDbConnection(type, conn.ConnectionString))
            {
                connection.Open();
                using (var cmd = DBFactory.CreateDbCommand(sql, connection))
                {
                    cmd.Parameters.AddRange(par);
                    using (var dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr);
                    }
                }
                connection.Close();
            }
            return dt;
        }

        /// <summary>
        /// 执行查询带参的sql语句
        /// </summary>
        /// <param name="sql">查询sql语句</param>
        /// <param name="par">sql语句中的参数</param>
        /// <returns>返回一个表</returns>
        public DataTable ExecuteReader(string sql, IDataParameter[] par, IDbConnection connection, IDbTransaction transaction)
        {
            DataTable dt = new DataTable();
            using (var cmd = DBFactory.CreateDbCommand(sql, CreatConn(connection)))
            {
                cmd.Transaction = transaction;
                cmd.Parameters.AddRange(par);
                using (var dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);
                }
            }
            return dt;
        }
        #endregion
        #region 执行增，删，改sql语句
        /// <summary>
        /// 执行无参的增，删，改sql语句
        /// </summary>
        /// <param name="sql">增，删，改的sql语句</param>
        /// <param name="par">sql语句中的参数</param>
        /// <returns>返回所影响的行数</returns>
        public int ExecuteNonQuery(string sql)
        {
            int result = 0;
            using (var connection = DBFactory.CreateDbConnection(type, conn.ConnectionString))
            {
                connection.Open();
                using (var cmd = DBFactory.CreateDbCommand(sql, connection))
                {
                    result = cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
            return result;
        }

        public int ExecuteNonQuery(string sql, IDbConnection connection, IDbTransaction transaction)
        {
            int result = 0;
            using (var cmd = DBFactory.CreateDbCommand(sql, CreatConn(connection)))
            {
                cmd.Transaction = transaction;
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }
        #endregion

        #region 执行带参的增，删，改sql语句
        /// <summary>
        /// 执行带参的增，删，改sql语句
        /// </summary>
        /// <param name="sql">增，删，改的sql语句</param>
        /// <param name="par">sql语句中的参数</param>
        /// <returns>返回所影响的行数</returns>
        public int ExecuteNonQuery(string sql, IDbDataParameter[] par)
        {
            int result = 0;
            using (var connection = DBFactory.CreateDbConnection(type, conn.ConnectionString))
            {
                connection.Open();
                using (var cmd = DBFactory.CreateDbCommand(sql, connection))
                {
                    cmd.Parameters.AddRange(par);
                    result = cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
            return result;
        }

        public int ExecuteNonQuery(string sql, IDbDataParameter[] par, IDbConnection connection, IDbTransaction transaction)
        {
            int result = 0;
            using (var cmd = DBFactory.CreateDbCommand(sql, CreatConn(connection)))
            {
                cmd.Transaction = transaction;
                cmd.Parameters.AddRange(par);
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }
        #endregion

    }
    #endregion
}