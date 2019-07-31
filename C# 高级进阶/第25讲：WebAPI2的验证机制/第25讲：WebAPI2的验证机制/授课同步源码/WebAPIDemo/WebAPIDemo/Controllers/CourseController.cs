using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIDemo.Controllers
{
    /// <summary>
    /// 基础API练习类
    /// </summary>
    public class CourseController : ApiController
    {
        [HttpGet]
        public string GetCourse()
        {
            //在这个地方可以请求数据库或其他资源...

            return "GetCourse()方法返回的结果：WebAPI2开发技术";
        }
        [HttpGet]
        public string GetCourseById(int courseId)
        {
            return $"GetCourseById(int courseId)方法返回结果：WebAPI2学习--对应的课程编号：{courseId}";
        }

        public string GetCourseByName()
        {
            return $"GetCourseByName()方法返回结果!";
        }

        //特性路由1
        [Route("Course/QueryCourse")]
        [HttpGet]
        public string QueryCourse(int courseId)
        {
            //在这里可以添加其他的操作...

            return "Get请求到的课程ID=" + courseId;
        }
        //特性路由2
        [Route("Course/UpdateCourse")]
        [HttpPost]
        public string UpdateCourse()
        {
            //在这里可以添加其他的操作...

            return "您正在修改课程！";
        }
        //特性路由3
        [Route("Course/DeleteCourse")]
        [HttpPost]
        public string DeleteCourse([FromBody]int courseId)
        {
            //在这里可以添加其他的操作...

            return "Post请求到的课程ID="+courseId;
        }
        //特性路由
        [Route("Course/AddCourse")]
        [HttpPost]
        public string AddCourse([FromBody]Models.Course course)
        {
            //在这里可以添加其他的操作...

            return $"Post请求到的课程ID={course.Id} Name={course.Name} Category={course.Category} Price={course.Price}";
        }

    }
}
