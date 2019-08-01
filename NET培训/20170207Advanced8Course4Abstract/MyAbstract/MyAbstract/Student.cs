using MyAbstract.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbstract
{

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Student : People
    {
        private int Tall { get; set; }

        //public void Play<T>(T t) where T:
        //{
        //    Console.WriteLine("This is {0} play {1}", this.Name, lumia.GetType());
        //    t.Brand();
        //    t.Call();
        //    t.Photo();
        //}

        public void PlayPhone(BasePhone phone)
        {
            Console.WriteLine("This is {0} play {1}", this.Name, phone.GetType());
            phone.Brand();
            phone.Call();
            phone.Photo();
        }

        public void PlayLumia(Lumia lumia)
        {
            Console.WriteLine("This is {0} play {1}", this.Name, lumia.GetType());
            lumia.Brand();
            lumia.Call();
            lumia.Photo();
        }
        public void PlayIPhone(iPhone lumia)
        {
            Console.WriteLine("This is {0} play {1}", this.Name, lumia.GetType());
            lumia.Brand();
            lumia.Call();
            lumia.Photo();
        }

        
    }
    public class Teacher : People
    {
        private int Tall { get; set; }

        public void PlayLumia(Lumia lumia)
        {
            Console.WriteLine("This is {0} play {1}", this.Name, lumia.GetType());
            lumia.Brand();
            lumia.Call();
            lumia.Photo();
        }
    }
}
