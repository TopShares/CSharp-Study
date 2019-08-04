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
    /// <summary>
    /// 链栈的结点 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Node <T>
    {
        private T data;
        private Node<T> next;

        public Node()
        {
            data = default(T);
            next = null;
        }

        public Node(T data)
        {
            this.data = data;
            next = null;
        }

        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }

        public Node(Node<T> next)
        {
            this.next = next;
            data = default(T);
        }

        public T Data { get { return data; }set { data = value; } }

        public Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }
    }
}
