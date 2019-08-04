using Newtonsoft.Json.Linq;
using SOA.Web.Models;
using SOA.Web.Utility;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SOA.Web.Controllers
{
    //[BasicAuthorize]
    public class UsersController : ApiController//BaseApiController//
    {
        /// <summary>
        /// User Data List
        /// </summary>
        private List<Users> _userList = new List<Users>
        {
            new Users {UserID = 1, UserName = "Superman", UserEmail = "Superman@cnblogs.com"},
            new Users {UserID = 2, UserName = "Spiderman", UserEmail = "Spiderman@cnblogs.com"},
            new Users {UserID = 3, UserName = "Batman", UserEmail = "Batman@cnblogs.com"}
        };

        // GET api/Users
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return _userList;
        }

        // GET api/Users/5
        [HttpGet]
        public Users GetUserByID(int id)
        {
            string idParam = HttpContext.Current.Request.QueryString["id"];

            var user = _userList.FirstOrDefault(users => users.UserID == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }

        //GET api/Users/?username=xx
        [HttpGet]
        public IEnumerable<Users> GetUserByName(string userName)
        {
            string userNameParam = HttpContext.Current.Request.QueryString["userName"];

            return _userList.Where(p => string.Equals(p.UserName, userName, StringComparison.OrdinalIgnoreCase));
        }

        //GET api/Users/?username=xx&id=1
        [HttpGet]
        public IEnumerable<Users> GetUserByNameId(string userName, int id)
        {
            string idParam = HttpContext.Current.Request.QueryString["id"];
            string userNameParam = HttpContext.Current.Request.QueryString["userName"];

            return _userList.Where(p => string.Equals(p.UserName, userName, StringComparison.OrdinalIgnoreCase));
        }

        //POST api/Users/RegisterNone
        [HttpPost]
        public Users RegisterNone()
        {
            return _userList.FirstOrDefault();
        }

        //POST api/Users/register
        //只接受一个参数的需要不给key才能拿到
        [HttpPost]
        public Users Register([FromBody]int id)//可以来自FromBody   FromUri
        //public Users Register(int id)//可以来自url
        {
            string idParam = HttpContext.Current.Request.Form["id"];

            var user = _userList.FirstOrDefault(users => users.UserID == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }

        //POST api/Users/RegisterUser
        [HttpPost]
        public Users RegisterUser(Users user)//可以来自FromBody   FromUri
        {
            string idParam = HttpContext.Current.Request.Form["UserID"];
            string nameParam = HttpContext.Current.Request.Form["UserName"];
            string emailParam = HttpContext.Current.Request.Form["UserEmail"];

            //var userContent = base.ControllerContext.Request.Content.ReadAsFormDataAsync().Result;
            var stringContent = base.ControllerContext.Request.Content.ReadAsStringAsync().Result;
            return user;
        }


        //POST api/Users/register
        [HttpPost]
        public string RegisterObject(JObject jData)//可以来自FromBody   FromUri
        {
            string idParam = HttpContext.Current.Request.Form["User[UserID]"];
            string nameParam = HttpContext.Current.Request.Form["User[UserName]"];
            string emailParam = HttpContext.Current.Request.Form["User[UserEmail]"];
            string infoParam = HttpContext.Current.Request.Form["info"];
            dynamic json = jData;
            JObject jUser = json.User;
            string info = json.Info;
            var user = jUser.ToObject<Users>();

            return string.Format("{0}_{1}_{2}_{3}", user.UserID, user.UserName, user.UserEmail, info);
        }

        //POST api/Users/RegisterUserPut
        [HttpPut]
        public Users RegisterUserPut(int id)//可以来自FromBody   FromUri
        {
            return _userList[0];
        }

    }
}
