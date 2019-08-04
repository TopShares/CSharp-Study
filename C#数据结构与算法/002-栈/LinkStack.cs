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
namespace _002_栈 {
    class LinkStack<T>:IStackDS<T>
    {
        private Node<T> top;// 栈顶元素结点
        private int count = 0;//栈中元素的个数

        /// <summary>
        ///  取得栈中元素的个数
        /// </summary>
        public int Count
        {
            get { return count; } 
        }

        /// <summary>
        /// 取得栈中元素的个数
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return count;
        }

        /// <summary>
        /// 判断栈中是否有数据
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return count == 0;
        }

        /// <summary>
        /// 清空栈中所有的数据
        /// </summary>
        public void Clear()
        {
            count = 0;
            top = null;
        }

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            //把新添加的元素作为头结点（栈顶）
            Node<T> newNode = new Node<T>(item);
            newNode.Next = top;
            top = newNode;
            count++;
        }

        /// <summary>
        /// 出栈  取得栈顶元素，然后删除
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T data = top.Data;
            top = top.Next;
            count--;
            return data;
        }

        /// <summary>
        /// 取得栈顶中的数据，不删除栈顶
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return top.Data;
        }
    }
}
