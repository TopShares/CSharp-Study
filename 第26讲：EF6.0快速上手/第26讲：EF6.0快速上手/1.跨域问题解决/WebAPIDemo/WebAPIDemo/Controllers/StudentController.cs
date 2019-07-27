using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    /// <summary>
    /// Get各种请求的使用汇总
    /// </summary>
    [RoutePrefix("api/Student")]
    public class StudentController : ApiController
    {
        /// <summary>
        /// Get请求：无参数
        /// </summary>
        /// <returns></returns>
        [Route("GetStudent")]
        [HttpGet]
        public int GetStudent()
        {
            return 1500;
        }

        /// <summary>
        /// Get请求：两个参数-->基础数据类型
        /// </summary>
        /// <param name="stuId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("GetStudentInfo")]
        [HttpGet]
        public string GetStudentInfo(int stuId, string name)
        {
            return $"学员基本信息：{stuId}   {name}";
        }

        /// <summary>
        /// 【3】Get请求：实体作为参数
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        //[Route("QueryStudent")]
        //[HttpGet]
        //public string QueryStudent(Student student)  //这种方法是无法接收实体参数的（无法映射）
        //{
        //    return $"查询到100个学员对象，其中一个学员信息：{student.StudentId}   {student.StudentName}";
        //}

        [Route("QueryStudent")]
        [HttpGet]
        public string QueryStudent([FromUri]Student student)
        {
            string name1 = System.Web.HttpContext.Current.Request.QueryString["StudentName"];
            string name2= System.Web.HttpContext.Current.Request.Params["StudentName"];

            return $"查询到100个学员对象，其中一个学员信息：{student.StudentId}   {student.StudentName}";
        }

        /// <summary>
        /// 【4】接收json字符串，并转化成实体对象
        /// </summary>
        /// <param name="jsonStudent"></param>
        /// <returns></returns>
        [Route("GetStudentByJson")]
        [HttpGet]
        public string GetStudentByJson(string jsonStudent)
        {
            //将json字符串反序列化
            Student model = Newtonsoft.Json.JsonConvert.DeserializeObject<Student>(jsonStudent);
            
            return $"{model.StudentId}   {model.StudentName}  {model.PhoneNumber}";
        }

        /// <summary>
        /// 【5】Get请求中，如果没有添加 [HttpGet]特性，并且方法中没有Get关键字出现，请求是不能提交的
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [Route("QueryStudentScore")]
        public string QueryStudentScore(string studentId)
        {
            return $"学员：{studentId} 成绩是90";
        }
        /// <summary>
        /// 【5】Get请求中，在省略 [HttpGet]特性的情况下，可以根据方法名称中的关键字识别Get请求
        /// 
        /// 建议：还是认真的把Get请求类型写上
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [Route("GetStudentScore")]
        public string GetStudentScore(string studentId)
        {
            return $"学员：{studentId} 成绩是90";
        }
        /// <summary>
        /// 【6】Geg请求：返回一个对象集合
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        [Route("GetStudentList")]
        [HttpGet]
        public List<Student> GetStudentList(string className)
        {
            //实际开发中，可以在这里查询数据库...

            return new List<Student>
            {
                   new Student { StudentName="andy",Age=20,PhoneNumber="13000000000" ,StudentId=1001},
                   new Student { StudentName="tom",Age=21,PhoneNumber="13000000001" ,StudentId=1002},
                   new Student { StudentName="kid",Age=22,PhoneNumber="13000000002" ,StudentId=1003},
            };
        }
    }
}
