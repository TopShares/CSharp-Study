using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOSerialize.IO
{
    public class Recursion
    {
        /// <summary>
        /// 找出全部的子文件夹
        /// </summary>
        /// <param name="rootPath">根目录</param>
        /// <returns></returns>
        public static List<DirectoryInfo> GetAllDirectory(string rootPath)
        {
            List<DirectoryInfo> directoryList = new List<DirectoryInfo>();

            DirectoryInfo directory = new DirectoryInfo(rootPath);
            //directoryList.Add(directory);

            //directoryList.AddRange(directory.GetDirectories());

            //foreach (var child in directory.GetDirectories())
            //{
            //    directoryList.AddRange(child.GetDirectories());
            //    foreach (var grand in child.GetDirectories())
            //    {

            //    }

            //}
            GetChildDirectory(directoryList, directory);

            return directoryList;
        }


        /// <summary>
        /// 找出某个文件夹的子文件夹，，放入集合
        /// 
        /// 递归：方法自身调用自身
        /// </summary>
        /// <param name="directoryList"></param>
        /// <param name="parentDirectory"></param>
        private static void GetChildDirectory(List<DirectoryInfo> directoryList, DirectoryInfo parentDirectory)
        {
            directoryList.AddRange(parentDirectory.GetDirectories());
            if (parentDirectory.GetDirectories() != null && parentDirectory.GetDirectories().Length > 0)
            {
                foreach (var directory in parentDirectory.GetDirectories())
                {
                    GetChildDirectory(directoryList, directory);
                }
            }
        }
    }
}
