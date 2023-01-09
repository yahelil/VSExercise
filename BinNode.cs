using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    internal class BinNode<T>
    {

        private T value;
        private BinNode<T> left;
        private BinNode<T> right;

        public BinNode(T value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }
        public BinNode(T value, BinNode<T> left, BinNode<T> right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }
        public T Getvalue()
        {
            return this.value;
        }
        public BinNode<T> Getleft()
        {
            return this.left;
        }
        public BinNode<T> Getright()
        {
            return this.right;
        }
        public bool Hasleft()
        {
            return this.left != null;
        }
        public bool Hasright()
        {
            return this.right != null;
        }
        public void Setvalue(T value)
        {
            this.value = value;
        }
        public void Setleft(BinNode<T> left)
        {
            this.left = left;
        }
        public void Setright(BinNode<T> right)
        {
            this.right = right;
        }
        public override string ToString()
        {
            return "( Left: " + this.left + ", Value:  " + this.value + ", Right: " + this.right + ")";
        }
    }
}
