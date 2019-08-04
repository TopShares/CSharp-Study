using Ruanmou.Bussiness.Interface;
using Ruanmou.EF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.Bussiness.Service
{
    public class UserCompanyService : BaseService, IUserCompanyService
    {
        #region Identity
        //操作基于这些完成
        private DbSet<User> _UserDbSet = null;
        private DbSet<Company> _CompanyDbSet = null;
        public UserCompanyService(DbContext dbContext)
            : base(dbContext)
        {
            this._UserDbSet = dbContext.Set<User>();
            this._CompanyDbSet = dbContext.Set<Company>();
        }
        #endregion Identity

        /// <summary>
        /// 独立查询company，访问user再去访问数据库
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Company FindCompany(int id)
        {
            return this._CompanyDbSet.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// include 用户(属性名字)，一次性查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Company FindCompanyInclude(int id)
        {
            return this._CompanyDbSet.Include("User").FirstOrDefault(c => c.Id == id);
        }

    }
}
