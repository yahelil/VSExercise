using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace Exercise
{
    internal class Program
    {
        //Node<T>

        //page 93 - exercise 18
        //A function that gets a list and a name, checks how many times the name is in the list
        public static int NameChack(Node<string> L, string name)
        {
            Node<string> lst = L;
            int counter = 0;
            while (lst != null)
            {
                string[] arr = new string[2];
                arr = lst.Getvalue().Split();
                if (arr[0] == name)
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
            while (temp != n)
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
        //Note - Compare() compars in an alphabetic order(1 is greater, 0 is equals and -1 is smaller)
        public static Node<int> SortByAlpha(Node<int> list)
        {
            Node<int> p1 = list;
            Node<int> p2 = list.Getnext();
            while (p1.Getvalue().CompareTo(p2.Getvalue()) > 0)
            {
                if (p2.Getnext() == null)
                {
                    return null;
                }
                p1 = p1.Getnext();
                p2 = p2.Getnext();
            }
            return p2;
        }
        //Page 94 - exercise 25
        //A function that gets a not empty list and an int num, returns true if there is a series of numbers in the length of num in list, else false
        public static bool DoesContainSiries(Node<int> list, int num)
        {
            Node<int> start = list; //A node for every start of a series
            Node<int> checker; //A node that checks every series (runs in it)
            Node<int> end = list; //A node for every end of a series
            int SeiresValue; // The value of the series
            bool IsOk = true; // A var to check if the series wasn't broken yet 

            for (int i = 0; i < num; i++)
            {
                end = end.Getnext();
            }
            while (end != null)
            {
                SeiresValue = start.Getvalue();
                checker = start;
                while (checker != end)
                {
                    if (checker.Getvalue() != SeiresValue)
                    {
                        IsOk = false;
                    }
                    checker = checker.Getnext();
                }
                if (IsOk)
                {
                    return true;
                }
                end = end.Getnext();
                start = start.Getnext();
            }
            return false;

        }
        //Page 95 - exercise 26
        //A function that gets a list and returns the same list with all the even numbers at the beginning and the odd at the end
        /// Doesn't work
        public static void EvenThenOdd(Node<int> list)
        {
            Node<int> Zugi = null;
            Node<int> IZugi = null;
            while (list != null)
            {
                if (list.Getvalue() % 2 == 0)
                {
                    if (Zugi == null)
                    {
                        Zugi = new Node<int>(list.Getvalue());
                    }
                    else
                    {
                        Zugi.Setnext(list);
                        Zugi = list;
                    }

                }
                else
                {
                    if (IZugi == null)
                    {
                        IZugi = new Node<int>(list.Getvalue());
                    }
                    else
                    {
                        IZugi.Setnext(list);
                        IZugi = list;
                    }
                }
                list = list.Getnext();
            }
            while (Zugi != null)
            {
                if (list == null)
                {
                    list = new Node<int>(Zugi.Getvalue());
                }
                else
                {
                    list.Setnext(Zugi);
                    list = Zugi;
                }
                Zugi = Zugi.Getnext();
            }
            while (IZugi != null)
            {
                if (list == null)
                {
                    list = new Node<int>(IZugi.Getvalue());
                }
                else
                {
                    list.Setnext(IZugi);
                    list = IZugi;
                }
                IZugi = IZugi.Getnext();
            }
        }
        //A function that get a list and a node and adds the node to the list's beginning
        //Not done
        public static void BuildHead(Node<int> list, Node<int> pos)
        {
            Node<int> p = new Node<int>(pos.Getvalue(), list);
            list = p;
        }
        //Page 95 - exercise 27
        //A function that gets a list and returns a list without all the sereis that have more then 2 same number in a row
        /// Wasn't checked
        ///
        public static Node<int> NoInARow(Node<int> lst)
        {
            int counter = 0;
            Node<int> p = lst;
            Node<int> beginning = p;
            while (p != null)
            {
                while (p.Getvalue() == p.Getnext().Getvalue())
                {
                    counter++;
                }
                if (counter > 2)
                {
                    Remove(lst, beginning, p);
                }
                p = p.Getnext();
            }
            return lst;
        }
        //A function that removes all nodes until the value is diffrent from L
        public static Node<int> Remove(Node<int> L, Node<int> start, Node<int> end)
        {
            Node<int> before = start;
            Node<int> first = before;
            while (before != end.Getnext())
            {
                before = before.Getnext();
            }
            first.Setnext(before);
            return L;
        }
        //Page 95 - exercise 28
        //A
        // חוליה שהנקסט שלה היא החוליה עצמה
        //B
        //A function that gets a node and returns the length of the cirularlist it joins
        public static int CircuralListLen(Node<int> list)
        {
            Node<int> Back = list;
            int length = 0;
            list = list.Getnext();
            while (list != Back)
            {
                length++;
                list = list.Getnext();
            }
            return length;
        }
        //C
        //A function that removes num if it exists more then one time, if it doesn't it puts him in the biginning of the list
        // FOR SOME REASON DOESN'T WORK!!
        //!!!!
        //
        /// <summary>
        /// 
        /// !!
        /// </summary>
        /// <param name="list"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        /// pos = 8
        /// next = 2
        public static Node<int> Removenum(Node<int> list, int num)
        {
            Node<int> pos = list;
            int count = 0;
            while (pos.Getnext() != list)
            {
                if (count == 0)
                {
                    if (pos.Getvalue() == num)
                    {
                        count++;
                    }
                }
                else
                {
                    if (pos.Getvalue() == num)
                    {
                        prev(pos).Setnext(pos.Getnext());
                        count++;
                    }
                }
                pos = pos.Getnext();

            }
            if (count == 1)
            {
                Node<int> temp = new Node<int>(num, list);
                list = temp;
            }
            return list;
        }
        //A function 
        //Page 95 - exercise 29
        //A function that gets a list and says how many series in right order (small to big) there is(every series is evided by -999)
        public static int NumOfOrderedList(Node<int> L)
        {
            Node<int> p1 = L;
            Node<int> p2 = L.Getnext();
            bool is_follow = true;
            int count = 0;
            while (p2 != null)
            {
                if (p1.Getvalue() >= p2.Getvalue())
                {
                    while (p2.Getvalue() != -999)
                    {
                        if (p1.Getvalue() <= p2.Getvalue())
                        {
                            is_follow = false;
                        }
                        if (p2.Getnext().Getvalue() == -999 && is_follow)
                        {
                            count++;
                        }
                        p1 = p2;
                        p2 = p2.Getnext();
                    }
                    p1 = p2;
                    p2 = p2.Getnext();
                }
                else
                {
                    while (p2.Getvalue() != -999 && p2.Getnext() != null)
                    {
                        if (p1.Getvalue() >= p2.Getvalue())
                        {
                            is_follow = false;
                        }
                        if (p2.Getnext().Getvalue() == -999 && is_follow)
                        {
                            count++;
                        }
                        p1 = p2;
                        p2 = p2.Getnext();
                    }
                    p1 = p2;
                    p2 = p2.Getnext();
                }
            }
            return count;
        }
        //page 95 - exercise 30
        //A
        //A function that gets a list and an int and returns true if a sublist palindrom in the length of the int exists in the list
        public static bool IsPalindrom(Node<int> lst, int n)
        {
            int length = FindLength(lst);
            if (n > length)
            {
                return false;
            }
            Node<int> begin = lst;
            Node<int> last = FindBox(lst, n);
            bool ShouldRun = true;
            while (last != null)
            {
                Node<int> saver = last;
                for (int i = 0; i < (n / 2 + 1) && ShouldRun; i++)
                {
                    if (begin.Getvalue() != last.Getvalue())
                    {
                        ShouldRun = false;
                    }
                    begin = begin.Getnext();
                    last = prev(last);
                }
                if (ShouldRun)
                {
                    return true;
                }
                last = saver;
                begin = lst.Getnext();
            }
            return false;
        }
        public static Node<int> prev(Node<int> lst)
        {
            Node<int> p = lst;
            while (p != lst)
            {
                p = p.Getnext();
            }
            return p;
        }
        //page 95 - exercise 31
        //A function that gets two lists and returns a list of all the similars
        //Doesn't work
        public static Node<int> CombinedList(Node<int> first, Node<int> second)
        {
            Node<int> final = new Node<int>(0);
            bool replaced = false;
            for (int i = 0; i < FindLength(first); i++)
            {
                for (int j = 0; j < FindLength(second); j++)
                {
                    if (FindBox(first, j) != FindBox(second, j))
                    {
                        continue;
                    }
                    else
                    {
                        if (replaced == false)
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
            while (first.Getnext() != null)
            {
                first = first.Getnext();
            }
            first.Setnext(add);
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
            for (int i = 0; i < n; i++)
            {
                p = p.Getnext();
            }
            return p;
        }
        //Page 96 - exercise 33
        //A function that gets two lists,the second one existing once inside the first,and removes the second list from the first
        public static void RemoveSecondFromFirst(Node<int> lst1, Node<int> lst2)
        {
            Node<int> beginning = lst1;
            Node<int> check;
            Node<int> check2 = lst2;
            bool DidRemove = false;
            while (!DidRemove)
            {
                bool IsTheL = true;
                while (beginning.Getvalue() != lst2.Getvalue())
                {
                    beginning = beginning.Getnext();
                }
                check = beginning;
                while (check2 != null && IsTheL)
                {
                    if (check.Getvalue() != check2.Getvalue())
                    {
                        IsTheL = false;
                    }
                    check = check.Getnext();
                    check2 = check2.Getnext();
                }
                if (IsTheL)
                {

                    RemoveNodeSeries(lst1, beginning, check);
                    DidRemove = true;
                }
                else
                {

                    check = beginning.Getnext();
                    beginning = beginning.Getnext();
                    check2 = lst2;
                }
            }
        }
        //A side function the removes all nodes from a given node to a second node nodes
        public static void RemoveNodeSeries(Node<int> list, Node<int> pos, Node<int> pos2)
        {
            Node<int> remover = list;
            while (remover != pos2)
            {
                remover = remover.Getnext();
            }
            pos.Setnext(remover);
        }
        //Page 102 - exercise 56
        //A function that gets two polinoms lists and returns a lst of their sum
        public static Node<Couple2> SumOfPolynoms(Node<Couple2> list1, Node<Couple2> list2)
        {
            Couple2 inserter = new Couple2(0, 1);
            Node<Couple2> One = list1;
            Node<Couple2> OneSaver = One;
            Node<Couple2> Two = list2;
            Node<Couple2> Three = new Node<Couple2>(inserter);
            while (Two != null)
            {
                if (Two.Getvalue().Getpower() == One.Getvalue().Getpower())
                {
                    inserter.Setnum(One.Getvalue().Getnum() + Two.Getvalue().Getnum());
                    inserter.Setpower(One.Getvalue().Getpower());
                    AddACouple(Three, inserter);
                    PrevCouple2(OneSaver, One).Setnext(One.Getnext());
                }
                else
                {
                    inserter.Setnum(Two.Getvalue().Getnum());
                    inserter.Setpower(Two.Getvalue().Getpower());
                    AddACouple(Three, inserter);
                }
                Two = Two.Getnext();
                One = One.Getnext();
            }
            while (OneSaver != null)
            {
                inserter.Setnum(OneSaver.Getvalue().Getnum());
                inserter.Setpower(OneSaver.Getvalue().Getpower());
                AddACouple(Three, inserter);
                OneSaver = OneSaver.Getnext();
            }
            return Three;

        }
        //A side function that adds a couple to a list(Gets a list and a couple
        public static void AddACouple(Node<Couple2> L, Couple2 add)
        {
            Node<Couple2> node = new Node<Couple2>(add);
            node.Setnext(L);
            L = node;
        }
        //A side function thats gets a list and a node<Couple2> and returns the previus node
        public static Node<Couple2> PrevCouple2(Node<Couple2> lst, Node<Couple2> node)
        {
            Node<Couple2> runer = lst;
            while (runer.Getnext() != node)
            {
                runer = runer.Getnext();
            }
            return runer;
        }



        // Stack<T>
        //A function that gets a stack<int> S and returns a new stack with all the evens at the beginning and the odds at the end 
        public static Stack<int> EvenThenOddS(Stack<int> S)
        {
            Stack<int> Zugi = new Stack<int>();
            Stack<int> IZugi = new Stack<int>();
            int x;
            while (!S.IsEmpty())
            {
                x = S.pop();
                if (x % 2 == 0)
                {
                    Zugi.Push(x);
                }
                else
                {
                    IZugi.Push(x);
                }
            }
            while (!IZugi.IsEmpty())
            {
                Zugi.Push(IZugi.pop());
            }
            return Zugi;
        }

        //Page 133 - Exercise 14
        //A function that gets a stack<int> and a num, checks if the num exists in the stack in order

        public static bool IsInARow(Stack<int> S, int num)
        {
            if (S.IsEmpty())
            {
                return false;
            }
            Stack<int> S2 = new Stack<int>();
            while (!S.IsEmpty())
            {
                S2.Push(S.pop());
            }
            if (!IsNumIn(S2, num))
            {
                return false;
            }
            while (!S2.IsEmpty())
            {
                if (S2.Top() != num)
                {
                    S2.pop();
                }
                else
                {
                    while (S2.Top() == num)
                    {
                        S2.pop();
                    }
                    if (IsNumIn(S2, num))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //Side function that gets a stack<int> and an int, checks if the int exists in the stack
        public static bool IsNumIn(Stack<int> S, int x)
        {
            Stack<int> S2 = new Stack<int>();
            while (!S.IsEmpty())
            {
                S2.Push(S.pop());
            }
            while (!S2.IsEmpty())
            {
                if (S2.Top() == x)
                {
                    return true;
                }
                S2.pop();
            }
            return false;

        }
        //Page 133 - Exercise 15
        //A
        //A function that gets a stack<int> and returns the lowest number
        //Not recorsive
        public static int LowerNum(Stack<int> S)
        {
            int min = S.Top();
            Stack<int> S2 = new Stack<int>();
            Stack<int> temp = new Stack<int>();
            while (!S.IsEmpty())
            {
                S2.Push(S.Top());
                temp.Push(S.pop());
            }
            while (!S2.IsEmpty())
            {
                if (S2.Top() < min)
                {
                    min = S2.Top();
                }
                S2.pop();
            }
            while (!temp.IsEmpty())
            {
                if (temp.Top() == min)
                {
                    temp.pop();
                }
                else
                {
                    S.Push(temp.Top());
                }
            }
            return min;
        }
        //Recorsive
        public static int MinNum(Stack<int> S)
        {
            int min = S.Top();
            Stack<int> S2 = new Stack<int>();
            if (S.IsEmpty())
            {
                return min;
            }
            while (!S.IsEmpty())
            {
                S2.Push(S.pop());
            }
            if (S2.Top() < min)
            {
                min = S2.pop();
                return MinNum(S2);
            }
            else
            {
                S2.pop();
                return MinNum(S2);
            }
        }
        //B
        public static void SortStack(Stack<int> S)
        {
            Stack<int> temp = new Stack<int>();
            while (!S.IsEmpty())
            {
                int min = MinNum(S);
                temp.Push(min);
            }
            while (!temp.IsEmpty())
            {
                S.Push(temp.pop());
            }
        }
        //סיבוכיות O(n) לפי גוף פעולה לינארי O(N)

        //Page - 133 - Exercise 16
        //A function the solves the Unknown string(כתב הסתרים)
        public static string Solver()
        {
            string msg = Weird();
            Stack<char> secret = new Stack<char>();
            Stack<char> Solved = new Stack<char>();
            Stack<char> ByFive = new Stack<char>();
            for (int i = msg.Length; i > 0; i--)
            {
                secret.Push(msg[i]);
            }
            while (!secret.IsEmpty())
            {
                for (int i = 0; i < 5; i++)
                {
                    ByFive.Push(secret.pop());
                }
                Solved.Push(ByFive.pop());

            }
            while (!Solved.IsEmpty())
            {
                secret.Push(Solved.pop());
            }
            while (!secret.IsEmpty())
            {
                msg += secret.pop();
            }
            return msg;
        }
        //A function that get the Unknown string(כתב הסתרים)
        public static string Weird()
        {
            Console.WriteLine("What is your message");
            string msg = Console.ReadLine();
            return msg;
        }
        //Page 133 - Exercise 17
        //A function gets a Stack<int> and returns the length of the longest sortet in order series
        public static int LongestSortSeires(Stack<int> S)
        {
            int count = 1;
            if (S.IsEmpty())
            {
                return 0;
            }
            while (!S.IsEmpty())
            {
                if ((PrevInStack(S) + 1) == S.Top())
                {
                    count++;
                }
                S.pop();
            }
            return count;

        }
        //A function that gets the prevue int in a Stack<int>
        public static int PrevInStack(Stack<int> S)
        {
            Stack<int> reversed = new Stack<int>();
            while (!S.IsEmpty())
            {
                reversed.Push(S.pop());
            }
            Stack<int> temp = new Stack<int>();
            while (!reversed.IsEmpty())
            {
                temp.Push(reversed.pop());
            }
            temp.pop();
            return temp.Top(); ;
        }
        // page 133 - Exercise 18
        //A
        //A function that gets a Stack<Couple> and returns a Stack<int> of the num^appears 
        public static Stack<int> CoupleToInt(Stack<Couple> S)
        {
            Stack<int> final = new Stack<int>();
            int times;
            while (!S.IsEmpty())
            {
                times = S.Top().Getappears();
                while (times != 0)
                {
                    final.Push(S.Top().Getnum());
                    times--;
                }
                S.pop();
            }
            return final;
        }
        //B
        //סיבויות של o(n^2) לפי גוף הפעולה לינארי מתבצע n פעמים 

        //Work Page - Stack
        //Q1
        //A function that builds a stack<int> from input, if gets -99 stops
        public static Stack<int> BuildStack()
        {
            Console.WriteLine("Enter the num you want to add");
            int num = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            while (num != -99)
            {
                stack.Push(num);
                Console.WriteLine("Enter the num you want to add");
                num = int.Parse(Console.ReadLine());
            }
            return stack;
        }
        //Q2
        //A function that gets a stack<int> and prints it
        public static void PrintStack(Stack<int> S)
        {
            Console.WriteLine(S.ToString());
        }
        //Q3
        //A function that devaids a stack to two stacks one odd and one even
        public static Stack<Stack<int>> DivideToEvenOdd(Stack<int> S)
        {
            Stack<int> Even = new Stack<int>();
            Stack<int> Odd = new Stack<int>();
            while (!S.IsEmpty())
            {
                if (S.Top() % 2 == 0)
                {
                    Even.Push(S.pop());
                }
                else
                {
                    Odd.Push(S.pop());
                }
            }
            Stack<Stack<int>> returned = new Stack<Stack<int>>();
            returned.Push(Even);
            returned.Push(Odd);
            return returned;

        }
        //Q4
        //A function that gets two sorted stackes and returns a stack of the two of them
        public static Stack<int> MergeStacks(Stack<int> S1, Stack<int> S2)
        {
            Stack<int> S3 = new Stack<int>();
            while (!S1.IsEmpty() && !S2.IsEmpty())
            {
                if (S1.Top() > S2.Top())
                {
                    S3.Push(S1.pop());
                }
                else if (S1.Top() < S2.Top())
                {
                    S3.Push(S2.pop());
                }
                else
                {
                    S3.Push(S1.pop());
                    S3.Push(S2.pop());
                }
            }
            if (S1.IsEmpty())
            {
                while (!S2.IsEmpty())
                {
                    S3.Push(S2.pop());
                }
            }
            else if (S2.IsEmpty())
            {
                while (!S1.IsEmpty())
                {
                    S3.Push(S1.pop());
                }
            }
            Stack<int> flip = new Stack<int>();
            while (!S3.IsEmpty())
            {
                flip.Push(S3.pop());
            }
            return flip;
        }
        //Q5
        //A function that gets a stack<int> S and a num x, places x in the right spot
        public static void PlaceX(Stack<int> S, int x)
        {
            Stack<int> stack = new Stack<int>();
            while (S.Top() > x)
            {
                stack.Push(S.pop());
            }
            stack.Push(x);
            while (!S.IsEmpty())
            {
                stack.Push(S.pop());
            }
            while (!stack.IsEmpty())
            {
                S.Push(stack.pop());
            }
        }
        //Q6
        //A function that return a sorted stack
        public static Stack<int> SortedStack()
        {
            Stack<int> sorted = new Stack<int>();
            Console.WriteLine("Enter the num you want to add");
            int num = int.Parse(Console.ReadLine());
            while (num != -99)
            {
                PlaceX(sorted, num);
            }
            return sorted;
        }
        //Q7
        //A function that gets a two Stack<int> sorted in diffrent order and returns a Stack Sorted
        public static Stack<int> MergeDiffrent(Stack<int> S1, Stack<int> S2)
        {
            Stack<int> merged = new Stack<int>();
            while (!S2.IsEmpty())
            {
                PlaceX(merged, S2.pop());
            }
            while (!S1.IsEmpty())
            {
                PlaceX(merged, S1.pop());
            }
            return merged;
        }
        //Q8
        public static Node<int> SortStackToList(Stack<int> S)
        {
            Stack<int> sorted = new Stack<int>();
            while (!S.IsEmpty())
            {
                PlaceX(sorted, S.pop());
            }
            Node<int> lst = new Node<int>(-99);
            while (!sorted.IsEmpty())
            {
                if (lst.Getvalue() == -99)
                {
                    lst.Setvalue(sorted.pop());
                }
                else
                {
                    lst.Getnext().Setvalue(sorted.pop());
                }
                lst = lst.Getnext();
            }
            return lst;
        }
        //Q9
        //A function that get a stack and a list and returns true if every number in the list is in the stack, else false
        public static bool IsListInStack(Stack<int> S, Node<int> list)
        {
            Stack<int> stack = S;
            while (!stack.IsEmpty())
            {
                if (list.Getvalue() != stack.pop())
                {
                    return false;
                }
                list = list.Getnext();
            }
            return true;
        }
        //A function that checks if a string has balanced brackets
        public static bool IsBrackteBalanced(string str)
        {
            Stack<char> S = new Stack<char>();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == char.Parse("("))
                {
                    S.Push(char.Parse("("));
                }
                else if (str[i] == char.Parse("["))
                {
                    S.Push(char.Parse("["));
                }
                else if (str[i] == char.Parse("{"))
                {
                    S.Push(char.Parse("{"));
                }



                else if (str[i] == char.Parse(")"))
                {
                    if (S.pop() != char.Parse("("))
                    {
                        return false;
                    }
                }
                else if (str[i] == char.Parse("]"))
                {
                    if (S.pop() != char.Parse("["))
                    {
                        return false;
                    }
                }
                else if (str[i] == char.Parse("}"))
                {
                    if (S.pop() != char.Parse("{"))
                    {
                        return false;
                    }
                }

            }
            return true;
        }
        public static void Q19()
        {
            bool ShouldStack = false;
            Stack<char> S = new Stack<char>();
            string final = "";
            bool IsFirst = true;
            //Console.WriteLine("Enter chars");
            char ch = char.Parse(Console.ReadLine());
            while (ch != char.Parse("*"))
            {

                if (ch == char.Parse("@") && IsFirst)
                {
                    ShouldStack = true;
                    IsFirst = false;
                }
                else if (ch == char.Parse("@") && !IsFirst)
                {
                    ShouldStack = false;
                    IsFirst = true;
                    while (!S.IsEmpty())
                    {
                        final += S.pop();
                    }
                }
                else if (ShouldStack)
                {
                    S.Push(ch);
                }
                else
                {
                    final += ch;
                }
                // Console.WriteLine("Enter chars");
                ch = char.Parse(Console.ReadLine());
            }
            Console.WriteLine(final);
        }

        //Queue
        //דף עבודה: תרגילי חזרה על תור
        //Q3
        //A functoin that gets a queue q and removes all the numbers that are an even number of times in the queue
        public static void RemoveEvenExist(Queue<int> q)
        {
            Queue<int> temp = q;
            while (!(temp.IsEmpty()))
            {
                if (HowManyIn(temp, temp.Head()) % 2 == 0)
                {
                    RemoveAllNum(q, temp.Head());
                }
                temp.Remove();
            }
        }
        //A side functon that removes all the nums from q
        public static void RemoveAllNum(Queue<int> q, int num)
        {
            Queue<int> temp = new Queue<int>();
            while (!q.IsEmpty())
            {
                temp.Insert(q.Head());
            }
            while (!temp.IsEmpty())
            {
                if (temp.Head() != num)
                {
                    q.Insert(temp.Head());
                }
                temp.Remove();
            }
        }
        //A side function that tells you how many times the num is in q
        public static int HowManyIn(Queue<int> q, int num)
        {
            Queue<int> check = q;
            int count = 0;
            while (!q.IsEmpty())
            {
                if (q.Remove() == num)
                {
                    count++;
                }
            }
            return count;
        }
        //O(n^3)
        //Q4
        //A function that gets a queue<int> q and an int x and returns the number of series with the length of x
        public static int HowManySeriesOfX(Queue<int> q, int x)
        {
            int count = 0;
            int length;
            int NumOfSeries;
            while (!q.IsEmpty())
            {
                length = 0;
                NumOfSeries = q.Remove();
                while (q.Head() == NumOfSeries)
                {
                    length++;
                }
                if (length == x)
                {
                    count++;
                }
            }
            return count;
        }
        //O(n^2)
        //Q5
        //A function that gets two queues and returns the number of elements in the first one that is equal to the sum of two follow elements in the second
        public static int Q5(Queue<int> q1, Queue<int> q2)
        {
            Queue<int> sums = new Queue<int>();
            int count = 0;
            while (!q2.IsEmpty())
            {
                sums.Insert(q2.Remove() + q2.Head());
            }
            while (!sums.IsEmpty())
            {
                if (IsIn(sums, q1.Remove()))
                {
                    count++;
                }
            }
            return count;

        }
        //A function that return true if num is in q
        public static bool IsIn(Queue<int> q, int num)
        {
            Queue<int> check = q;
            while (!check.IsEmpty())
            {
                if (check.Remove() == num)
                {
                    return true;
                }
            }
            return false; ;
        }
        //Q6
        //A function that gets a queue<int> with an even number of elements and no repeated numbers
        //removes all the lower half of the queue(if the queue's length if 10 it will remove the 5 lowest numbers)
        public static void RemoveLowestHalf(Queue<int> q)
        {
            Stack<int> stack = new Stack<int>();
            int length = 0;
            while (!q.IsEmpty())
            {
                stack.Push(q.Remove());
                length++;
            }
            for (int i = 0; i < (length / 2); i++)
            {
                RemoveMaxInStack(stack);
                Console.WriteLine(q.ToString());
            }
            while (!stack.IsEmpty())
            {
                q.Insert(stack.pop());
            }

        }
        //A side function that gets the stack and removes the hightest number
        public static void RemoveMaxInStack(Stack<int> S)
        {
            Stack<int> S2 = new Stack<int>();
            Stack<int> S3 = new Stack<int>();
            int max = S.Top();
            while (!S.IsEmpty())
            {
                if (S.Top() > max)
                {
                    S2.Push(max);
                    max = S.Top();
                    S3.Push(S.pop());
                }
                else if (S.Top() == max)
                {
                    S2.Push(S.pop());
                    S.pop();
                }
                else
                {
                    S2.Push(S.pop());
                }
            }
            while (!S2.IsEmpty())
            {
                S.Push(S2.pop());
            }
        }
        //Q7
        //A function that removes the two greatest number from every 3 number in a given queue<int>
        public static void RemoveForEveryThree(Queue<int> q)
        {
            Queue<int> dump = new Queue<int>();
            Queue<int> temp = new Queue<int>();
            int num;
            bool Should_work = true;
            bool Dont_break = true;
            while (!q.IsEmpty())
            {
                temp.Insert(q.Remove());
            }
            while (Should_work)
            {
                num = temp.Head();
                q.Insert(temp.Remove());
                for (int i = 0; i < 2 & Dont_break; i++)
                {
                    if (temp.Head() >= num)
                    {
                        dump.Insert(temp.Remove());
                    }
                    else
                    {
                        dump.Insert(temp.Remove());
                        q.Insert(temp.Remove());
                    }
                }
                if (temp.IsEmpty())
                {
                    Should_work = false;
                    Dont_break = false;
                }
            }

        }
        //Q8
        //A function that gets a queue<int> and returnd true if crazy and false if not
        //A crazy function is a function that has a seires with sorted lengths - For example, 1,1,5,5,5,5,6,6,6,6,6,15,15,15,15,15,15,15,15,15 returns true
        public static bool IsCrazyQueue(Queue<int> q)
        {
            int count = 0; //The length of the current series
            int beforeLen = 0; // The length of the series before
            int prev; // Remembers the q.Remove()
            bool Run = true; //Tells the second while if it should work
            while (!q.IsEmpty())
            {
                prev = q.Remove();
                if (q.IsEmpty())
                {
                    Run = false;
                }
                while (Run && prev == q.Head())
                {
                    count++;
                }
                if (count <= beforeLen)
                {
                    return false;
                }
                beforeLen = count;

            }
            return true;
        }
        //Q9
        //A function that gets a Queue<int> and returns true if every element if greater then the sum of all the others after it else returns false
        public static bool IsSumSorted(Queue<int> q)
        {
            while (!q.IsEmpty())
            {
                if (!IsGreaterThenSum(q))
                {
                    return false;
                }
            }
            return true;
        }
        //A Side function that said if the Top element if greater then the sum of all the numbers after him
        public static bool IsGreaterThenSum(Queue<int> q)
        {
            Queue<int> newq = new Queue<int>();
            int sum = 0;
            int element = q.Remove();
            while (!q.IsEmpty())
            {
                sum += q.Head();
                newq.Insert(q.Remove());
            }
            while (!newq.IsEmpty())
            {
                q.Insert(newq.Remove());
            }
            if (element > sum)
            {
                return true;
            }
            return false;
        }
        //Q10
        //A function that gets a Queue<int> and an int and returns true if there are two numbers with the value of the int
        public static bool HasTwoX(Queue<int> q, int x)
        {
            bool Found = false; // True is seen one x already, false if not
            while (!q.IsEmpty())
            {
                if (q.Head() == x && Found)
                {
                    return true;
                }
                if (q.Remove() == x)
                {
                    Found = true;
                }
            }
            return false;
        }
        //Q11
        //A function that gets a queue<int> and a positive int and returns true a series with the sum of the int exists in the queue, else false
        public static bool HasSumSeriesX(Queue<int> q, int x)
        {
            while (!q.IsEmpty())
            {
                if (SideHasSumSeries(q, x))
                {
                    return true;
                }
                q.Remove();
            }
            return false;
        }
        //A side function that gets a queue<int> and an int and says if it has a series with the sum in the int(Only from the queue's start)
        public static bool SideHasSumSeries(Queue<int> q, int x)
        {
            int sum = 0;//The sum of the series so far
            while (!(sum > x))
            {
                sum += q.Head();
                if (sum == x)
                {
                    return true;
                }
            }
            return false;
        }
        //Q12
        //A function that gets two queue<int> and returns a third one with the avrege of every student
        public static Queue<int> GetsAvreges(Queue<int> q1, Queue<int> q2)
        {
            int sum = 0;
            int devider;
            Queue<int> q3 = new Queue<int>();
            while (!q1.IsEmpty())
            {
                devider = q2.Head();
                for (int i = 0; i < q2.Head(); i++)
                {
                    sum += q1.Remove();
                }
                q2.Remove();
                q3.Insert(sum / devider);
                sum = 0;
            }
            return q3;
        }
        //Q13
        //A function that gets a queue<int> and returns how many elements are greater then the one after them and before them
        public static int HowManyGreater(Queue<int> q)
        {
            int count = 0;
            int prev = q.Remove();
            int middle = q.Remove();
            while (!q.IsEmpty())
            {
                if (middle > prev && middle > q.Head())
                {
                    count++;
                }
                prev = middle;
                middle = q.Remove();
            }
            return count;
        }
        //Q14
        //A function that gets a queue<int> and returns how many numbers exist more than once
        public static int MoreThanOnce(Queue<int> q)
        {
            int count;
            int main_count = 0;
            int x;
            Queue<int> temp = new Queue<int>();
            while (!q.IsEmpty())
            {
                count = 1;
                x = q.Remove();
                while (!q.IsEmpty())
                {
                    if (q.Head() == x)
                    {
                        count++;
                        q.Remove();
                    }
                    else
                    {
                        temp.Insert(q.Remove());
                    }
                }
                if (count > 1)
                {
                    main_count++;
                }
                count = 1;
                x = temp.Remove();
                while (!temp.IsEmpty())
                {
                    if (temp.Head() == x)
                    {
                        count++;
                        temp.Remove();
                    }
                    else
                    {
                        q.Insert(temp.Remove());
                    }
                }
                if (count > 1)
                {
                    main_count++;
                }
            }
            return main_count;
        }
        //Q15
        //A function that gets a queue<int> and returns a new queue of the sums of the edges(first with last, second with prev to last and so on)
        public static Queue<int> SumsOfAllEdges(Queue<int> q)
        {
            Queue<int> final = new Queue<int>();
            while (!q.IsEmpty())
            {
                final.Insert(SumOfEdge(q));
            }
            return final;
        }
        //A side function that gets the sum of the first and last element
        public static int SumOfEdge(Queue<int> q)
        {
            int sum = 0;
            Queue<int> temp = new Queue<int>();
            Queue<int> newq = new Queue<int>();
            while (!q.IsEmpty())
            {
                temp.Insert(q.Head());
                newq.Insert(q.Remove());
            }
            int TimesToRun = LengthQueue(newq);
            newq.Remove();
            for (int i = 1; i < TimesToRun - 1; i++)
            {
                q.Insert(newq.Remove());
            }
            int first = temp.Remove();
            while (!temp.IsEmpty())
            {
                sum = temp.Remove();
            }
            sum += first;
            return sum;
        }
        //A side function that gets the length of a queue
        public static int LengthQueue(Queue<int> q)
        {
            int Length = 0;
            Queue<int> newq = new Queue<int>();
            while (!q.IsEmpty())
            {
                newq.Insert(q.Remove());
            }
            while (!newq.IsEmpty())
            {
                Length++;
                q.Insert(newq.Remove());
            }
            return Length;
        }
        //Q16 
        //A function that gets a Queue<char>(a legal one) and returns the length of the longest word
        public static int MaxLengthWord(Queue<char> q)
        {
            int length; //The length of the current word
            int MaxLength = 0; // The length of the longest work until now
            while (!q.IsEmpty())
            {
                length = 0;
                while (!q.IsEmpty() && q.Remove() != char.Parse(" "))
                {
                    length++;
                }
                if (length > MaxLength)
                {
                    MaxLength = length;
                }
            }
            return MaxLength;
        }
        //O(N^2)
        //Q17
        //A function that gets a Queue<int> and return the max sum of two close elements in the queue
        public static int MaxSumClose(Queue<int> q)
        {
            int sum; //The current sum
            int first; //The first elemnt
            int second; //The second element
            int MaxSum = 0;//The biggest sum so far
            while (!q.IsEmpty())
            {
                first = q.Remove();
                if (!q.IsEmpty())
                {
                    second = q.Head();
                    sum = first + second;
                    if (sum > MaxSum)
                    {
                        MaxSum = sum;
                    }
                }
            }
            return MaxSum;
        }
        //Q18
        //A Balarin Queue:1.Not empty, 2.Has an even length, 3.For every element in the first half there is a simular one in the second
        //A function that returns true if it's a Balatin queue and false if not
        //Note - I used a side function that gets the length of a queue - LengthQueue (Look at Q15)
        public static bool IsBalarin(Queue<int> q)
        {
            if (q.IsEmpty() || LengthQueue(q) % 2 == 1)
            {
                return false;
            }
            Queue<int> first = new Queue<int>(); //A queue for the first half
            Queue<int> second = new Queue<int>(); //A queue for the second half
            for (int i = 0;i < LengthQueue(q) / 2; i++)
            {
                first.Insert(q.Remove());
            }
            while (!q.IsEmpty())
            {
                second.Insert(q.Remove());
            }
            while (!first.IsEmpty())
            {
                if (!IsNumInQueue(second, first.Remove()))
                {
                    return false;
                }
            }
            return true;
        }
        //A side function that gets a queue and a number, returns true if the number is in the queue and flse if not
        public static bool IsNumInQueue(Queue<int> q, int num)
        {
            Queue<int> temp = new Queue<int>();
            bool found = false;
            while (!q.IsEmpty())
            {
                temp.Insert(q.Head());
                if (q.Remove() == num)
                {
                    found = true;
                }
            }
            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
            return found;
        }
        //O(n)
        //Q19
        //A function that gets a Queue<int> and after every seires of the same number(bigger then two) adds the length of the series
        public static void AddLengthsSeries(Queue<int> q)
        {
            Queue<int> lengths = new Queue<int>(); //A Queue of all the lengths
            Queue<int> temp = new Queue<int>(); //Will be temporarlly q 
            Queue<int> newq = new Queue<int>(); //A copy of q
            int current; //The currrent number of the seires
            int length; //The length of the current series
            while (!q.IsEmpty())
            {
                newq.Insert(q.Head());
                temp.Insert(q.Remove());
            }
            while (!newq.IsEmpty())
            {
                Console.WriteLine(newq.ToString());
                length = 0;
                current = newq.Head();
                while (!newq.IsEmpty() && newq.Head() == current)
                {
                    length++;
                    newq.Remove();
                }
                if (length > 1)
                {
                    lengths.Insert(length);
                }
            }
            Console.WriteLine(lengths.ToString());
            while (!temp.IsEmpty())
            {
                current = temp.Head();
                length = 0;
                while (!temp.IsEmpty() && temp.Head() == current)
                {
                    q.Insert(temp.Remove());
                    length++;
                }
                if (length > 1)
                {
                    q.Insert(lengths.Remove());
                }
            }
        }
        //O(n^2)
        //Q20
        //A function that gets two sorted from small to big Queue<int> and returns a thired one sorted and has the two Queue<int>
        public static Queue<int> MergeSort(Queue<int> q1, Queue<int> q2)
        {
            Queue<int> q3 = new Queue<int>(); //The thired queue
            while(!q1.IsEmpty() && !q2.IsEmpty())
            {
                if (q1.Head() > q2.Head())
                {
                    q3.Insert(q2.Remove());
                }
                else if(q1.Head() <= q2.Head())
                {
                    q3.Insert(q1.Remove());
                }
            }
            while (!q2.IsEmpty())
            {
                q3.Insert(q2.Remove());
            }
            while (!q1.IsEmpty())
            {
                q3.Insert(q1.Remove());
            }
            return q3;
        }
        //O(n)
        //Q21
        //A function that gets a Queue of prices and returns the price that should be paid by the sale rulls
        public static int Price(Queue<int> q)
        {
            int first = 0; //The price of the first product
            int sec = 0; //The price of the second product
            int price = 0; //The final price the customer needs to pay
            SortQueue(q);
            while (!q.IsEmpty())
            {
                first = q.Remove();
                if (!q.IsEmpty())
                {
                    sec = q.Remove();
                    price += Math.Max(first, sec);
                }
                else
                {
                    price += first;
                }
                
                
            }
            return price;
        }
        public static void SortQueue(Queue<int> q)
        {
            Queue<int> temp = new Queue<int>();
            Queue<int> temp2 = new Queue<int>();
            int Max = q.Head(); //The Max number in q
            while (!q.IsEmpty())
            {
                if(q.Head() > Max)
                {
                    Max = q.Head();
                }
                temp.Insert(q.Remove());
            }
            while (!temp.IsEmpty())
            {
                if(temp.Head() != Max)
                {
                    temp2.Insert(temp.Remove());
                    
                }
                else
                {
                    q.Insert(temp.Remove());
                }
            }
            while(!temp2.IsEmpty())
            {
                SortQueue(temp2);
                q.Insert(temp2.Remove());
            }
        }
        //O(n)
        //Q22
        //A function that gets a queue, returns a queue with the sums of the series
        public static Queue<int> SumsOfSeries(Queue<int> q)
        {
            Queue<int> final = new Queue<int>(); //The queue that will be returned
            int sum; //The sum of the current series up till now
            int prev; //The number before the current now (if prev > current it's the end of the seires)
            while(!q.IsEmpty())
            {
                sum = q.Head();
                prev = q.Remove();
                while (!q.IsEmpty() && prev < q.Head())
                {
                    prev = q.Head();
                    sum += q.Remove();    
                }
                final.Insert(sum);
            }
            return final;
        }
        //O(n^2)
        //Q23
        //A function that gets a queue<int> and removes all the numbers between the two simular numbers(thier are only one pair)
        public static void RemoveBetween(Queue<int> q)
        {
            int repeated = -999; //The number that is repeated
            bool Found = false; //True when repeated was found(for the while loop to be more efficient
            Queue<int> temp = new Queue<int>();
            Queue<int> newq = new Queue<int>(); //A copy for q
            while (!q.IsEmpty())
            {
                newq.Insert(q.Head());
                temp.Insert(q.Remove());
            }
            while (!Found)
            {
                if (IsTwice(temp, newq.Head()))
                {
                    repeated = newq.Head();
                    Found = true;
                }
                newq.Remove();
            }
            while (temp.Head() != repeated)
            {
                q.Insert(temp.Remove());
            }
            temp.Remove();
            while (temp.Head() != repeated)
            {
                temp.Remove();
            }
            temp.Remove();
            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
        }
        //A side function that gets a queue<int> and a number, returns true if the numebr appears twice else false
        public static bool IsTwice(Queue<int> q, int num)
        {
            bool Found = false; //True when the number was seen once
            bool twice = false; //True when the number was seen twice
            Queue<int> temp = new Queue<int>();
            Queue<int> newq = new Queue<int>(); //A copy for q
            while (!q.IsEmpty())
            {
                newq.Insert(q.Head());
                temp.Insert(q.Remove());
            }
            while (!newq.IsEmpty())
            {
                if(newq.Remove() == num)
                {
                    if(Found == true)
                    {
                        twice = true;
                    }
                    else
                    {
                        Found = true;
                    }
                }
            }
            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
            return twice;
        }
        //O(n)
        //Q24
        //A functoin that gets a queue<int>, retunrs true if a polindrom and flase if not
        public static bool IsPolindrom(Queue<int> q)
        {
            Stack<int> stack = new Stack<int>(); //A stack to help check the symmetry of the queue
            int length = LengthQueue(q);
            for (int i = 0; i < (length / 2); i++)
            {
                stack.Push(q.Remove());
            }
            if (length % 2 == 1)
            {
                q.Remove();
            }
            while (!q.IsEmpty())
            {
                if (q.Remove() != stack.pop())
                {
                    return false;
                }
            }
            return true;
        }
        //Q25
        //A function that gets two stacks<int> and returns true if every element in the first exists in the second, else false
        public static bool IsOneInSec(Stack<int> first, Stack<int> second)
        {
            while(!first.IsEmpty() && !second.IsEmpty())
            {
                if(!IsNumIn(second, first.pop()))
                {
                    return false;
                }
            }
            return true;
        }
        //O(n)
        //Page 151 - exercise 2
        //A function that gets a Queue<Time> and return the time diffrence between the first and last one
        public static Time TimeDiffrence(Queue<Time> q)
        {
            Queue<Time> replacment = new Queue<Time>();
            Queue<Time> GetLast = new Queue<Time>();
            while (!q.IsEmpty())
            {
                replacment.Insert(q.Head());
                GetLast.Insert(q.Remove());
            }
            Time Worset = GetLast.Head();
            if (replacment.IsEmpty())
            {
                Time empty = new Time(0, 0, 0);
                return empty;
            }
            while (!GetLast.IsEmpty())
            {
                Worset = GetLast.Head();
                GetLast.Remove();
            }
            Time Diffrence = new Time(Worset.Gethour() - replacment.Head().Gethour(), Worset.Getminute() - replacment.Head().Getminute(), Worset.Getsecond() - replacment.Head().Getsecond());
            return Diffrence;
        }
        //Page 152 - Exercise 6
        //A function that gets a Queue<Job> and an int representing time, prints all the jobs (thier code) that can be done in that time
        public static void PrintJobsPosiable(Queue<Job> q, int time)
        {
            while (!q.IsEmpty())
            {
                if (q.Head().Gettime() < time)
                {
                    Console.WriteLine(q.Remove().Getcode());
                }
                else
                {
                    q.Remove();
                }
            }
        }
        //Random exercise
        //A function that gets a Queue<int> and an int (k), removes k elements from the middle of the queue
        public static void RemoveKMiddle(Queue<int> q, int k)
        {
            int length = LengthQueue(q);
            Queue<int> q2 = new Queue<int>();
            if (k <= length)
            {
                while (!q.IsEmpty())
                {
                    q2.Insert(q.Remove());
                }
                if (k % 2 == 0 || (k % 2 == 1 && length % 2 == 1))
                {
                    for (int i = 0; i < ((length / 2) - (k / 2)); i++)
                    {
                        q.Insert(q2.Remove());
                    }
                    for (int i = 0; i < k; i++)
                    {
                        q2.Remove();
                    }
                    while (!q2.IsEmpty())
                    {
                        q.Insert(q2.Remove());
                    }
                }
                else
                {
                    for (int i = 0; i < ((length / 2) - (k / 2) - 1); i++)
                    {
                        q.Insert(q2.Remove());

                    }
                    for (int i = 0; i < k; i++)
                    {
                        q2.Remove();
                    }
                    while (!q2.IsEmpty())
                    {
                        q.Insert(q2.Remove());
                        
                    }
                }
            }
            else
            {
                Console.WriteLine("The integer was too big sorry");
            }
        }
        //BinNode
        //Page 176 - Exercise 8
        //A
        //A function that gets a BinNode<int> and prints all the negative numbers in a final order
        public static void PrintsNegative(BinNode<int> t)
        {
            Stack<int> stack = new Stack<int>();
            if (t != null)
            {
                if (t.Getvalue() < 0)
                {
                    stack.Push(t.Getvalue());
                }
                PrintsNegative(t.Getleft());
                PrintsNegative(t.Getright());
            }
            while (!stack.IsEmpty())
            {
                Console.WriteLine(stack.pop());
            }

        }
        //B
        //A function that gets a BinNode<int> and prints all the left sons
        public static void PrintLeftSons(BinNode<int> t)
        {
            if (t.Hasleft())
            {
                Console.WriteLine(t.Getleft().Getvalue());
                PrintLeftSons(t.Getleft());
            }
        }
        //C
        //A function that builds a BinNode<int>, if the root of the tree in positive the function will print all the positive numbers in the tree by stating scan
        //and if the root is negative the function will print all the left sons
        //Not Done!!
        public static void BuildAndPrint(BinNode<int> t)
        {
            if (t != null)
            {
                if (t.Getvalue() > 0)
                {
                    PrintsPositive(t);
                }
                else
                {
                    PrintLeftSons(t);
                }
            }
        }
        //A side function simular to A but preorder and positive
        public static void PrintsPositive(BinNode<int> t)
        {
            if (t != null)
            {
                Console.WriteLine(t.Getvalue());
                if (t.Hasleft())
                {
                    if (t.Getleft().Getvalue() % 2 == 0)
                    {
                        Console.WriteLine(t.Getleft().Getvalue());
                    }
                    BuildAndPrint(t.Getleft());
                }
                if (t.Hasright())
                {
                    if (t.Getright().Getvalue() % 2 == 0)
                    {
                        Console.WriteLine(t.Getright().Getvalue());
                    }
                    BuildAndPrint(t.Getright());
                }
            }
        }
        //Page 189 - Exercise 44
        //A function that gets a BinNode<int>, returns true if the tree if sorted else false
        public static bool IsSortedTree(BinNode<int> T)
        {
            if(T != null)
            {
                if(T.Hasleft() && T.Getleft().Getvalue() > T.Getvalue())
                {
                    return false;
                }
                if (T.Hasright() && T.Getright().Getvalue() < T.Getvalue())
                {
                    return false;
                }
                IsSortedTree(T.Getleft());
                IsSortedTree(T.Getright());
            }
            return true;
        }
        //Page 189 - Exercise 45
        //A function that gets a sorted Tree and returns a sorted list
        public static Node<int> SortedTreeToSortedList(BinNode<int> t)
        {
            Node<int> lst = new Node<int>(0);
            SortedTreeToSortedList(t, lst);
            return lst.Getnext();
        }
        public static void SortedTreeToSortedList(BinNode<int> t, Node<int> L)
        {
            Node<int> lst = new Node<int>(0);
            if (t != null && L.Getnext() != null)
            {
                SortedTreeToSortedList(t.Getleft(), L);
                L.Getnext().Setvalue(t.Getvalue());
                lst = L.Getnext();
                SortedTreeToSortedList(t.Getright(), L);
                lst = L.Getnext();
            }
            L = lst;
        }
        //Page 189 - Exercise 46
        //A function that gets an empty BinNode (at first) and gets numbers untill gets -999 and builds a tree that every number exists only once
        public static BinNode<int> InputToTree(BinNode<int> t)
        {
            int num = Int32.Parse(Console.ReadLine());
            BinNode<int> tree = new BinNode<int>(num); 
            if (num != -999)
            {
                if (num < t.Getvalue())
                {
                    t.Setleft(tree);
                    return InputToTree(t.Getleft());
                }
                else
                {
                    t.Setright(tree);
                    return InputToTree(t.Getright());
                }
            }
            else
            {
                return t;
            }

        } 
        public static BinNode<int> yuvalNeb()
        {
            int num = int.Parse(Console.ReadLine());
            BinNode<int> tree = new BinNode<int>(num);  
            while (num == -999)
            {
                yuvalNeb(tree, num);
                num = int.Parse(Console.ReadLine());
                return tree;
            }
            return yuvalNeb();
        }
        public static BinNode<int> yuvalNeb(BinNode<int> t, int num)
        {
            if (num > t.Getvalue())
            {
                yuvalNeb(t.Getright(), num);
            }
            if (num < t.Getvalue())
            {
                yuvalNeb(t.Getright(), num);
            }
            return t;
        }
        public static BinNode<int> pipipopo()
        {
            int num = int.Parse(Console.ReadLine());
            BinNode<int> tree = new BinNode<int>(num);
            BinNode<int> p = new BinNode<int>(num);
            if (num == -999)
            {
                return tree;
            }
            else if (num > tree.Getvalue())
            {
                tree.Setright(p);
                return pipipopo(tree);
            }
            else
            {
                tree.Setleft(p);
                return pipipopo(tree);
            }
        }
        public static BinNode<int> pipipopo(BinNode<int> t)
        {
            int num = int.Parse(Console.ReadLine());
            BinNode<int> p = new BinNode<int>(num);
            if (num == -999)
            {
                return t;
            }
            else if (num > t.Getvalue())
            {
                t.Setright(p);
                return pipipopo(t.Getright());
            }
            else
            {
                t.Setleft(p);
                return pipipopo(t.Getleft());
            }
        }
        //Exercise page on binery trees
        //Q1
        //A function that gets a binary tree of integers and prints the tree at postorder
        public static void PrintPostOrder(BinNode<int> T)
        {
            if (T.Hasleft())
            {
                PrintPostOrder(T.Getleft());
            }
            if (T.Hasright())
            {
                PrintPostOrder(T.Getright());
            }
            Console.WriteLine(T.Getvalue());
        }
        //Q2
        //A function that gets a binary tree of integers and prints all the leefs from left to right
        public static void PrintLeaves(BinNode<int> T)
        {
            if (T.Hasleft())
            {
                PrintLeaves(T.Getleft());
            }
            if (T.Hasright())
            {
                PrintLeaves(T.Getright());
            }
            if (!T.Hasleft() && !T.Hasright())
            {
                Console.WriteLine(T.Getvalue());
            }
        }
        //Q3
        //A function that gets a binary tree of integers and prints all the right sons by preorder
        public static void PrintRightSons(BinNode<int> T)
        {
            if (T.Hasleft())
            {
                PrintRightSons(T.Getleft());
            }
            if (T.Hasright())
            {
                Console.WriteLine(T.Getright().Getvalue());
                PrintRightSons(T.Getright());
            }
        }
        //Q4
        //A function that gets a binary tree of integers and prints all the sons that have a lower value than their fathers
        public static void PrintLowerSons(BinNode<int> T)
        {
            if(T == null)
            {
                return;
            }
            if (T.Hasleft() && T.Getvalue() > T.Getleft().Getvalue())
            {
                PrintLowerSons(T.Getleft());
                PrintLowerSons(T.Getright());
                Console.WriteLine(T.Getleft().Getvalue());
            }
            if (T.Hasright() && T.Getvalue() > T.Getright().Getvalue())
            {
                PrintLowerSons(T.Getleft());
                PrintLowerSons(T.Getright());
                Console.WriteLine(T.Getright().Getvalue());
            }
           
        }
        //Q5
        //A function that gets a binary tree of integers and prints all the fathers that has two sons and that have a higher value from at least one of them
        public static void PrintBigFathers(BinNode<int> T)
        {
            if(T.Hasleft() && T.Hasright())
            {
                if(T.Getvalue() > T.Getleft().Getvalue() || T.Getvalue() > T.Getright().Getvalue())
                {
                    Console.WriteLine(T.Getvalue());
                    PrintBigFathers(T.Getleft());
                    PrintBigFathers(T.Getright());
                }
            }
            if(T.Hasleft() && !T.Hasright())
            {
                PrintBigFathers(T.Getleft());
            }
            if (!T.Hasleft() && T.Hasright())
            {
                PrintBigFathers(T.Getright());
            }
        }
        //Q6
        //A function that gets a binary tree of integers and return the sum of it
        public static int SumOfTree(BinNode<int> T)
        {
            if (T != null)
            {
                return T.Getvalue() + SumOfTree(T.Getleft()) + SumOfTree(T.Getright());
            }
            return 0;
        }
        //Q7
        //A function that gets a binary tree of integers and return the number of leefs
        public static int NumOfLeefs(BinNode<int> T)
        {
            if (T == null)
            {
                return 0;
            }
            if(!T.Hasleft() && !T.Hasright())
            {
                return 1;
            }
            return NumOfLeefs(T.Getleft()) + NumOfLeefs(T.Getright());
        }
        //Q8
        //A function that gets a binary tree of integers and return the sum of the right sons
        public static int SumOfRightSons(BinNode<int> T)
        {
            if (T == null)
            {
                return 0;
            }
            int sum = 0;
            if (T.Hasright())
            {
                sum += T.Getright().Getvalue();
            }
            sum += SumOfRightSons(T.Getright());
            sum += SumOfRightSons(T.Getleft());
            return sum;
        }
        //Q9
        //A function that gets a binary tree of integers and returns the number of only sons it has
        public static int CountOnlySons(BinNode<int> T)
        {
            if (T == null)
            {
                return 0;
            }
            int count = 0;
            if (T.Hasleft() && !T.Hasright() || !T.Hasleft() && T.Hasright())
            {
                count = 1;
            }
            return count + CountOnlySons(T.Getleft()) + CountOnlySons(T.Getright());
        }
        //Q10
        //A function that gets a binary tree of integers and returns the number of even numbers in the tree
        public static int CountEven(BinNode<int> T)
        {
            if (T == null)
            {
                return 0;
            }
            int count = 0;
            if (T.Getvalue() % 2 == 0)
            {
                count = 1;
            }
            return count + CountEven(T.Getleft()) + CountEven(T.Getright());
        }
        //Q11
        //A function that gets a binary tree of integers and an integer, it returns the number of numbers in the tree that matches the integer
        public static int CountX(BinNode<int> T, int X)
        {
            if (T == null)
            {
                return 0;
            }
            int count = 0;
            if (T.Getvalue() == X)
            {
                count = 1;
            }
            return count + CountX(T.Getright(), X) + CountX(T.Getright(), X);
        }
        //Q12
        //A functoin that gets a binary tree of integers and returns the number of grandpas
        public static int CountGrandpas(BinNode<int> T)
        {
            if (T == null)
            {
                return 0;
            }
            int count = 0;
            if (IsGrandFather(T))
            {
                count = 1;
            }
            return count + CountGrandpas(T.Getleft()) + CountGrandpas(T.Getright());
        }
        //A side function that gets a binary tree and returns true if he is a father
        public static bool IsFather(BinNode<int> T)
        {
            if(T.Hasleft() || T.Hasright())
            {
                return true;
            }
            return false;
        }
        //A side function that gets a binary tree and returns true if he is a Grandfather
        public static bool IsGrandFather(BinNode<int> T)
        {
            if(T.Hasleft() && IsFather(T.Getleft()) || T.Hasright() && IsFather(T.Getright()))
            {
                return true;
            }
            return false;
        }
        //Q13
        //A function that gets a binary tree and return the sum of all the odd only children
        public static int SumOddOnlyChild(BinNode<int> T)
        {
            if(T == null)
            {
                return 0;
            }
            int sum = 0;
            if (T.Hasleft() && !T.Hasright())
            {
                if(T.Getleft().Getvalue() % 2 == 1)
                {
                    sum += T.Getleft().Getvalue();
                }
            }
            if(!T.Hasleft() && T.Hasright())
            {
                if (T.Getright().Getvalue() % 2 == 1)
                {
                    sum += T.Getright().Getvalue();
                }
            }
            return sum + SumOddOnlyChild(T.Getleft()) + SumOddOnlyChild(T.Getright());
        }
        //Q14
        //A function that gets a binary tree and returns the amount of trees with two identical sons
        public static int CountFatherWithIdenticalSons(BinNode<int> T)
        {
            if (T == null)
            {
                return 0;
            }
            int count = 0;
            if (T.Hasleft() && T.Hasright() && T.Getleft().Getvalue() == T.Getright().Getvalue())
            {
                count = 1;
            }
            return count + CountFatherWithIdenticalSons(T.Getleft()) + CountFatherWithIdenticalSons(T.Getright());
        }
        //Q15
        //A function that gets a binary tree and returns the amount of fathers that have at least one son with a higher value
        public static int CountBigFather(BinNode<int> T)
        {
            if (T == null)
            {
                return 0;
            }
            int count = 0;
            if (T.Hasleft() && T.Getleft().Getvalue() > T.Getvalue() || T.Hasright() && T.Getright().Getvalue() > T.Getvalue())
            {
                count = 1;
                Console.WriteLine(T.Getvalue());
            }
            return count + CountBigFather(T.Getleft()) + CountBigFather(T.Getright());
        }
        //Q16
        //A function that gets a binary treee and returns the amount of numbers higher then their fathers
        public static int CountLowerSons(BinNode<int> T)
        {
            if (T == null)
            {
                return 0;
            }
            int count = 0;
            if (T.Hasleft() && T.Getvalue() > T.Getleft().Getvalue())
            {
                count++;
            }
            if (T.Hasright() && T.Getvalue() > T.Getright().Getvalue())
            {
                count++;
            }
            return count + CountLowerSons(T.Getleft()) + CountLowerSons(T.Getright());
        }
        //Q17
        //A function that gets a binary tree and a ingeger presenting a level, returns how many element their are on this level
        public static int CountElementInLevel(BinNode<int> T, int L)
        {
            if (T == null)
            {
                return 0;
            }
            if (L == 0) { return 1; }
            return CountElementInLevel(T.Getright(), L - 1) + CountElementInLevel(T.Getleft(), L - 1);
            

        }
        static void Main(string[] args)
        {
            //Node<int> list = new Node<int>(8, new Node<int>(2, new Node<int>(5, new Node<int>(7, new Node<int>(8, new Node<int>(2, new Node<int>(1, new Node<int>(6))))))));
            //Node<int> lst = new Node<int>(8, new Node<int>(2, new Node<int>(1)));
            //Node<int> list2 = new Node<int>(1, new Node<int>(7, new Node<int>(4, new Node<int>(9, new Node<int>(34, new Node<int>(0, new Node<int>(-5, new Node<int>(1))))))));

            //Queue<Time> q = new Queue<Time>();
            //q.Insert(new Time(1, 25, 44));
            //q.Insert(new Time(2, 05, 48));
            //q.Insert(new Time(4, 33, 48));


            //Console.WriteLine(CombinedList(list, lst));
            //Circular list
            //Node<int> cell4 = new Node<int>(4, null);
            //Node<int> cell3 = new Node<int>(8, cell4);
            //Node<int> cell2 = new Node<int>(8, cell3);
            //Node<int> cell1 = new Node<int>(1, cell2);
            //Node<int> head = new Node<int>(0, cell1);
            //cell4.Setnext(head);
            //Node<int> L = Removenum(head, 8);
            //Console.WriteLine(L.ToString());


            //Node<int> list = new Node<int>(8, new Node<int>(2, new Node<int>(4, new Node<int>(5, new Node<int>(8, new Node<int>(8))))));

            //Stack runs
            //Stack<Couple> stack = new Stack<Couple>();
            //stack.Push(new Couple(2,5));
            //stack.Push(new Couple(0,4));
            //stack.Push(new Couple(3,0));
            //stack.Push(new Couple(4,6));
            //stack.Push(5);
            //stack.Push(8);
            //stack.Push(1);
            //stack.Push(2);
            //Stack<int> S2 = CoupleToInt(stack);
            //Console.WriteLine(S2.ToString());
            Queue<int> q = new Queue<int>();
            q.Insert(1);
            q.Insert(2);
            //q.Insert(3);
            //q.Insert(4);
            //q.Insert(5);
            //q.Insert(6);
            //q.Insert(7);
            //q.Insert(8);
            //q.Insert(9);
            //q.Insert(10);
            //q.Insert(11);
            //q.Insert(2);
            //q.Insert(4);
            //q.Insert(-41);
            //q.Insert(12);
            //q.Insert(6);
            //q.Insert(6);
            //q.Insert(6);
            //q.Insert(6);
            //q.Insert(4);
            //q.Insert(2);
            Queue<int> q2 = new Queue<int>();
            q2.Insert(5);
            q2.Insert(6);
            q2.Insert(7);
            q2.Insert(12);
            q2.Insert(30);
            q2.Insert(53);
            q2.Insert(102);
            q2.Insert(224);
            Queue<char> charq = new Queue<char>();
            charq.Insert(char.Parse("M"));
            charq.Insert(char.Parse("Y"));
            charq.Insert(char.Parse(" "));
            charq.Insert(char.Parse("N"));
            charq.Insert(char.Parse("A"));
            charq.Insert(char.Parse("M"));
            charq.Insert(char.Parse("E"));
            charq.Insert(char.Parse(" "));
            charq.Insert(char.Parse("I"));
            charq.Insert(char.Parse("S"));
            charq.Insert(char.Parse(" "));
            charq.Insert(char.Parse("Y"));
            charq.Insert(char.Parse("A"));
            charq.Insert(char.Parse("H"));
            charq.Insert(char.Parse("E"));
            charq.Insert(char.Parse("L"));
            charq.Insert(char.Parse("I"));
            //Stack<int> stak = new Stack<int>();
            //stak.Push(1);
            //stak.Push(2);
            //stak.Push(3);
            //stak.Push(10);
            //stak.Push(5);
            //stak.Push(6);
            //stak.Push(7);
            //stak.Push(8);
            //Stack<int> stak2 = new Stack<int>();
            //stak2.Push(1);
            //stak2.Push(8);
            //stak2.Push(6);
            //stak2.Push(3);
            //stak2.Push(4);
            //stak2.Push(9);

            BinNode<int> Tree = new BinNode<int>(new BinNode<int>(new BinNode<int>(5), 17, new BinNode<int>(21)), 20, new BinNode<int>(new BinNode<int>(18), 34, new BinNode<int>(null, 70, new BinNode <int>(45))));
            Console.WriteLine(CountElementInLevel(Tree, 5));
            Console.ReadLine();
        }
    }
}

