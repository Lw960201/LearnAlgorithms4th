//二分查找
//有序数组中查找不在白名单中的数字

using System;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] whitelist = {1,2,3,4,5,6,7};//白名单
            int[] keys = {1,7,10,13};//要查找的值
            for (int i = 0; i < keys.Length; i++)//遍历所有key
            {
                if (rank(keys[i],whitelist) < 0)  Console.WriteLine(keys[i]);//如果找不到，则打印值
            }
        }
        public static int rank(int key,int[] a)
        {
            int lo = 0;
            int hi = a.Length -1;
            while (lo <= hi)
            {
                int mid = lo + (hi -lo)/2;
                if (key < a[mid]) hi = mid -1;//key小于mid，则改变最大范围
                else if(key > a[mid]) lo = mid +1;//key大于mid，则改变最小范围
                else return mid;//key等于mid，则返回mid
            }
            return -1;//找不到则返回-1
        }
    }
}
