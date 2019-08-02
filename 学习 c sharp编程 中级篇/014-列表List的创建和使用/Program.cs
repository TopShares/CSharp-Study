using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _014_列表List的创建和使用 {
    class Program {
        static void Main(string[] args) {
            //List<int> scoreList = new List<int>();//创建了一个空的列表 通过类型后面的<>来表示这个列表存储的数据的类型
            var scoreList = new List<int>();
            //var scoreList = new List<int>(){1,2,3};//创建了一个列表，里面的初始值有三个分别为 1 2 3
            //Console.WriteLine("capacity:"+scoreList.Capacity+" count:"+scoreList.Count);
            //scoreList.Add(12);//向列表中插入数据
            //Console.WriteLine("capacity:" + scoreList.Capacity + " count:" + scoreList.Count);
            //scoreList.Add(45);
            //Console.WriteLine("capacity:" + scoreList.Capacity + " count:" + scoreList.Count);
            //Console.WriteLine(scoreList[0]);//根据索引访问数据

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("capacity:" + scoreList.Capacity + " count:" + scoreList.Count);
                scoreList.Add( 10 );
            }

            //Console.WriteLine(scoreList[2]);//索引不存在的时候，会出现异常
            Console.ReadKey();
        }
    }
}
