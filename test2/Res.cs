using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace test2
{
    internal class Res
    {
        //все первые буквы слов ToUpper
        public static string R1(string str)
        {
            var s = str.Split().Select(p => char.ToUpper(p[0])+ p.Remove(0,1));

            return String.Join(" ",s);
        }



        //вернуть числа между лимитом пр 5- 25 => {5,10,15,20,25}
        public static List<int> R2(int integer, int limit)
        {
            //var1
            List<int> result = new List<int>(){};
            
            for (int i = 1; i <= limit/integer ; i++ )
                result.Add(integer*i);

            return result;
            //var2
           // return Enumerable.Range(1, limit / integer).Select(x => x * integer).ToList();

        }



        //зашифровать первую буква в  ASII,  и поменять 2 букву с последней 
        public static string R3(string input)
        {
            if (input == "")
                return " ";
            if (input.Length < 2)
             return (input[0] + 0).ToString();

            var s = input.Split().Select((p) =>
            {
                int index = p.Length-1;
                int val = 1;
                if (p.Length == 1)
                {
                    index = 0;
                    val = 0;
                }

                string temp = p.Remove(index, 1).Insert(index, p[val].ToString());//замена
                return temp.Remove(val, 1).Insert(val, p[index].ToString());//замена
            }).Select(p => (p[0] + 0) + p.Remove(0, 1));// шифровка

            return String.Join(" ", s);
        }



        //расшифровать первую буква из ASII,  и поменять 2 букву с последней 
        public static string R4(string s)
        {
            if (s == "")
                return " ";

            // вместо кучи конверции int.Parse(match.Value)

            var sb = s.Split().Select(p => new Regex(@"(\d)+").Replace(p, Convert.ToChar(int.Parse(new Regex(@"(\d)+").Match(p).Value)).ToString())).
                Select((p) =>
                {
                    int index = p.Length - 1;
                    int val = 1;
                    if (p.Length == 1)
                    {
                        index = 0;
                        val = 0;
                    }

                    string temp = p.Remove(index, 1).Insert(index, p[val].ToString());//замена
                    return temp.Remove(val, 1).Insert(val, p[index].ToString());//замена
                });
 
            return String.Join(" ", sb); ;
        }



        //(p => new Regex(@"(\d)+").Replace(p, Convert.ToString(Convert.ToChar(Convert.ToInt32((new Regex(@"(\d)+").Match(p)).ToString())))))
        public static string R5(string[] name)
        {
            if (name.Length == 1)
                return $"{name[0]} likes this";
            if (name.Length == 2)
                return $"{name[0]} and {name[1]} like this";
            if (name.Length == 3)
                return $"{name[0]}, {name[1]} and {name[2]} like this";
            if (name.Length > 3)
                return $"{name[0]}, {name[1]} and {name.Length - 2} others like this";
            return "no one likes this";
        }



        //найти первое меньшее и первое большее правильное число(делится на себя и на 1) от данного числа
        public static long[] R6(long num)
        {
            var a = num;
            var b = num;
            bool checkA = default;
            bool checkB = default;

            do
            {
                a--;
                for (int i = 2; i <= a; i++)
                {
                    if (a % i == 0 && i == a) { checkA = true; }
                    if (a % i == 0) break;
                }
            }
            while (checkA == false);

            do
            {
                b++;
                for (int i = 2; i <= b; i++)
                {
                    if (b % i == 0 && i == b) { checkB = true; break; }
                    if (b % i == 0) { break; }
                }
            }
            while (checkB == false);

            return new long[] { a, b };

        }


        // Вернуть сумму строк ДВУМЕРНОГО МАССИВА помноженую  [,] {n+n+n}*{n+n+n} = int n
        public static int R7(int[,] array)
        {
            int x = 0;
            int y = 1;
            for (int i = 0; i < array.GetLength(0); i++)
            {

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    x += array[i, j];
                }
                y *= x;
                x = 0;
            }
            return y;
            // LINQ!!!!!!!!!!!!!!!!
            //return Enumerable.Range(0, array.GetLength(0))
            //    .Select(x => Enumerable.Range(0, array.GetLength(1)).Sum(i => array[x, i]))
            //    .Aggregate(1, (a, b) => a * b);

        }




        //паук и муха вывести минимальный путь паука паутина A-G 0-4
        public static string SpiderToFly(string spider, string fly)
        {
            var df = "ABCDEFGHABCDEFGH";
            var x = (spider[0] - 65);
            var y = spider[1] - '0';
            var result = "";
            var direction = Math.Abs((fly[0] - 65) - (spider[0] - 65));
            if (direction >= 6)
            {
                direction = 8 - direction;
            }

            if (spider == fly) return fly;

            if (direction > 2 && spider != "A0" && fly != "A0")
            {
                while (y != 1)
                {
                    result += $"{df[x]}{y}-";
                    y--;
                }
                result += $"{df[x]}{y}-";
                result += "A0-";
                x = (fly[0] - 65);
                while ($"{df[x]}{y}" != fly)
                {
                    result += $"{df[x]}{y}-";
                    y++;
                }
            }
            else
            {
                if (spider == "A0")
                {
                    result += $"{df[x]}{y}-";
                    x = (fly[0] - 65);
                    y = 1;
                }

                if (spider[1] - '0' > fly[1] - '0')
                {
                    while (y != fly[1] - '0')
                    {
                        result += $"{df[x]}{y}-";
                        y--;
                    }
                }


                if ((fly[0]) == ('B') && (spider[0]) == 'H' || (fly[0]) == ('A') && (spider[0]) == 'G' && fly != "A0" || (fly[0]) == ('A') && (spider[0]) == 'H' && fly != "A0")
                {
                    while (df[x] != fly[0])
                    {

                        if (x == 7)
                        { result += $"{df[x]}{y}-"; x = 0; continue; }
                        result += $"{df[x]}{y}-";

                        x++;
                    }
                }

                if ((fly[0]) == ('H') && (spider[0]) == 'B' || (fly[0]) == ('G') && (spider[0]) == 'A' && spider != "A0" || (fly[0]) == ('H') && (spider[0]) == 'A' && spider != "A0")
                {
                    while (df[x] != fly[0])
                    {

                        if (x == 0) { result += $"{df[x]}{y}-"; x = 7; continue; }
                        result += $"{df[x]}{y}-";
                        x--;
                    }

                }

                if ((fly[0] - 65) > (spider[0] - 65) && fly != "A0")
                {
                    while (df[x] != fly[0])
                    {
                        result += $"{df[x]}{y}-";
                        if (x == 7) { x = 0; result += $"{df[x]}{y}-"; continue; }

                        x++;
                    }
                }
                else if ((fly[0] - 65) < (spider[0] - 65) && fly != "A0")
                {
                    while (df[x] != fly[0])
                    {
                        result += $"{df[x]}{y}-";
                        if (x == 0) { x = 7; result += $"{df[x]}{y}-"; continue; }

                        x--;
                    }
                }

                if (spider[1] - '0' < fly[1] - '0')
                {
                    while (y != fly[1] - '0')
                    {
                        result += $"{df[x]}{y}-";
                        y++;
                    }
                }
            }


            return result + fly;
        }


    }
    // рандом  способность при атаке у перса
    public class Character
    {
        public string Name { get; set; }
        public int Opness { get; set; }
        public Character(string name, int opness)
        {
            Name = name;
            Opness = opness;
        }
        public int Attack() => Opness + new Random().Next(1, 21);
    }


    //  возможность динамично менять сообщение
    //public class Dinglemouse
    //{
    //    string _name;
    //    string _age;
    //    string _sex;
    //    string _hello = "Hello.";
    //    Dictionary<int, string> users = new Dictionary<int, string>();

    //    public Dinglemouse()
    //    {
    //    }

    //    public Dinglemouse SetAge(int age)
    //    {
    //        _age = $" I am {age}.";
    //        users[1] = _age;
    //        return this;
    //    }

    //    public Dinglemouse SetSex(char sex)
    //    {
    //        _sex = $" I am {(sex == 'M' ? "male" : "female")}";
    //        users[2] = _sex;
    //        return this;
    //    }

    //    public Dinglemouse SetName(string name)
    //    {
    //        _name = $" My name is {name}.";
    //        users[3] = _name;
    //        return this;
    //    }

    //    public string Hello()
    //    {
    //        foreach (var item in users)
    //        {
    //            _hello += item.Value;
    //        }
    //        return _hello;
    //    }
    //}
}
