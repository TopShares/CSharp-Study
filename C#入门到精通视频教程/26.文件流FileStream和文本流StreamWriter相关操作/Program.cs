using ClassLibrary2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Class1
{
    static void Main(string[] args)
    {
        var path = @"H:\test\1\mytest.txt";

        //StreamWriter sw = new StreamWriter(path);

        //sw.WriteLine("hello world 123");

        //sw.Close();

        //using (StreamWriter sw = new StreamWriter(path))
        //{
        //    sw.WriteLine("hello world 12345");
        //}

        //using (StreamReader sr = new StreamReader(path))
        //{
        //    var line = sr.ReadLine();

        //    Console.WriteLine(line);
        //}

        var line = File.ReadAllText(path);

        Console.WriteLine(line);
    }
}