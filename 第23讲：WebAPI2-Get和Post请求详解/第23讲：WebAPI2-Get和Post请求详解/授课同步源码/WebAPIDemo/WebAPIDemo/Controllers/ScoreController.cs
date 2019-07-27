using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    [RoutePrefix("api/Score")]
    public class ScoreController : ApiController
    {
        /// <summary>
        /// 【1】POST：一个参数的请求
        /// </summary>
        /// <param name="scoreId"></param>
        /// <returns></returns>
        [Route("GetScoreById")]
        [HttpPost]
        public string GetScoreById([FromBody]int scoreId)
        {
            return $"POST一个参数请求返回成绩信息：DB--90  C#--98";
        }

        /// <summary>
        /// 【2】POST：多个基础类型的参数传递（这种方式是无法实现的）
        /// 
        /// 无法将多个参数(“scoreId”和“studentId”)绑定到请求的内容
        /// </summary>
        /// <param name="scoreId"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [Route("GetScoreByIdAndName")]
        [HttpPost]
        public string GetScoreByIdAndName([FromBody]int scoreId,[FromBody] int studentId)
        {
            return $"POST多个个参数请求返回成绩信息：DB--90  C#--98";
        }

        /// <summary>
        /// 【3】POST：基于dynamic实现多个参数的请求
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("GetScoreByDynamic")]
        [HttpPost]
        public string GetScoreByDynamic(dynamic param)
        {
            return $"基于dynamic实现多个参数的请求返回成绩信息：{param.StudentName}  {param.StudentId}";
        }

        /// <summary>
        /// 【4】基于JSON传递实体对象，前端可以直接传递普通json，后台也不用非得写FromBody
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [Route("QueryStudent")]
        [HttpPost]
        public string QueryStudent(Student student)
        {
            return $"基于JSON传递实体对象请求返回信息：{student.StudentName}";
        }

        /// <summary>
        /// 【6】POST：基础数据类参数+实体参数一起传递
        ///  通用dynamic类型，接收复杂的JSON字符
        /// </summary>
        /// <returns></returns>
        [Route("MultiParam")]
        [HttpPost]
        public string MultiParam(dynamic param)
        {
            //方式1：通过key动态的获取对应的数据，并根据需要转换
            var teacher = param.Teacher.ToString();
            var course = Newtonsoft.Json.JsonConvert.DeserializeObject<Course>(param.Course.ToString());

            //方式2：对应动态类型中包括的子对象也可以通过jObject类型转换（下面的效果和上面是一样）
            Newtonsoft.Json.Linq.JObject jCourse = param.Course;
            var courseModel = jCourse.ToObject<Course>();//讲jsonObject转换成具体的实体对象

            return $"Teacher={teacher}  Course>Id={course.Id}  CourseName={course.Name}";
          
        }
        /// <summary>
        /// 【7】简单数据作为参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("ArrayParam")]
        [HttpPost]
        public string ArrayParam(string[] param)
        {
            return $"{param[0]}  {param[1]}  {param[2]}";
        }

        /// <summary>
        /// 【8】实体集合作为参数
        /// </summary>
        /// <param name="stuList"></param>
        /// <returns></returns>
        [Route("ListParam")]
        [HttpPost]
        public string ListParam(List<Student> stuList)
        {
            return stuList.Count.ToString();
        }

    }
}
