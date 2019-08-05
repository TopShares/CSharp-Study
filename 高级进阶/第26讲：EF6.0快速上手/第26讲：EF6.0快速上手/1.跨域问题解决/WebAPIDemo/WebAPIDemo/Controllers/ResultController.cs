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
    /// WebAPI的方法返回值使用汇总
    /// </summary>
    [RoutePrefix("api/Result")]
    public class ResultController : ApiController
    {
        /// <summary>
        /// 没有返回值
        /// </summary>
        /// <param name="student"></param>
        [Route("AddStudent")]
        [HttpPost ]
        public void AddStudent(Student student)
        {
            //我们可以在这个地方保存到数据库或其他文件...


        }
        /// <summary>
        /// 返回：Json<T>(T content)
        /// </summary>
        /// <returns></returns>
        [Route("QueryStudent")]
        [HttpPost]
        public IHttpActionResult QueryStudent()
        {
            //其他业务...

            var stuList = new List<Student>
            {
                 new Student { StudentName="andy" , Age=20, PhoneNumber="1360000001",StudentId=1001},
                 new Student { StudentName="tom" , Age=22, PhoneNumber="1360000002",StudentId=1002},
                 new Student { StudentName="aki" , Age=21, PhoneNumber="1360000003",StudentId=1003}
            };
            return Json(stuList);
        }
        /// <summary>
        /// 【3】返回匿名对象（适合没有对应实体类的普通的数据组合）
        /// </summary>
        /// <returns></returns>
        [Route("QueryScore")]
        [HttpPost]
        public IHttpActionResult QueryScore()
        {
            //其他业务

            return Json<dynamic>(new { Sqlserver = 89, DB = 99, StudentId = 10010 });
        }
        /// <summary>
        /// 返回：OK（）
        /// </summary>
        /// <returns></returns>
        [Route("ReturnOK")]
        [HttpPost]
        public IHttpActionResult ReturnOK()
        {
            //其他业务

            return Ok();
        }

        /// <summary>
        /// 返回：重载的Ok<T>(T content)
        /// </summary>
        /// <returns></returns>
        [Route("ReturnOverloadOk")]
        [HttpPost]
        public IHttpActionResult ReturnOverloadOk()
        {
            //其他业务

            return Ok(10000);
        }
        //以上的方式和Json<T>(T content)相类似。
        //开发中的选择：如果是实体或集合，建议使用Json<T>(T content)
        //如果是基础数据类型返回，可以使用Ok<T>(T content)

        //其他相关类型，自己用到再学即可
    }
}
