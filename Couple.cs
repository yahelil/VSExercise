using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    internal class Couple
    {
        //A class for Page 133 - Exercise 18
        private int num;
        private int appears;
        public Couple()
        {
            this.num = 0;
            this.appears = 0;
        }
        public Couple(int num, int appears)
        {
            this.num = num;
            this.appears = appears;
        }
        public int Getnum()
        {
            return this.num;
        }
        public int Getappears()
        {
            return this.appears;
        }

    }
}
