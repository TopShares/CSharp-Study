using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




using System.Data.SqlClient;
using Models;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DAL
{
    /// <summary>
    /// 管理员数据访问类
    /// </summary>
    public class SysAdminService
    {

        //管理员登录
        //public void AdminLogin(string loginId,string loginPwd)
        //public void AdminLogin(int loginId, string loginPwd)//这个地方使用int作为LoginId是没有作用的，反而麻烦
        //{

        //}
        //关于返回值：三种情况，int、bool、string、对象类型，究竟选择哪个？一定要选用一个适合当前情况的
        //经过分析，我们通过验证用户信息，我们需要返回的内容：用户名、用户状态（后面还有角色...)，最后我们选择SysAdmin

        /// <summary>
        /// 根据账号和密码查询管理员对象
        /// </summary>
        /// <param name="admins">封装了LoginId和LoginPwd的SysAdmin对象</param>
        /// <returns></returns>
        public SysAdmin AdminLogin(SysAdmin admins)
        {
            //【1】定义SQL语句
            string sql = $"select AdminName,AdminStatus from Admins where LoginId={admins.LoginId} and LoginPwd='{admins.LoginPwd}'";
            //【2】执行查询
            SqlDataReader reader = SQLHelper.GetReader(sql);
            //【3】判断用户信息是否正确
            if (reader.Read())
            {
                admins.AdminName = reader["AdminName"].ToString();
                admins.AdminStatus = Convert.ToInt32(reader["AdminStatus"]);
                //获取扩展：获取角色ID，根据角色ID查询对应的权限...

            }
            else
            {
                admins = null;//用户名或密码错误，我们就把当前对象的清除
            }
            reader.Close();
            return admins;
        }

        /// <summary>
        /// 在本地以序列化方式保存登录信息
        /// </summary>
        /// <param name="sysAdmin"></param>
        public void SaveLoginInfo(SysAdmin sysAdmin)
        {
            FileStream fs = new FileStream("sysAdmins.sys", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, sysAdmin);
            fs.Close();
        }
        /// <summary>
        /// 从本地读取登录信息
        /// </summary>
        /// <returns></returns>
        public SysAdmin ReadLoginInfo()
        {         
            FileStream fs = new FileStream("sysAdmins.sys", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            SysAdmin sysAmin = (SysAdmin)bf.Deserialize(fs);
            fs.Close();
            return sysAmin;
        }
    }
}
