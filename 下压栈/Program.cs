using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 下压栈：动态调整数组大小、泛型、迭代
/// </summary>
namespace 下压栈
{
    class Program
    {
        static void Main(string[] args)
        {
            ResizeingArrayStack<int> temp = new ResizeingArrayStack<int>();
            temp.push(123);
            temp.push(456);
            temp.push(789);
            temp.pop();
            Console.WriteLine(temp.isEmpty());
            Console.WriteLine(temp.size());
            foreach (var a in temp)
            {
                Console.WriteLine(a + "");
            }
        }


    }


    public class ResizeingArrayStack<T> : IEnumerable<T>
    {
        private T[] a = new T[1];
        private int N = 0;
        //是否为空
        public bool isEmpty() {return N==0;}
        //尺寸
        public int size() {return N;}
        //重新分配尺寸
        private void resize(int max)
        {
            T[] temp = new T[max];
            for (int i = 0; i < N; i++)
            {
                temp[i] = a[i];
            }
            a = temp;
        }
        //压栈
        public void push(T t)
        {
            if (N == a.Length) resize(2*a.Length);
            a[N++] = t;
        }
        //弹栈
        public T pop()
        {
            T t = a[--N];
            //a[N] = null;
            if(N > 0 && N==a.Length/4) resize(a.Length/2);
            return t;
        }
        //迭代
        public IEnumerator<T> GetEnumerator()
        {
            for (int index = N - 1; index >= 0; index--)
            {
                yield return a[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
