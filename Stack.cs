using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    internal class Stack<T>
    {
        private Node<T> Head;

        public Stack()
        {
            this.Head = null;
        }
        public void Push(T add)
        {
            Node<T> temp = new Node<T>(add);
            temp.Setnext(Head);
            Head = temp;
        }
        public T pop()
        {
            T x = Head.Getvalue();
            Head = Head.Getnext();
            return x;
        }
        public T Top()
        {
            return Head.Getvalue();
        }
        public bool IsEmpty()
        {
            return Head == null;
        }
        public override string ToString()
        {
            if (this.IsEmpty())
            {
                return "[]";
            }
            Stack<T> temp = new Stack<T>();
            while (!this.IsEmpty())
            {
                temp.Push(this.pop());
            }
            string str = "[";
            while (!temp.IsEmpty())
            {
                str += temp.Top() + ",";
                this.Push(temp.pop());
            }
            str += "]";
            return str;
        }
    }
}
