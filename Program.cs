using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    internal class Program
    {   
        //page 93 - exercise 18
        //A function that gets a list and a name, checks how many times the name is in the list
        public static int NameChack(Node<string> L, string name)
        {
            Node<string> lst = L;
            int counter = 0;
            while(lst != null)
            {
                string[] arr = new string[2];
                arr = lst.Getvalue().Split();
                if(arr[0] == name)
                {
                    counter++;
                }
                lst = lst.Getnext();
            }
            return counter;
        }
        //A function that gets two strings and finds the index one string is in the second one 
        public static int FindvalueIndex(string value, string n)
        {
            string temp = Char.ToString(value[0]);
            int i = 1;
            int main = 0;
            while(temp != n)
            {
                temp = Char.ToString(value[i]);
                main++;
                i++;
            }
            return main;
        }
        //Page 93 - exercise 19
        //A function that gets strings and builds a new list with the strings in the oposit order
        public static Node<string> BuildTailString()
        {
            string str = Console.ReadLine();
            Node<string> list = new Node<string>(str);
            Node<string> p;
            str = Console.ReadLine();
            while (str != "done")
            {
                p = new Node<string>(str, list);
                list = p;              
                str = Console.ReadLine();
            }
            return list;

        }
        //Page 93 - exercise 21
        //A function gets a list(strings),if its in the right alphabetic order it returns null,else returns the index the order broke
        //Need to know - Compare() compars in an alphabetic order(1 is greater, 0 is equals and -1 is smaller)
        public static Node<int> SortByAlpha(Node<int> list)
        {
            Node<int> p1 = list;
            Node<int> p2 = list.Getnext();
            while(p1.Getvalue().CompareTo(p2.Getvalue()) > 0)
            {
                if(p2.Getnext() == null)
                {
                    return null;
                }
                p1 = p1.Getnext();
                p2 = p2.Getnext();
            }
            return p2;
        }
        /*
        //page 95 - exercise 30
        //A
        //A function that gets a list and an int and returns true if a sublist palindrom in the length of the int exists in the list
        public static void IsPalindrom(Node<int> lst, int n)
        {
            Node<int> begin = lst;
            Node<int> last = lst;
            last = FindBox(last, n);
            if(begin.Getvalue() != last.Getvalue())
            {
                begin = begin.Getnext();
                last = prev(last);
            }
        }
        public static Node<int> prev(Node<int> lst)
        {
            Node<int> p = lst;
            while(p != lst)
            {
                p = p.Getnext();
            }
            return p;
        }
        */
        //page 95 - exercise 31
        //A function that gets two lists and returns a list of all the similars
        public static Node<int> CombinedList(Node<int> first, Node<int> second)
        {
            Node<int> final = new Node<int> (0);
            bool replaced = false;
            for(int i =0; i< FindLength(first); i++)
            {
                for(int j = 0; j < FindLength(second); j++)
                {
                    if (FindBox(first, j) != FindBox(second, j))
                    {
                        continue;
                    }
                    if (FindBox(first, j) == FindBox(second, j))
                    {
                        if(replaced == false)
                        {
                            final.Setvalue(FindBox(first, j).Getvalue());
                            replaced = true;
                        }
                        else
                        {
                           AddHead(final, FindBox(first, j));
                        }    
                    }
                }
            }
            return final;
        }
        //A function that build a list by getting a number and adding it to the list's head
        public static Node<int> AddHead(Node<int> lst, Node<int> add)
        {
            Node<int> first = lst;
            while(first.Getnext() != null)
            {
                first = first.Getnext();
            }
            first.SetNext(add);
            return first;
          

        }
        //A function that gets the length of a list
        public static int FindLength(Node<int> lst)
        {
            Node<int> p = lst;
            int length = 1;
            while (p.Getnext() != null)
            {
                p = p.Getnext();
                length++;
            }
            return length;
        }
        // A function that gets the box in index n
        public static Node<int> FindBox(Node<int> lst, int n)
        {
            Node<int> p = lst;
            for(int i = 0; i < n; i++)
            {
                p = p.Getnext();
            }
            return p;
        }



        static void Main(string[] args)
        {
        }
    }
}
