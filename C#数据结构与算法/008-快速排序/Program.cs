using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008_快速排序 {
    class Program {

        /// <summary>
        /// 对数组dataArray中索引从left到right之间的数做排序
        /// </summary>
        /// <param name="dataArray">要排序的数组</param>
        /// <param name="left">要排序数据的开始索引</param>
        /// <param name="right">要排序数据的结束索引</param>
        static void QuickSort(int[] dataArray, int left, int right)
        {
            if (left < right)
            {

                int x = dataArray[left];//基准数， 把比它小或者等于它的 放在它的左边，然后把比它大的放在它的右边
                int i = left;
                int j = right;//用来做循环的标志位

                while (true &&i<j )//当i==j的时候，说明我们找到了一个中间位置，这个中间位置就是基准数应该所在的位置 
                {

                    //从后往前比较(从右向左比较) 找一个比x小（或者=）的数字，放在我们的坑里 坑位于i的位置
                    while (true && i < j) {
                        if (dataArray[j] <= x) //找到了一个比基准数 小于或者等于的数子，应该把它放在x的左边
                    {
                            dataArray[i] = dataArray[j];
                            break;
                        } else {
                            j--;//向左移动 到下一个数字，然后做比较
                        }
                    }

                    //从前往后（从左向右）找一个比x大的数字，放在我们的坑里面 现在的坑位于j的位置
                    while (true && i < j) {
                        if (dataArray[i] > x) {
                            dataArray[j] = dataArray[i];
                            break;
                        } else {
                            i++;
                        }
                    }

                }

                //跳出循环 现在i==j i是中间位置
                dataArray[i] = x;// left -i- right

                QuickSort(dataArray,left,i-1);
                QuickSort(dataArray,i+1,right);
            }
        }

        static void Main(string[] args) {
            int[] data = new int[] { 42, 20, 17, 27, 13, 8, 17, 48 };
            
            QuickSort(data,0,data.Length-1);

            foreach (var temp in data) {
                Console.Write(temp + " ");
            }
            Console.ReadKey();
        }
    }
}
