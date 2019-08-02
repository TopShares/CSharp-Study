using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _017_泛型_泛型类 {
    class ClassA<T,A> {//T代表一个数据类型，当使用classA进行构造的时候，需要制定T的类型
        private T a;
        private T b;
        private A c;

        public ClassA(T a, T b )
        {
            this.a = a;
            this.b = b;
        }

        public string  GetSum()
        {
            
            return a +""+ b;
        }
    }
}
