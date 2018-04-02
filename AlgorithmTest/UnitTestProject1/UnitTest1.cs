using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmTest;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// 冒泡排序
        /// </summary>
        [TestMethod]
        public void TestSort()
        {
            int[] a = new int[] { 4, 2, 1, 6, 3 };
            Core.SelectSort(a);
        }
    }
}
