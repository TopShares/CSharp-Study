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
    /// 测试授权验证特性的控制器
    /// </summary>
    [CommonBasicAuthorize]
    [RoutePrefix("api/School")]
    public class SchoolController : ApiController
    {
        /// <summary>
        /// 添加允许匿名访问
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetStudentCount")]
        [HttpGet]
        public int GetStudentCount()
        {
            //在这里编写你需要的复杂的业务逻辑...

            return 10000;
        }

        /// <summary>
        /// 只有验证通过后才允许调用这个API
        /// </summary>
        /// <returns></returns>
        [Route("GetTeacherCount")]
        [HttpPost]
        public int GetTeacherCount()
        {
            //在这里编写你需要的复杂的业务逻辑...

            return 10000;
        }
    }
}
