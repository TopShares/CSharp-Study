using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_简单选择排序 {
    class Program {
        static void SelectSort(int[] dataArray)
        {
            for (int i = 0; i < dataArray.Length-1; i++)
            {
                int min = dataArray[i];
                int minIndex = i;//最小值所在索引
                for (int j = i+1; j < dataArray.Length; j++)
                {
                    if (dataArray[j] < min)
                    {
                        min = dataArray[j];
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    int temp = dataArray[i];
                    dataArray[i] = dataArray[minIndex];
                    dataArray[minIndex] = temp;
                }
            }
        }
        static void Main(string[] args) {

            int[] data = new int[] { 42, 20, 17, 27, 13, 8, 17, 48 };
            SelectSort(data);
            foreach (var temp in data) {
                Console.Write(temp + " ");
            }
            Console.ReadKey();
        }
    }
}
