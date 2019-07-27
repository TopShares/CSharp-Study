using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIDemo.Controllers
{
    /// <summary>
    /// 路由前缀
    /// </summary>
    [RoutePrefix("api/Teacher")]
    public class TeacherController : ApiController
    {
        [Route("")]
        [HttpGet]
        public int GetAllTeacherCount()
        {
            return 10;
        }
        [Route("QueryTeacherById")]
        [HttpPost]
        public string QueryTeaherById([FromBody] int teacherId)
        {
            return "常老师的讲师编号：" + teacherId;
        }
        //路由约束1
        [Route("GetCount/{age:int=0}")]
        [HttpGet]
        public string GetCount(int age)
        {
            return $"查询讲师年龄等于{age}共计10人";
        }
        //路由约束1
        [Route("GetTeacherName/{id:int=0}")]
        [HttpPost]
        public string GetTeacherName([FromBody]int id)
        {
            return "当前授课老师的讲师编号是：" + id;
        }
    }
}
