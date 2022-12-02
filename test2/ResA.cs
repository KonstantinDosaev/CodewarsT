using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace test2
{
    internal class ResA
    {
        // возвести 5 в количество цифр в number е и умножить это на number
        public static int Multiply(int number )
        {
            return number*(int)Math.Pow(5, number.ToString().Length);
        }

        //factorial
        protected int FacRecursion(int value)
        {
            return value switch
            {
                1 => 1,
                < 0 => 0,
                0 => 1,
                _ => value * FacRecursion(value - 1)
            };
        }



        //найти ЦИФРЫ в строке и удалить
        public static string? FilterNumbers(string str)
        {
            return new Regex(@"(\d)+").Replace(str, "");
            //return string.Concat(str.Where(c => !char.IsNumber(c)));
            //return new string(str.Where(c => !Char.IsDigit(c)).ToArray());
            //return string.Concat(str.Where(c => !char.IsNumber(c)));
        }


        // получить следующее идеальное квадратное число(sqrt(n) также является целым числом)

        public static long FindNextSquare(long num)
        {
            long r = (long)Math.Sqrt(num);
            if (r * r == num) return -1;
            return ((r + 1) * (r + 1));


        }

        //вывести корень из deccimal не уходя в duble

        private static decimal SquereR(decimal square)
        {
            if (square < 0) return 0;

            decimal root = square / 3;
            int i;
            for (i = 0; i < 35; i++)
                root = (root + square / root) / 2;
            return root;
        }


        // проверить правильность расстановки скобок пр.{()[]} или ({[]}) true ; {()(} false
        public static bool CheckBrackets(string braces)
        {

            bool bol = false;
            List<char> myList = braces.ToList(); Stack<char> myStack = new Stack<char>();
            for (int i = 0; i < myList.Count; i++)
            {

                if (myList[i] == '{' || myList[i] == '[' || myList[i] == '(')
                {

                    myStack.Push(myList[i]);

                }
                else
                {
                    if (myStack.Count == 0)
                    {
                        bol = false; break;
                    }
                    var cc = myStack.Pop();
                    if (cc + 0 == myList[i] - 2 | cc + 0 == myList[i] - 1)
                    {
                        bol = true;
                    }
                }
            }

            return bol;
        }


        //удалить все эллементы массива b из a
        public static int[] ArrayDiff(int[] a, int[] b)
        {

            return a.Where(x => !b.Contains(x)).ToArray();
        }

    }










    // исправить счетчик
    public class Counter
    {
        private int _value;
        public int Value
        {
            get
            {
                return _value;
            }
            private set
            {
                _value = value;
            }
        }

        public Counter()
        {
            Value = 0;
        }

        public void Increase()
        {
            ++Value;
        }

        public void Reset()
        {
            Value = 0;
        }
    }
}
