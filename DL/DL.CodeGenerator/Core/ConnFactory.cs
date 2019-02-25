using DL.CodeGenerator.Models;
using DL.Common.Strings;
using MySql.Data.MySqlClient;
//using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DL.CodeGenerator.Core
{
    public class ConnFactory
    {
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="dbtype">数据库类型</param>
        /// <param name="conStr">数据库连接字符串</param>
        /// <returns>数据库连接</returns>
        public static IDbConnection CreateConnection(string dbtype, string strConn)
        {
            if (dbtype.IsNullOrWhiteSpace())
                throw new ArgumentNullException("数据库类型为空!");
            if (strConn.IsNullOrWhiteSpace())
                throw new ArgumentNullException("数据库连接字符串为空!");
            var dbType = GetDBType(dbtype);
            return CreateConnection(dbType, strConn);
        }

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="conStr">数据库连接字符串</param>
        /// <returns>数据库连接</returns>
        public static IDbConnection CreateConnection(DBType dbType, string strConn)
        {
            IDbConnection connection = null;
            if (strConn.IsNullOrWhiteSpace())
                throw new ArgumentNullException("数据库连接字符串为空!");

            switch (dbType)
            {
                case DBType.SqlServer:
                    connection = new SqlConnection(strConn);
                    break;
                case DBType.MySQL:
                    connection = new MySqlConnection(strConn);
                    break;
                case DBType.PostgreSQL:
                    //connection = new NpgsqlConnection(strConn);
                    break;
                default:
                    throw new ArgumentNullException($"暂不支持的{dbType.ToString()}数据库类型");

            }
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }

        /// <summary>
        /// 转换数据库类型
        /// </summary>
        /// <param name="dbtype">数据库类型字符串</param>
        /// <returns>数据库类型</returns>
        public static DBType GetDBType(string dbtype)
        {
            if (dbtype.IsNullOrWhiteSpace())
                throw new ArgumentNullException("数据库类型为空!");
            DBType returnValue = DBType.SqlServer;
            foreach (DBType dbType in Enum.GetValues(typeof(DBType)))
            {
                if (dbType.ToString().Equals(dbtype, StringComparison.OrdinalIgnoreCase))
                {
                    returnValue = dbType;
                    break;
                }
            }
            return returnValue;
        }
    }
}
