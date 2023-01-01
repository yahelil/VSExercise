using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    internal class Stack<T>
    {
        private T Empty;
        private Node<T> Head;
        private Node<T> BeforeTail;
        private int length;
        public Stack()
        {
            this.Head = new Node<T>(Empty);
            this.BeforeTail = new Node<T>(Empty, this.Head);
            this.length = 0;
        }
        public void Push(T new_element)
        {
            Node<T> add = new Node<T>(new_element);
            if (this.IsEmpty())
            {
                this.Head.Setvalue(add.Getvalue());
            }
            else
            {
                this.Head.Setnext(add);
                this.BeforeTail = this.BeforeTail.Getnext();
                this.length++;
            }
        }
        public T pop()
        {
            if(this.IsEmpty())
            {
                return this.Empty;
            }
            T x = this.Head.Getvalue();
            this.Head = this.Head.Getnext();
            return x;
        }
        public T Top()
        {
            return this.BeforeTail.Getnext().Getvalue();
        }
        public bool IsEmpty()
        {
            return this.length <= 0;
        }

        public string ToString()
        {
            string str = "";
            Node<T> run = this.Head.Getnext();
            while(run != null)
            {
                str += run.Getvalue() + "-->";
                run = run.Getnext();
            }
            return str;
        }
        public static Node<T> prev(Node<T> lst, Node<T> p)
        {
            while(lst.Getnext() != p && lst != p)
            {
                lst = lst.Getnext();
            }
            return lst;
        }
    }
}
