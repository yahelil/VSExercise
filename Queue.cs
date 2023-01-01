using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    internal class Queue<T>
    {
        private Node<T> first;
        private Node<T> last;

        public Queue()
        {
            this.first = null;
            this.last = null;
        }
        public bool IsEmpty()
        {
            return (this.first == null);
        }
        public void Insert(T value)
        {
            Node<T> p = new Node<T>(value);
            if (this.first == null)
            {
                this.first = p;
                this.last = p;
            }
            else
            {
                this.last.Setnext(p);
                this.last = p;
            }
        }
        public T Head()
        {
            return this.first.Getvalue();
        }
        public T Remove()
        {
            T value = this.first.Getvalue();
            this.first = this.first.Getnext();
            return value;
        }
        public override string ToString()
        {
            if (this.first == null)
            {
                return " ";
            }
            return this.first.ToString();
        }
    }
}
