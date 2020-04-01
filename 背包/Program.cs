using System;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 背包：迭代的顺序无所谓，只有添加元素，没有删除元素
/// </summary>
namespace 背包
{
    class Program
    {
        static void Main(string[] args)
        {
            Bag<int> temp = new Bag<int>();
            temp.add(1);
            temp.add(2);
            temp.add(3);
            temp.add(4);
            temp.add(5);
            temp.add(6);
            Console.WriteLine(temp.isEmpty());
            Console.WriteLine(temp.size());
            foreach (var a in temp)
            {
                Console.WriteLine(a + "");
            }
        }
    }

    public class Bag<T> : IEnumerable<T>
    {
        //节点的类
        public class Node
        {
            public T t;
            public Node next;
        }
        //链表的首节点
        private Node first;
        //长度
        private int N;
        //是否为空
        public bool isEmpty() {return first==null;}
        //大小
        public int size() {return N;}
        //添加
        public void add(T t)
        {
            Node oldFirst = first;
            first =  new Node();
            first.t = t;
            first.next = oldFirst;
            N++;
        }
        //迭代
        public IEnumerator<T> GetEnumerator()
        {
            for (Node i = first; i!=null; i=i.next)
            {
                yield return i.t;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
