﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;

namespace ORM.MainService
{
    /// <summary>
    /// 基于泛型实现的多数据库通用数据访问类
    /// </summary>
    /// <typeparam name="TConnection"></typeparam>
    /// <typeparam name="TCommand"></typeparam>
    /// <typeparam name="TReader"></typeparam>
    /// <typeparam name="TParam"></typeparam>
    class ImplBaseDALHelper<TConnection, TCommand, TReader, TParam> : IBaseDALHelper<TReader, TParam>
        where TConnection : IDbConnection, new()
        where TCommand : IDbCommand, new()
        where TReader : IDataReader
        where TParam : IDataParameter
    {
        private static string connString = 
            ConfigurationManager.ConnectionStrings["connString"].ToString();

        #region 增、删、改操作

        /// <summary>
        /// 增、删、改操作
        /// </summary>
        /// <param name="cmdText">SQL语句或存储过程名称</param>
        /// <param name="param">可选参数：参数数组</param>
        /// <param name="isStoreProcedure">可选参数：是否是存储过程</param>
        /// <returns></returns>
        public int Update(string cmdText, TParam[] param = null, bool isStoreProcedure = false)
        {
            TConnection conn = new TConnection();
            conn.ConnectionString = connString;
            TCommand cmd = new TCommand();
            cmd.CommandText = cmdText;
            cmd.Connection = conn;
            if (isStoreProcedure)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            if (param != null)
            {
                foreach (var item in param)
                {
                    cmd.Parameters.Add(item);
                }
            }
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //写入日志...

                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion

        #region 返回只读数据集查询

        /// <summary>
        /// 返回只读数据集查询
        /// </summary>
        /// <param name="cmdText">SQL语句或存储过程名称</param>
        /// <param name="param">可选参数：参数数组</param>
        /// <param name="isStoreProcedure">可选参数：是否是存储过程</param>
        /// <returns></returns>
        public TReader GetReader(string cmdText, TParam[] param = null, bool isStoreProcedure = false)
        {
            TConnection conn = new TConnection();
            conn.ConnectionString = connString;
            TCommand cmd = new TCommand();
            cmd.CommandText = cmdText;
            cmd.Connection = conn;
            if (isStoreProcedure)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            if (param != null)
            {
                foreach (var item in param)
                {
                    cmd.Parameters.Add(item);
                }
            }
            try
            {
                conn.Open();
                return (TReader)cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                //写入日志...

                throw ex;
            }
        }

        #endregion

        #region 返回单一结果查询

        /// <summary>
        /// 返回单一结果查询
        /// </summary>
        /// <param name="cmdText">SQL语句或存储过程名称</param>
        /// <param name="param">可选参数：参数数组</param>
        /// <param name="isStoreProcedure">可选参数：是否是存储过程</param>
        /// <returns></returns>
        public object GetSingleResult(string cmdText, TParam[] param = null, bool isStoreProcedure = false)
        {
            TConnection conn = new TConnection();
            conn.ConnectionString = connString;
            TCommand cmd = new TCommand();
            cmd.CommandText = cmdText;
            cmd.Connection = conn;
            if (isStoreProcedure)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            if (param != null)
            {
                foreach (var item in param)
                {
                    cmd.Parameters.Add(item);
                }
            }
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //写入日志...

                throw ex;
            }
        }

        #endregion

        #region 获取一个DataSet的查询

        /// <summary>
        /// 获取一个DataSet的查询
        /// </summary>
        /// <param name="cmdTextList">基于键-值对的《数据表名称、SQL语句》</param>
        /// <param name="param">可选参数：参数数组</param>
        /// <param name="isStoreProcedure">可选参数：是否是存储过程</param>
        /// <returns></returns>
        public DataSet GetDataSet(Dictionary<string, string> cmdTextList, TParam[] param = null, bool isStoreProcedure = false)
        {
            DataSet ds = new DataSet();
            try
            {
                foreach (string tableName in cmdTextList.Keys)
                {
                    DataTable dt = new DataTable(tableName);
                    TReader objReader = GetReader(cmdTextList[tableName], param, isStoreProcedure);
                    dt.Load(objReader);
                    objReader.Close();
                    ds.Tables.Add(dt);
                }
                return ds;
            }
            catch (Exception ex)
            {
                //写入日志...

                throw ex;
            }
        }

        #endregion

        #region 启用事务提交多条带参数的SQL语句

        /// <summary>
        /// 启用事务提交多条带参数的SQL语句（在SQLServer下面测试成功，MySQL还没测试）
        /// </summary>
        /// <param name="mainSql">主表SQL语句</param>
        /// <param name="mainParam">主表SQL语句对应的参数</param>
        /// <param name="detailSql">明细表SQL语句</param>
        /// <param name="detailParam">明细表SQL语句对应的参数数组集合</param>
        /// <returns>返回事务是否执行成功</returns>
        public static bool UpdateByTran(string mainSql, IDataParameter[] mainParam,
            string detailSql, List<IDataParameter[]> detailParam)
        {
            TConnection conn = new TConnection();
            conn.ConnectionString = connString;
            TCommand cmd = new TCommand();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.Transaction = conn.BeginTransaction();//开启事务
                if (mainSql != null && mainSql.Length != 0)
                {
                    cmd.CommandText = mainSql;
                    foreach (var item in mainParam)
                    {
                        cmd.Parameters.Add(item);
                    }
                    cmd.ExecuteNonQuery();
                }
                foreach (IDataParameter[] param in detailParam)
                {
                    cmd.CommandText = detailSql;
                    cmd.Parameters.Clear();//必须要清除以前的参数
                    foreach (var p in param)
                    {
                        cmd.Parameters.Add(p);
                    }
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
                //写入日志...

                throw ex;
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

    }
}
