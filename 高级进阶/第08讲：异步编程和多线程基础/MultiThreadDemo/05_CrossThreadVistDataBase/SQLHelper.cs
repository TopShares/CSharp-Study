using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DBUtility
{
    /// <summary>
    /// 针对SQLServer数据库的通用访问类
    /// </summary>
    public class SQLHelper
    {

        //封装数据库连接字符串
        private static string connString = "server=.;DataBase=SMDB;Uid=sa;Pwd=password01!";

        #region 封装格式化SQL语句执行的各种方法

        public static int Update(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //将异常信息写入日志
                //WriteLog(ex.Message);
                //throw new Exception("调用public static int Update(string sql)方法时发生错：" + ex.Message);
                string errorInfo = "调用public static int Update(string sql)方法时发生错：" + ex.Message;
                WriteLog(errorInfo);
                throw new Exception(errorInfo);
            }
            finally
            {
                conn.Close();
            }
        }
        public static object GetSingleResult(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //将异常信息写入日志              
                string errorInfo = "调用public static object  GetSingleResult(string sql)方法时发生错：" + ex.Message;
                WriteLog(errorInfo);
                throw new Exception(errorInfo);
            }
            finally
            {
                conn.Close();
            }
        }
        public static SqlDataReader GetReader(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                conn.Close();
                //将异常信息写入日志              
                string errorInfo = "调用SqlDataReader GetReader(string sql)方法时发生错：" + ex.Message;
                WriteLog(errorInfo);
                throw new Exception(errorInfo);
            }
        }
        public static DataSet GetDataSet(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);//创建数据适配器对象
            DataSet ds = new DataSet();//创建一个内存数据集
            try
            {
                conn.Open();
                da.Fill(ds);//使用数据适配器填充数据集
                return ds;
            }
            catch (Exception ex)
            {
                //将异常信息写入日志              
                string errorInfo = "调用  public static DataSet GetDataSet(string sql)方法时发生错：" + ex.Message;
                WriteLog(errorInfo);
                throw new Exception(errorInfo);
            }
            finally
            {
                conn.Close();
            }
        }
        public static bool UpdateByTran(List<string> sqlList)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.Transaction = conn.BeginTransaction();//开启事务          
                foreach (string sql in sqlList)
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();//提交事务
                return true;
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
                {
                    cmd.Transaction.Rollback();//回滚事务
                }
                string errorInfo = "调用UpdateByTran(List<string> sqlList)方法时发生错：" + ex.Message;
                WriteLog(errorInfo);
                throw new Exception(errorInfo);
            }
            finally
            {
                if (cmd.Transaction != null)
                {
                    cmd.Transaction = null;//清空事务
                }
                conn.Close();
            }
        }

        #endregion
        

        #region 其他方法

        private static void WriteLog(string log)
        {
            FileStream fs = new FileStream("sqlhelper.log", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString() + "   " + log);
            sw.Close();
            fs.Close();
        }

        #endregion
    }
}
