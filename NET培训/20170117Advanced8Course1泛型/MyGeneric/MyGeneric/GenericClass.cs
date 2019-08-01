using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public class GenericClass<T>
    {

        public void Show(T t)
        {
            Console.WriteLine(t);
        }

        public void GenericMethod<W, X, Y, Z, Yoyo, Eleven>()
        { }

        public T Get(T t)
        {
            List<int> iList = null;
            return t;
        }
    }

    public interface IGet<T>
    { }

    public delegate void GetHandler<T>();


    public class ChildClass : GenericClass<int>, IGet<string>
    {

    }

    public class ChildClass<T, W> : GenericClass<T>, IGet<W>
    {
        private Child child = new Child();
    }


    public class Parent
    {
        public Parent(string name)
        { }
    }

    public class Child : Parent
    {
        public Child():base("123")
        { }
    }

}
