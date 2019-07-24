using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectName.Models;
using System.Data.SqlClient;
using ProjectName.IDAL;

namespace ProjectName.DAL
{
    public class StudentService : IStudentService
    {

        #region 添加学员对象

        /// <summary>
        /// 判断身份证号是否已经存在
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public bool IsIdNoExisted(string studentIdNo)
        {
            string sql = "select count(*) from Students where StudentIdNo=" + studentIdNo;
            int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql));
            if (result == 1) return true;
            else return false;
        }
        /// <summary>
        /// 添加学员对象
        /// </summary>
        /// <param name="objStudent"></param>
        /// <returns></returns>
        public int AddStudent(Student objStudent)
        {
            //【1】编写SQL语句
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("insert into Students(studentName,Gender,Birthday,");
            sqlBuilder.Append("StudentIdNo,Age,PhoneNumber,StudentAddress,ClassId)");
            sqlBuilder.Append(" values('{0}','{1}','{2}',{3},{4},'{5}','{6}',{7})");
            //【2】解析对象
            string sql = string.Format(sqlBuilder.ToString(), objStudent.StudentName,
                     objStudent.Gender, objStudent.Birthday,
                    objStudent.StudentIdNo, objStudent.Age,
                    objStudent.PhoneNumber, objStudent.StudentAddress,
                    objStudent.ClassId);
            try
            {
                //【3】执行SQL语句，返回结果
                return Convert.ToInt32(SQLHelper.Update(sql));
            }
            catch (SqlException ex)
            {
                throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 查询学员信息

        public List<Student> GetStudent()
        {
            return this.GetStudentBySql("");
        }
        public List<Student> GetStudentByClass(string className)
        {
            string whereSql = string.Format(" where ClassName='{0}'", className);
            return this.GetStudentBySql(whereSql);
        }
        private List<Student> GetStudentBySql(string whereSql)
        {
            string sql = "select StudentId,StudentName,Gender,Birthday,ClassName from Students";
            sql += " inner join StudentClass on Students.ClassId=StudentClass.ClassId ";
            sql += whereSql;
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<Student> list = new List<Student>();
            while (objReader.Read())
            {
                list.Add(new Student()
                {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    Gender = objReader["Gender"].ToString(),
                    Birthday = Convert.ToDateTime(objReader["Birthday"]),
                    ClassName = objReader["ClassName"].ToString()
                });
            }
            objReader.Close();
            return list;
        }
        /// <summary>
        /// 根据学生编号查询学生信息
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public Student GetStudentById(string studentId)
        {
            string sql = "select StudentId,StudentName,Gender,Birthday,ClassName,";
            sql += "StudentIdNo,PhoneNumber,StudentAddress from Students";
            sql += " inner join StudentClass on Students.ClassId=StudentClass.ClassId ";
            sql += " where StudentId=" + studentId;
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            Student objStudent = null;
            if (objReader.Read())
            {
                objStudent = new Student()
                {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    Gender = objReader["Gender"].ToString(),
                    Birthday = Convert.ToDateTime(objReader["Birthday"]),
                    ClassName = objReader["ClassName"].ToString(),
                    StudentIdNo = objReader["StudentIdNo"].ToString(),
                    PhoneNumber = objReader["PhoneNumber"].ToString(),
                    StudentAddress = objReader["StudentAddress"].ToString()
                };
            }
            objReader.Close();
            return objStudent;
        }

        #endregion

        #region 修改学员信息

        /// <summary>
        /// 修改学员时判断身份证号是否和其他学员的重复
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public bool IsIdNoExisted(string idNo, string studentId)
        {
            string sql = "select count(*) from Students where StudentIdNo="
                + idNo + " and StudentId<>" + studentId;
            int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql));
            if (result == 1) return true;
            else return false;
        }
        /// <summary>
        /// 修改学员对象
        /// </summary>
        /// <param name="objStudent"></param>
        /// <returns></returns>
        public int ModifyStudent(Student objStudent)
        {
            //【1】编写SQL语句
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("update Students set studentName='{0}',Gender='{1}',Birthday='{2}',");
            sqlBuilder.Append("StudentIdNo={3},Age={4},PhoneNumber='{5}',StudentAddress='{6}',ClassId={7}");
            sqlBuilder.Append(" where StudentId={8}");
            //【2】解析对象
            string sql = string.Format(sqlBuilder.ToString(), objStudent.StudentName,
                     objStudent.Gender, objStudent.Birthday,
                    objStudent.StudentIdNo, objStudent.Age,
                    objStudent.PhoneNumber, objStudent.StudentAddress,
                    objStudent.ClassId, objStudent.StudentId);
            try
            {
                //【3】执行SQL语句，返回结果
                return Convert.ToInt32(SQLHelper.Update(sql));
            }
            catch (SqlException ex)
            {
                throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 删除学员对象

        //public int DeleteStudentById(string studentId)
        //{
        //    string sql = "delete from Students where StudentId=" + studentId;
        //    try
        //    {
        //        return SQLHelper.Update(sql);
        //    }
        //    catch (SqlException ex)
        //    {
        //        if (ex.Number == 547)
        //            throw new Exception("该学号被其他实体引用，不能直接删除该学员对象！");
        //        else
        //            throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// 删除学员对象
        /// </summary>
        /// <param name="objStudent"></param>
        /// <returns></returns>
        public int DeleteStudent(Student objStudent)
        {
            string sql = "delete from Students where StudentId=" + objStudent.StudentId;
            try
            {
                return SQLHelper.Update(sql);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    throw new Exception("该学号被其他实体引用，不能直接删除该学员对象！");
                else
                    throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
