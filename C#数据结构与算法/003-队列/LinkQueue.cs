using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 作者:siki
/// 微信公众账号：devsiki
/// QQ:804632564
/// 请关注微信公众号，关注最新的视频和文章教程信息！O(∩_∩)O
/// </summary>
namespace _003_队列 {
    class LinkQueue <T>:IQueue<T>
    {
        private Node<T> front;//头节点 
        private Node<T> rear;//尾结点
        private int count;//表示元素的个数

        public LinkQueue()
        {
            front = null;
            rear = null;
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public int GetLength()
        {
            return count;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public void Clear()
        {
            front = null;
            rear = null;
            count = 0;
        }

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (count == 0)
            {
                front = newNode;
                rear = newNode;
                count = 1;
            }
            else
            {
                rear.Next = newNode;
                rear = newNode;
                count++;
            }
        }

        public T Dequeue()
        {
            if (count == 0)
            {
                Console.WriteLine("队列为空，无法出队");
                return default(T);
            }else if (count == 1)
            {
                T temp = front.Data;
                front = rear = null;
                count = 0;
                return temp;
            }
            else
            {
                T temp = front.Data;
                front = front.Next;
                count--;
                return temp;
            }
        }

        public T Peek()
        {
            if (front != null)
            {
                return front.Data;
            }
            else
            {
                return default(T);
            }
        }
    }
}
