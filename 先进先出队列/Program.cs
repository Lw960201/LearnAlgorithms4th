using System;
using System.Collections;
using System.Collections.Generic;

namespace 先进先出队列
{
    class Program
    {
         static void Main(string[] args)
        {
            Queue<int> temp = new Queue<int>();
            temp.enqueue(123);
            temp.enqueue(456);
            temp.enqueue(789);
            temp.dequeue();
            Console.WriteLine(temp.isEmpty());
            Console.WriteLine(temp.size());
            foreach (var a in temp)
            {
                Console.WriteLine(a + "");
            }
        }
        
    }

    public class Queue<T> : IEnumerable<T>
    {
        //定义了节点的嵌套类
        public class Node
        {
            public T t;
            public Node next;
        }
        //指向最早添加的节点的链接
        private Node first;
        //指向最近添加的节点的链接
        private Node last;
        //队列中的元素数量
        private int N;
        //是否为空
        public bool isEmpty() { return first==null; }//或者N==0
        //大小
        public int size() { return N;}
        //从表尾添加元素
        public void enqueue(T t)
        {
            Node oldLast = last;
            last = new Node();
            last.t = t;
            last.next = null;
            //为空，首尾都是一个，不为空则放到旧尾的后面
            if (isEmpty()) first = last;
            else oldLast.next = last;
            N++;
        }
        //从表头删除元素
        public T dequeue()
        {
            T t = first.t;
            first = first.next;
            if (isEmpty()) last = null;
            N--;
            return t;
        }
        
        //迭代
        public IEnumerator<T> GetEnumerator()
        {
            for (Node x = first; x!=null ; x=x.next)
            {
                yield return x.t;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
