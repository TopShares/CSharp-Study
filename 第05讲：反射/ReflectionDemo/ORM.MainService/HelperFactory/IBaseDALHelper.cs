﻿using System;
using System.Collections.Generic;
using System.Data;
namespace ORM.MainService
{
    /// <summary>
    /// 多数据库访问通用Helper接口
    /// </summary>
    /// <typeparam name="TDataRader"></typeparam>
    public interface IBaseDALHelper<TReader, TParam>
          where TReader : IDataReader
          where TParam : IDataParameter
    {
        /// <summary>
        /// 返回一个结果集DataSet
        /// </summary>
        /// <param name="cmdTextList">SQL命令文本，可以是SQL语句或者存储过程名称</param>
        /// <param name="param">参数接口数组</param>
        /// <param name="isStoreProcedure">是否是存储过程</param>
        /// <returns>返回一个DataSet</returns>
        DataSet GetDataSet(Dictionary<string, string> cmdTextList, TParam[] param = null, bool isStoreProcedure = false);
        /// <summary>
        /// 返回一个只读数据集DataReader
        /// </summary>
        /// <param name="cmdText">SQL命令文本，可以是SQL语句或者存储过程名称</param>
        /// <param name="param">泛型数组</param>
        /// <param name="isStoreProcedure">是否是存储过程</param>
        /// <returns></returns>
        TReader GetReader(string cmdText, TParam[] param = null, bool isStoreProcedure = false);
        /// <summary>
        /// 返回一个单一结果
        /// </summary>
        /// <param name="cmdText">SQL命令文本，可以是SQL语句或者存储过程名称</param>
        /// <param name="param">泛型数组</param>
        /// <param name="isStoreProcedure">是否是存储过程</param>
        /// <returns></returns>
        object GetSingleResult(string cmdText, TParam[] param = null, bool isStoreProcedure = false);
        /// <summary>
        /// 执行增删改，返回受影响的行数
        /// </summary>
        /// <param name="cmdText">SQL命令文本，可以是SQL语句或者存储过程名称</param>
        /// <param name="param">泛型数组</param>
        /// <param name="isStoreProcedure">是否是存储过程</param>
        /// <returns></returns>
        int Update(string cmdText, TParam[] param = null, bool isStoreProcedure = false);
    }
}
