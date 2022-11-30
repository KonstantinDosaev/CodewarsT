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
