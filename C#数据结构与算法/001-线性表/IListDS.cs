using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 作者:siki
/// 微信公众账号：devsiki
/// QQ:804632564
/// 请关注微信公众号，关注最新的视频和文章教程信息！O(∩_∩)O
/// </summary>
namespace _001_线性表 {
    interface IListDS<T>
    {
        int GetLength();
        void Clear();
        bool IsEmpty();
        void Add(T item);
        void Insert(T item, int index);
        T Delete(int index);
        T this[int index] { get; }
        T GetEle(int index);
        int Locate(T value);
    }
}
