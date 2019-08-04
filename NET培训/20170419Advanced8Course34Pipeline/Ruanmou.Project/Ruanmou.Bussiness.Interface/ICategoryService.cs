using Ruanmou.EF.Model;
using System.Collections.Generic;

namespace Ruanmou.Bussiness.Interface
{
    public interface ICategoryService : IBaseService
    {
        #region Query
        /// <summary>
        /// 用code获取当前类及其全部子孙类别的id
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        IEnumerable<int> GetDescendantsIdList(string code);

        /// <summary>
        /// 根据类别编码找子类别集合  找一级类用默认code  root
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        IEnumerable<Category> GetChildList(string code = "root");

        /// <summary>
        /// 查询并缓存全部的类别数据
        /// 类别数据一般是不变化的
        /// </summary>
        /// <returns></returns>
        List<Category> CacheAllCategory();
        #endregion Query
    }
}
