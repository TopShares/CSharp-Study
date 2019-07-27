using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using ORM.Common;

namespace ORM.MainService
{
    /*
     * 本ORM框架属于轻量级别，相当于EF会在效率上提高很多，特别适合不想使用EF，但又不想写ADO.NET操作中封装和解析过程的开发者
     * 本ORM框架对ADO.NET中CRUD操作做了基本的封装，主要使用了泛型和反射技术
     * 本ORM框架能够带来的好处是CRUD的所有操作都是基于实体对象操作，避免增、删、改操作中写SQL语句和参赛封装，同时也避免查询中对象的封装过程
     * 本ORM目前等待完善的地方：1.插入和修改时，默认值的问题、返回标识列的值问题。2.组合主键的问题   3.
     * 
     * 本ORM使用注意的问题：实体类要根据要求添加对应的“特性”（比如：主键特性、标识列特性、非数据库字段特性等）
     * 
     *版本号码：V1.0  设计：喜科堂互联教育  常慧勇
     *
     */
    public class DBService
    {
        #region 封装Insert操作

        #region 通过普通SQL语句添加

        /// <summary>
        /// 基于自动生成格式化的SQL语句
        /// </summary>
        /// <param name="model">实体对象</param>
        /// <param name="returnIdentity">是否返回标识列</param>
        /// <returns></returns>
        public static int SaveByCommonSql(object model, bool returnIdentity = false)
        {
            string msg = ValidateModel(model);
            if (msg != "success")
            {
                throw new Exception(model.GetType().Name + "模型验证错误：" + msg);
            }
            else
            {
                //【1】准备要组合的SQL语句
                StringBuilder sqlFileds = new StringBuilder("INSERT INTO " + model.GetType().Name + "(");
                StringBuilder sqlValues = new StringBuilder(" VALUES (");

                //【2】获取实体对象所有的属性
                PropertyInfo[] proArray = model.GetType().GetProperties();

                //【3】获取标识列和所有扩展属性（这些字段将不会添加到SQL语句中）
                string identity = GetIdentityColumn(proArray);
                List<string> nonTableFileds = GetNonTableFields(proArray);
                //其他属性，目前这个没有考虑GUID等类型，请学员自行完成

                //【4】循环添加其他《属性、属性值》到SQL语句中
                foreach (PropertyInfo item in proArray)
                {
                    //过滤标识列和非对应字段的属性
                    if (item.Name == identity) continue;
                    if (nonTableFileds.Contains(item.Name)) continue;

                    //获取属性值，过滤空属性
                    object columnValue = item.GetValue(model, null);
                    if (columnValue == null) continue;

                    //过滤没有赋值的时间，时间属性初始化时未赋值会变为默认最小值（0001/01/01），这个通过null是没法判断出来的
                    Type filedType = item.PropertyType;//获取字段的类型
                    if (item.PropertyType == typeof(DateTime))
                    {
                        DateTime dt;
                        DateTime.TryParse(columnValue.ToString(), out dt);
                        if (dt <= SqlDateTime.MinValue.Value)
                            continue;
                    }

                    //在SQL语句中添加一个字段名称
                    sqlFileds.Append(item.Name + ",");

                    //在SQL语句中添加字段对应的值（需要考虑“非值类型”添加单引号）
                    if (filedType == typeof(string) || filedType == typeof(DateTime))
                    {
                        sqlValues.Append("'" + columnValue + "',");
                    }
                    else
                    {
                        sqlValues.Append(columnValue + ",");
                    }
                }
                //【5】整合SQL语句（删除最后一个逗号，并闭合括号）
                string sql1 = sqlFileds.ToString().Trim(new char[] { ',' }) + ")"; //   start = start.Substring(0, start.Length - 1) + ")";//基础的方法可以这样写        
                string sql2 = sqlValues.ToString().Trim(new char[] { ',' }) + ")";
                string sql = sql1 + sql2;

                //【6】调用普通的通用数据访问类
                if (returnIdentity)//返回带标识列的
                {
                    sql += ";select @@Identity";
                    return Convert.ToInt32(HelperFactory.SQLHelper.GetSingleResult(sql));
                }
                else
                {
                    return HelperFactory.SQLHelper.Update(sql);
                }
            }
        }

        #endregion

        #region 通过带参数SQL语句添加

        /// <summary>
        /// 自动生成带参数的SQL语句添加对象
        /// </summary>
        /// <param name="model">实体对象</param>
        /// <returns></returns>
        public static int SaveByParamSql(object model, bool returnIdentity = false)
        {
            string msg = ValidateModel(model);
            if (msg != "success")
            {
                throw new Exception(model.GetType().Name + "模型验证错误：" + msg);
            }
            else
            {
                //【1】准备要组合的SQL语句和参数数组
                StringBuilder sqlFileds = new StringBuilder("INSERT INTO " + model.GetType().Name + "(");
                StringBuilder sqlValues = new StringBuilder(" VALUES (");
                List<SqlParameter> paramList = new List<SqlParameter>();

                //【2】获取实体对象所有的属性
                PropertyInfo[] proArray = model.GetType().GetProperties();

                //【3】获取标识列和所有扩展属性（这些字段将不会添加到SQL语句中）
                string identity = GetIdentityColumn(proArray);
                List<string> nonTableFileds = GetNonTableFields(proArray);
                //其他属性，目前这个没有考虑GUID等类型，请学员自行完成

                //【4】循环生成字段和参数名称到SQL语句中            
                foreach (PropertyInfo item in proArray)
                {
                    //过滤标识列和非对应字段的属性
                    if (item.Name == identity) continue;
                    if (nonTableFileds.Contains(item.Name)) continue;

                    //获取属性值，过滤空属性
                    object columnValue = item.GetValue(model, null);
                    if (columnValue == null) continue;

                    //过滤没有赋值的时间，时间属性初始化时未赋值会变为默认最小值（0001/01/01），这个通过null是没法判断出来的
                    Type filedType = item.PropertyType;//获取字段的类型
                    if (item.PropertyType == typeof(DateTime))
                    {
                        DateTime dt;
                        DateTime.TryParse(columnValue.ToString(), out dt);
                        if (dt <= SqlDateTime.MinValue.Value)
                            continue;
                    }

                    //组合SQL语句中字段名称和对应的参数名称
                    sqlFileds.Append(item.Name + ",");
                    sqlValues.Append("@" + item.Name + ",");

                    //将参数添加到参数集合
                    paramList.Add(new SqlParameter("@" + item.Name, item.GetValue(model, null)));
                }
                //【5】整合SQL语句（删除最后一个逗号，并闭合括号）
                string sql1 = sqlFileds.ToString().Trim(new char[] { ',' }) + ")";
                string sql2 = sqlValues.ToString().Trim(new char[] { ',' }) + ")";
                string sql = sql1 + sql2;

                //【6】调用普通的通用数据访问类
                if (returnIdentity)//返回带标识列的
                {
                    sql += ";select @@Identity";
                    return Convert.ToInt32(HelperFactory.SQLHelper.GetSingleResult(sql, paramList.ToArray()));
                }
                else
                {
                    return HelperFactory.SQLHelper.Update(sql, paramList.ToArray());
                }
            }
        }

        #endregion

        #region 通过存储过程添加

        public static int SaveByStoreProcedure(object model, string procedureNane)
        {
            PropertyInfo[] proArray = model.GetType().GetProperties();
            string identity = GetIdentityColumn(proArray);
            List<string> nonTableFiles = GetNonTableFields(proArray);
            List<SqlParameter> paramList = new List<SqlParameter>();
            foreach (PropertyInfo item in proArray)
            {
                if (item.Name == identity) continue;
                if (nonTableFiles.Contains(item.Name)) continue;
                paramList.Add(new SqlParameter("@" + item.Name, item.GetValue(model, null)));
            }
            return HelperFactory.SQLHelper.Update(procedureNane, paramList.ToArray(), true);
        }

        #endregion

        #endregion

        #region 封装Update操作

        /// <summary>
        /// 自动生成带参数的SQL语句完成对象修改
        /// </summary>
        /// <param name="model">实体对象</param>
        /// <returns></returns>
        public static int UpdateByParamSql(object model)
        {
            PropertyInfo[] proArray = model.GetType().GetProperties();  //获取对象的属性数组
            string primaryKey = GetPrimaryKey(proArray);//获取主键列，用来组合后面的where条件
            string identity = GetIdentityColumn(proArray);//获取标识列，避免更新
            List<string> nonTableFileds = GetNonTableFields(proArray);//获取所有的非对应数据表字段的属性（特指扩展属性）

            //组合带参数的sql语句
            StringBuilder sqlFiled = new StringBuilder("update " + model.GetType().Name + " set ");
            List<SqlParameter> paramList = new List<SqlParameter>();
            foreach (PropertyInfo item in proArray)  //循环生成字段和参数名称
            {
                //过滤标识列和非对应字段的属性
                if (item.Name == identity) continue;
                if (nonTableFileds.Contains(item.Name)) continue;
                sqlFiled.Append(item.Name + "=@" + item.Name + ",");     //组合Update内容
                paramList.Add(new SqlParameter("@" + item.Name, item.GetValue(model, null)));  //将参数添加到参数集合
            }
            foreach (PropertyInfo item in proArray)    //找到主键列并封装参数（因为前面的标识列把主键去掉了）
            {
                if (item.Name == primaryKey)
                {
                    paramList.Add(new SqlParameter("@" + item.Name, item.GetValue(model, null)));
                    break;
                }
            }
            //组合完整的带参数的SQL语句
            string sql = sqlFiled.ToString();
            sql = sql.Substring(0, sql.Length - 1) + " where " + primaryKey + "=@" + primaryKey;//去掉最后一个逗号，然后再加上where条件

            //调用通用数据访问类
            return HelperFactory.SQLHelper.Update(sql, paramList.ToArray());
        }
        public static int UpdateByStoreProcedure(object model, string procedureNane)
        {
            PropertyInfo[] proArray = model.GetType().GetProperties();
            string primaryKey = GetPrimaryKey(proArray);
            string identity = GetIdentityColumn(proArray);
            List<string> nonPropertyList = GetNonTableFields(proArray);
            List<SqlParameter> paramList = new List<SqlParameter>();
            foreach (PropertyInfo item in proArray)
            {
                if (item.Name == identity) continue;
                if (nonPropertyList.Contains(item.Name)) continue;
                paramList.Add(new SqlParameter("@" + item.Name, item.GetValue(model, null)));  //将参数添加到参数集合
            }
            foreach (PropertyInfo item in proArray)    //找到主键列并封装参数（因为前面的标识列把主键去掉了）
            {
                if (item.Name == primaryKey)
                {
                    paramList.Add(new SqlParameter("@" + item.Name, item.GetValue(model, null)));
                    break;
                }
            }
            //调用通用数据访问类
            return HelperFactory.SQLHelper.Update(procedureNane, paramList.ToArray(), true);
        }

        #endregion

        #region 封装Delete操作

        /// <summary>
        /// 自动生成带参数SQL语句删除对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int DeleteByParamSql(object model)
        {
            PropertyInfo[] proArray = model.GetType().GetProperties();
            string primaryKey = GetPrimaryKey(proArray);
            StringBuilder sql = new StringBuilder("delete from  " + model.GetType().Name);
            List<SqlParameter> paramList = new List<SqlParameter>();
            foreach (PropertyInfo item in proArray)    //找到主键列并封装参数
            {
                if (item.Name == primaryKey)
                {
                    paramList.Add(new SqlParameter("@" + item.Name, item.GetValue(model, null)));
                    break;
                }
            }
            sql.Append(" where " + primaryKey + "=@" + primaryKey); //组合完整的带参数的SQL语句         
            return HelperFactory.SQLHelper.Update(sql.ToString(), paramList.ToArray());
        }

        #endregion

        #region 封装Select操作

        /// <summary>
        /// 根据查询后的DataReader自动封装对象到List集合
        /// </summary>
        /// <typeparam name="T">要封装的实体类</typeparam>
        /// <param name="reader">当前查询用的DataReader</param>
        /// <returns>返回自动封装后的List集合</returns>
        public static List<T> GetEntitiesFromReader<T>(IDataReader reader) where T : new()
        {
            Type type = typeof(T);   //得到当前实体的类型
            PropertyInfo[] proArray = type.GetProperties();    //获取属性集合
            List<T> entityList = new List<T>();//创建集合对象

            //获取当前查询的所有列名称（注意必须和数据库字段一致）
            List<string> filedNames = new List<string>();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                filedNames.Add(reader.GetName(i).ToLower());
            }
            //循环读取并封装对象
            while (reader.Read())
            {
                T objEntity = new T();
                foreach (PropertyInfo item in proArray)//取出每一个属性信息
                {
                    if (filedNames.Contains(item.Name.ToLower()))//判断是否包含该列（因为很多时候属性和查询的字段不一致）
                    {
                        if (reader[item.Name] != null)   //如果当前列不为null，则给属性赋值
                        {
                            item.SetValue(objEntity, Convert.ChangeType(reader[item.Name], item.PropertyType), null);
                        }
                    }
                }
                entityList.Add(objEntity);
            }
            reader.Close();
            return entityList;
        }

        #endregion

        #region ORM相关的辅助方法

        //【公共的私有方法】根据属性数组，和列的类型，找到所有列名称
        private static List<string> GetAttributeColumns(PropertyInfo[] proArray, string columnType)
        {
            List<string> columnList = new List<string>();
            for (int i = 0; i < proArray.Length; i++)
            {
                object[] attrs = proArray[i].GetCustomAttributes(false);
                foreach (var item in attrs)
                {
                    if (item.GetType().Name == columnType)
                    {
                        columnList.Add(proArray[i].Name);
                        ////跳出全部循环
                        //i = proArray.Length; //在这里不应应用跳出全部循环，因为对于非映射属性，可能有多个
                        break;
                    }
                }
            }
            return columnList;
        }
        /// <summary>
        /// 获取标识列
        /// </summary>
        /// <param name="proArray"></param>
        /// <returns></returns>
        private static string GetIdentityColumn(PropertyInfo[] proArray)
        {
            return GetAttributeColumns(proArray, "IdentityAttribute")[0];
        }
        /// <summary>
        /// 获取主键列（这里我们只考虑一个主键的情况，符合主键，学员可以自己改进）
        /// </summary>
        /// <param name="proinfo"></param>
        /// <returns></returns>
        private static string GetPrimaryKey(PropertyInfo[] proArray)
        {
            return GetAttributeColumns(proArray, "PrimaryKeyAttribute")[0];
        }
        /// <summary>
        /// 获取非数据库字段属性
        /// </summary>
        /// <param name="proArray"></param>
        /// <returns></returns>
        private static List<string> GetNonTableFields(PropertyInfo[] proArray)
        {
            return GetAttributeColumns(proArray, "NonTableAttribute");
        }

        #endregion

        /// <summary>
        /// 模型验证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string ValidateModel(object model)
        {
            bool isContinue = true;//是否继续执行
            string errorMsg = string.Empty;

            foreach (PropertyInfo property in model.GetType().GetProperties())//遍历所有的属性
            {
                if (!isContinue)
                {
                    return errorMsg;//返回错误的验证信息
                }
                //找到当前属性中指定类型的自定义特性
                object[] cusAttribute = property.GetCustomAttributes(typeof(ValidateAtrribute),true);
                //遍历自定义特性
                foreach (var attribute in cusAttribute)
                {
                    ValidateAtrribute att = (ValidateAtrribute)attribute;//转换成父类
                    bool isValid = att.Validate(property.GetValue(model));//调用重写的验证方法
                    if (!isValid)//如果验证不通过
                    {
                        isContinue = false;//不在访问其他属性
                        errorMsg = att.ErrorMessage;
                        break;
                    }
                }
            }
            return "success";
        }
    }
}
