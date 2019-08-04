using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 作者:siki
/// 微信公众账号：devsiki
/// QQ:804632564
/// 请关注微信公众号，关注最新的视频和文章教程信息！O(∩_∩)O
/// </summary>
namespace _001_线性表 {
    class LinkList<T>:IListDS<T>
    {
        private Node<T> head;//存储一个头结点

        public LinkList()
        {
            head = null;
        }


        public int GetLength()
        {
            if (head == null) return 0;
            Node<T> temp = head;
            int count = 1;
            while (true)
            {
                if (temp.Next != null)
                {
                    count++;
                    temp = temp.Next;
                }
                else
                {
                    break;
                }
            }
            return count;
        }

        public void Clear()
        {
            head = null;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public void Add(T item)
        {
            Node<T> newNode = new Node<T>(item);//根据新的数据创建一个新的节点
            //如果头结点为空，那么这个新的节点就是头节点
            if (head == null)
            {
                head = newNode;
            }
            else
            {//把新来的结点放到 链表的尾部
                //要访问到链表的尾结点
                Node<T> temp = head;
                while (true)
                {
                    if (temp.Next != null)
                    {
                        temp = temp.Next;
                    }
                    else
                    {
                        break;
                    }
                }
                temp.Next = newNode;//把新来的结点放到 链表的尾部
            }
        }

        public void Insert(T item, int index)
        {
            Node<T> newNode = new Node<T>(item);
            if (index == 0) //插入到头节点
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                Node<T> temp = head;
                for (int i = 1; i <=index-1; i++)
                {
                    //让temp向后移动一个位置
                    temp = temp.Next;
                }
                Node<T> preNode = temp;
                Node<T> currentNode = temp.Next;
                preNode.Next = newNode;
                newNode.Next = currentNode;
            }
        }

        public T Delete(int index)
        {
            T data = default(T);
            if (index == 0) //删除头结点
            {
                data = head.Data;
                head = head.Next;
            }
            else
            {
                Node<T> temp = head;
                for (int i = 1; i <= index - 1; i++) {
                    //让temp向后移动一个位置
                    temp = temp.Next;
                }
                Node<T> preNode = temp;
                Node<T> currentNode = temp.Next;
                data = currentNode.Data;
                Node<T> nextNode = temp.Next.Next;
                preNode.Next = nextNode;
            }
            return data;
        }

        public T this[int index]
        {
            get
            {
                Node<T> temp = head;
                for (int i = 1; i <= index; i++) {
                    //让temp向后移动一个位置
                    temp = temp.Next;
                }
                return temp.Data;
            }
        }

        public T GetEle(int index)
        {
            return this[index];
        }

        public int Locate(T value)
        {
            Node<T> temp = head;
            if (temp == null)
            {
                return -1;
            }
            else
            {
                int index = 0;
                while (true)
                {
                    if (temp.Data.Equals(value))
                    {
                        return index;
                    }
                    else
                    {
                        if (temp.Next != null)
                        {
                            temp = temp.Next;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                return -1;
            }
        }
    }
}
