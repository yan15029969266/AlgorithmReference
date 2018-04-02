using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmTest
{
    public class Core
    {
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="array"></param>
        public static void SelectSort(int[] array)
        {
            for(int i=0;i<array.Length;i++)
            {
                for(int j=i+1;j<array.Length;j++)
                {
                    if(array[i]>array[j])
                    {
                        int temp = 0;
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }
}
