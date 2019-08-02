using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _015_列表的遍历 {
    class Program {
        static void Main(string[] args)
        {
            var scoreList = new List<int>();
            scoreList.Add(34);
            scoreList.Add(334);
            scoreList.Add(3344);
            scoreList.Add(344);
            scoreList.Add(32344);
            scoreList.Add(134);
            scoreList.Add(334);
            //for (int i = 0; i < scoreList.Count; i++)
            //{
            //    Console.Write(scoreList[i]+" ");
            //}
            foreach (var temp in scoreList)
            {
                Console.Write(temp+" ");
            }
            Console.ReadKey();
        }
    }
}
