using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_队列 {
    interface IQueue<T> {
        int Count { get; }
        int GetLength();
        bool IsEmpty();
        void Clear();
        void Enqueue(T item);
        T Dequeue();
        T Peek();
    }
}
