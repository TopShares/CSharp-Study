using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _019_使用泛型和索引器来实现一个我们自己的集合类MyList {
    class MyList<T> where T:IComparable
    {
        private T[] array;
        private int count=0;//表示当前添加的元素的个数

        public MyList(int size)
        {
            if (size >= 0)
            {
                array = new T[size];
            }
        }

        public MyList()
        {
            array = new T[0];
        }

        public int Capacity
        {
            get { return array.Length; }
        }

        public int Count
        {
            get { return count; }
        }

        public void Add(T item )
        {
            if (Count == Capacity) //判断元素个数跟列表容量大小是否一样大，如果一样大，说明数组容量不用，需要创建新的数组
            {
                if (Capacity == 0)
                {
                    array = new T[4];//当数组长度为0的时候，创建一个长度为4的数组
                }
                else
                {
                    var newArray = new T[Capacity*2];//当长度不为0的时候，我们创建一个长度为原来2倍的数组
                    Array.Copy(array,newArray,Count);//把旧数组中的元素复制到新的数组中 ， 复制前count个  array-->newArray
                    array = newArray;
                }
            }
            array[Count] = item;
            count++;//元素个数自增
        }

        public T GetItem(int index)
        {
            if (index >= 0 && index <= count - 1)
            {
                return array[index];
            }
            else
            {
                //Console.WriteLine("所以超出了范围");
                throw new Exception("索引超出了范围");
            }
        }

        public T this[int index]
        {
            get//当我们通过索引器取值的时候，会调用get块
            { return GetItem(index); }
            set//当我们通过索引器设置值的时候，会调用set块
            {
                if (index >= 0 && index <= count - 1)
                {
                    array[index] = value;
                } else {
                    //Console.WriteLine("所以超出了范围");
                    throw new Exception("索引超出了范围");
                }
            }
        }

        public void Insert(int index, T item)
        {
            if (index >= 0 && index <= count - 1)
            {
                if (Count == Capacity)//容量不够 进行扩容
                {
                    var newArray = new T[Capacity*2];   
                    Array.Copy(array,newArray,count);
                    array = newArray;
                }
                for (int i = count-1; i >=index; i--)
                {
                    array[i + 1] = array[i];//把i位置的值放在后面，就是向后移动一个单位

                }
                array[index] = item;
                count++;
            }
            else
            {
                throw new Exception("所以超出范围");
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index <= count - 1)
            {
                for (int i = index + 1; i < count; i++)
                {
                    array[i - 1] = array[i];
                }
                count--;
            }
            else
            {
                throw new Exception("所以超出范围");
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (array[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public int LastIndexOf(T item)
        {
            for (int i = Count-1; i >=0; i--) {
                if (array[i].Equals(item)) {
                    return i;
                }
            }
            return -1;
        }

        public void Sort()
        {
            for (int j = 0; j < Count-1; j++)
            {
                for (int i = 0; i < Count - 1 - j; i++) {
                    if (array[i].CompareTo(array[i + 1]) > 0) {
                        T temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
            }
           
        }
    }
}
