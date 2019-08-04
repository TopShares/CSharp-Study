using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Entity;
using Ruanmou.EF.Model;
using Ruanmou.Bussiness.Interface;
using Ruanmou.Framework.Caching;

namespace Ruanmou.Bussiness.Service
{
    public class CategoryService : BaseService, ICategoryService
    {
        #region Identity
        private DbSet<Category> _CategorySet = null;

        public CategoryService(DbContext dbContext)
            : base(dbContext)
        {
            this._CategorySet = base.Context.Set<Category>();
        }
        #endregion Identity

        #region Query
        /// <summary>
        /// 用code获取当前类及其全部子孙类别的id
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public IEnumerable<int> GetDescendantsIdList(string code)
        {
            return this._CategorySet.Where(c => c.Code.StartsWith(code)).Select(c => c.Id);
        }

        /// <summary>
        /// 根据类别编码找子类别集合  找一级类用默认code  root
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public IEnumerable<Category> GetChildList(string code = "root")
        {
            return this._CategorySet.Where(c => c.ParentCode.StartsWith(code));
        }

        /// <summary>
        /// 查询并缓存全部数据
        /// </summary>
        /// <returns></returns>
        public List<Category> CacheAllCategory()
        {
            return CacheManager.Get<List<Category>>("AllCategory", () => this._CategorySet.ToList());
        }
        #endregion Query
    }
}
