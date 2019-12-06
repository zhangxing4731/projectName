using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReserve_DAL
{
    public class SqlHelper
    {
        private SqlConnection conn = null;
        private SqlCommand cmd = null;
        private SqlDataReader sdr = null;

        private static readonly string connString = ConfigurationManager.ConnectionStrings["T_HotelReserve"].ConnectionString;
        /// <summary>
        ///  查询数据  结果以填充表格的形式
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="type">类型</param>
        /// <param name="pars">参数</param>
        /// <returns></returns>
        public static DataTable GetTable(string sql, CommandType type, params SqlParameter[] pars)
        {

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlDataAdapter apter = new SqlDataAdapter(sql, conn))
                {
                    apter.SelectCommand.CommandType = type;
                    if (pars != null)
                    {
                        apter.SelectCommand.Parameters.AddRange(pars);
                    }
                    DataTable da = new DataTable();
                    apter.Fill(da);
                    return da;
                }
            }
        }

        /// <summary>
        /// 获取改变的行
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="type">类型</param>
        /// <param name="pars">参数</param>
        /// <returns></returns>
        public static int ExecuteNonquery(string sql, CommandType type)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = type;

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }

        }
        /// <summary>
        /// 获取改变的行带参数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int Execute(string sql, CommandType type)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = type;
                    conn.Open();
                    return cmd.ExecuteNonQuery();

                }
            }

        }
        public static object ExecuteScalare(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = type;
                    if (pars != null)
                    {
                        cmd.Parameters.AddRange(pars);
                    }
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }


        private SqlConnection GetConn()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }


        /// <summary>
        /// 执行不带参数的增删改查SQL语句或存储过程
        /// </summary>
        /// <param name="cmdText">不带参数的增删改查SQL语句或存储过程</param>
        /// <param name="ct">命令类型</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string cmdText, CommandType ct)
        {
            int res;
            using (cmd = new SqlCommand(cmdText, GetConn()))

            {
                cmd.CommandType = ct;
                res = cmd.ExecuteNonQuery();
            }
            return res;
        }
        /// <summary>
        /// 执行带参数的SQL增删改查或存储过程
        /// </summary>
        /// <param name="cmdText">参数的SQL增删改查或存储过程</param>
        /// <param name="paras">参数集合</param>
        /// <param name="ct">命令类型</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string cmdText, SqlParameter[] paras, CommandType ct)
        {
            int res;
            using (cmd = new SqlCommand(cmdText, GetConn()))
            {

                cmd.Parameters.AddRange(paras);
                cmd.CommandType = ct;
                res = cmd.ExecuteNonQuery();
            }
            return res;
        }

        /// <summary>
        /// 执行带参数的增删改SQL语句或存储过程
        /// </summary>
        /// <param name="sql">带参数的增删改SQL语句或存储过程</param>
        /// <param name="ct">命令类型</param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string cmdText, CommandType ct)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand(cmdText, GetConn());
            cmd.CommandType = ct;
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }
            return dt;
        }

        /// <summary>
        /// 判断 参数是否存在 读取数据库表 做登录 资料查询
        /// </summary>
        /// <param name="cmdText">带参数的SQL查询语句</param>
        /// <param name="paras">参数集合</param>
        /// <param name="ct">执行类型</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteQuery(string cmdText, SqlParameter[] paras, CommandType ct)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand(cmdText, GetConn());
            cmd.Parameters.AddRange(paras);
            cmd.CommandType = ct;
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                if (sdr.Read())
                {
                    //返回数据库指定的列
                    int ID = Convert.ToInt32(sdr.GetString(0));

                }
                dt.Load(sdr);
            }
            return dt;
        }
        /// <summary>
        /// ExecuteScalar--返回首行首列 
        /// </summary>
        /// <param name="XSqlString">sql语句</param>
        /// <returns>返回结果集的首行首列</returns>
        public int GetRecordCount(string XSqlString)
        {
            string SCount;
            SqlCommand Cmd = new SqlCommand(XSqlString, GetConn());
            SCount = Cmd.ExecuteScalar().ToString().Trim(); //返回结果集的首行首列,忽略其它
            if (SCount == "")
                SCount = "0";
            return Convert.ToInt32(SCount);
        }
        /// <summary>
        ///  查询数据结果以填充表格的形式（不带参数）
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static DataTable NoGetTable(string sql, CommandType type)
        {

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlDataAdapter apter = new SqlDataAdapter(sql, conn))
                {
                    apter.SelectCommand.CommandType = type;
                    DataTable da = new DataTable();
                    apter.Fill(da);
                    return da;
                }
            }
        }
    }
}
