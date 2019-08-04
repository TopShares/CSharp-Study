using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ruanmou.LuceneProject.Model;

namespace Ruanmou.LuceneProject.Interface
{
    public interface ILuceneBulid
    {
        /// <summary>
        /// 批量创建索引
        /// </summary>
        /// <param name="ciList"></param>
        /// <param name="pathSuffix">索引目录后缀，加在电商的路径后面，为空则为根目录.如sa\1</param>
        /// <param name="isCreate">默认为false 增量索引  true的时候删除原有索引</param>
        void BuildIndex(List<Commodity> ciList, string pathSuffix = "", bool isCreate = false);

        /// <summary>
        /// 将索引合并到上级目录
        /// </summary>
        /// <param name="sourceDir">子文件夹名</param>
        void MergeIndex(string[] sourceDirs);

        /// <summary>
        /// 新增一条数据的索引
        /// </summary>
        /// <param name="ci"></param>
        void InsertIndex(Commodity ci);

        /// <summary>
        /// 批量新增数据的索引
        /// </summary>
        /// <param name="ciList">sourceflag统一的</param>
        void InsertIndexMuti(List<Commodity> ciList);

        /// <summary>
        /// 删除一条数据的索引
        /// </summary>
        /// <param name="ci"></param>
        void DeleteIndex(Commodity ci);

         /// <summary>
        /// 批量删除数据的索引
        /// </summary>
        /// <param name="ciList">sourceflag统一的</param>
        void DeleteIndexMuti(List<Commodity> ciList);

        /// <summary>
        /// 更新一条数据的索引
        /// </summary>
        /// <param name="ci"></param>
        void UpdateIndex(Commodity ci);

        /// <summary>
        /// 批量更新数据的索引
        /// </summary>
        /// <param name="ciList">sourceflag统一的</param>
        void UpdateIndexMuti(List<Commodity> ciList);
    }
}
