using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    internal class Node<T>
    {
        private T value;
        private Node<T> next;

        public Node(T x)
        {
            this.value = x;
            this.next = null;
        }
        public Node(T x, Node<T> next)
        {
            this.value = x;
            this.next = next;
        }
        public T Getvalue()
        {
            return this.value;
        }
        public Node<T> Getnext()
        {
            return this.next;
        }
        public void Setvalue(T value)
        {
            this.value = value;
        }
        public void SetNext(Node<T> next)
        {
            this.next = next;
        }
        public override string ToString()
        {
            return this.value + "-->" + this.next;
        }
    }
}
