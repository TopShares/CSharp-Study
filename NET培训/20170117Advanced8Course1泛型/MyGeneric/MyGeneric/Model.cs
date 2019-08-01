﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public interface ISports
    {
        void Pingpang();
    }

    public interface IWork
    {
        void Work();
    }


    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Hi()
        { }

    }

    public class Chinese : People, ISports, IWork
    {
        public string Tradition { get; set; }

        public void SayHi()
        {
            Console.WriteLine("吃了么？");
        }

        public void Pingpang()
        {
            Console.WriteLine("打乒乓球...");
        }

        public void Work()
        {
            throw new NotImplementedException();
        }
    }

    public class Hubei : Chinese
    {
        public string Changjiang { get; set; }
        public void Majiang()
        {
            Console.WriteLine("打麻将啦。。");
        }
    }


    public class Japanese : ISports
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public void Pingpang()
        {
            Console.WriteLine("打乒乓球...");
        }
    }
}
