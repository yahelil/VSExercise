using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    internal class Time
    {
        private int hour;
        private int minute;
        private int second;

        public Time()
        {
            this.hour = 0; 
            this.minute = 0; 
            this.second = 0; 
        }
        public Time(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        public int Gethour()
        {
            return this.hour;
        }
        public int Getminute()
        {
            return this.minute;
        }
        public int Getsecond()
        {
            return this.second;
        }
        public override string ToString()
        {
            return this.hour + ":" + this.minute + ":" + this.second;
        }
    }
}
