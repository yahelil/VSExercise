using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    internal class Couple2
    {
        //A class for Page 102 - Exercise 56
        private int num;
        private int power;
        public Couple2()
        {
            this.num = 0;
            this.power = 0;
        }
        public Couple2(int num, int power)
        {
            this.num = num;
            this.power = power;
        }
        public int Getnum()
        {
            return this.num;
        }
        public int Getpower()
        {
            return this.power;
        }
        public void Setnum(int num)
        {
            this.num = num;
        }
        public void Setpower(int power)
        {
            this.power = power;
        }

    }
}
