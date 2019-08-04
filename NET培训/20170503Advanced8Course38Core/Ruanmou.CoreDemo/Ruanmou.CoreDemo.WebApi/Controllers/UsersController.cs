using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace SOA.Web.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        /// <summary>
        /// User Data List
        /// </summary>
        private List<UserModel> _userList = new List<UserModel>
        {
            new UserModel {UserID = 1, UserName = "Superman", UserEmail = "Superman@cnblogs.com"},
            new UserModel {UserID = 2, UserName = "Spiderman", UserEmail = "Spiderman@cnblogs.com"},
            new UserModel {UserID = 3, UserName = "Batman", UserEmail = "Batman@cnblogs.com"}
        };

        #region HttpGet
        [HttpGet,Route("Get")]
        public IEnumerable<UserModel> Get()
        {
            return _userList;
        }

        [HttpGet, Route("GetUserByID/{id}")]
        public UserModel GetUserByID(int id)
        {
            var user = _userList.FirstOrDefault(users => users.UserID == id);
            return user;
        }

        //GET api/Users/?username=xx
        [HttpGet]
        public IEnumerable<UserModel> GetUserByName(string userName)
        {
            return _userList.Where(p => string.Equals(p.UserName, userName, StringComparison.OrdinalIgnoreCase));
        }

        //GET api/Users/?username=xx&id=1
        [HttpGet]
        public IEnumerable<UserModel> GetUserByNameId(string userName, int id)
        {
            return _userList.Where(p => string.Equals(p.UserName, userName, StringComparison.OrdinalIgnoreCase));
        }

        [HttpGet]
        public IEnumerable<UserModel> GetUserByModel(UserModel user)
        {
            return _userList;
        }

        [HttpGet]
        public IEnumerable<UserModel> GetUserByModelUri(UserModel user)
        {
            return _userList;
        }

        [HttpGet]
        public IEnumerable<UserModel> GetUserByModelSerialize(string userString)
        {
            UserModel user = JsonConvert.DeserializeObject<UserModel>(userString);
            return _userList;
        }

        //[HttpGet]
        public IEnumerable<UserModel> GetUserByModelSerializeWithoutGet(string userString)
        {
            UserModel user = JsonConvert.DeserializeObject<UserModel>(userString);
            return _userList;
        }
        /// <summary>
        /// 方法名以Get开头，WebApi会自动默认这个请求就是get请求，而如果你以其他名称开头而又不标注方法的请求方式，那么这个时候服务器虽然找到了这个方法，但是由于请求方式不确定，所以直接返回给你405——方法不被允许的错误。
        /// 最后结论：所有的WebApi方法最好是加上请求的方式（[HttpGet]/[HttpPost]/[HttpPut]/[HttpDelete]），不要偷懒，这样既能防止类似的错误，也有利于方法的维护，别人一看就知道这个方法是什么请求。
        /// </summary>
        /// <param name="userString"></param>
        /// <returns></returns>
        public IEnumerable<UserModel> NoGetUserByModelSerializeWithoutGet(string userString)
        {
            UserModel user = JsonConvert.DeserializeObject<UserModel>(userString);
            return _userList;
        }
        #endregion HttpGet


    }
}

public class UserModel
{
    public int UserID { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
}
