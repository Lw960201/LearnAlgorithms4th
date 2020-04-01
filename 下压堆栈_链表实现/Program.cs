using System;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 下压堆栈(链表实现)
/// </summary>
namespace 下压堆栈_链表实现
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> temp = new Stack<int>();
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

    public class Stack<T> : IEnumerable<T>
    {
        //定于节点的嵌套类
        public class Node
        {
            public T t;
            public Node next;
        }
        //栈顶
        private Node first;
        //元素数量
        private int N;
        //是否为空
        public bool isEmpty() {return first == null;}//或者N==0
        //大小
        public int size() {return N;}
        //向栈顶插入元素
        public void push(T t)
        {
            Node oldFirst = first;
            first = new Node();
            first.t = t;
            first.next = oldFirst;
            N++;
        }
        //向栈顶删除元素
        public T pop()
        {
            T t = first.t;
            first = first.next;
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
