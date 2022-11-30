using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Microsoft.VisualBasic;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(ResA.Multiply(-2));
            //foreach (var VARIABLE in GetNames(new int[,] { { 1, 2 }, { 3, 4 } }))
            //{
            //    Console.WriteLine(VARIABLE);
            //}
            // Console.WriteLine(Res.GetNames(new int[,] { { 7, 1, 5, 8 }, { 2, 1, 4, 9 }, { 3, 2, 4, 7 } }));

            //Console.WriteLine(ArrayPlusArray(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }));

            //long num = 1082077497969070681;


            //Console.WriteLine(Math.Sqrt(num)); Console.WriteLine((Math.Sqrt(num)+1) * ((Math.Sqrt(num) +1)));
            ////Console.WriteLine(q);
            Console.WriteLine(FindNextSquare(5049531132362809));
            //Console.WriteLine(Math.Sqrt(1082077497969070681));Console.WriteLine(Math.Sqrt(4503599761588225));

        }

        //public static string Stb(string word)
        //{


        //}
        

        public static long FindNextSquare(long num)
        {
            //if (num == 4503599627370496 && num == 5049531132362809) return -1;

            long r = (long)Math.Sqrt(num);

            Console.WriteLine(r);
            Console.WriteLine((r+1)*(r+1));
            decimal defNum = num;
                 
            var sq = SquereR(num);
            Console.WriteLine(sq);
            
            if (sq - Math.Truncate(sq) != 0) return -1;
            var t = (sq+ 1.0M) * (sq +1.0M);
            return (long)(t);
            

        }
        static decimal SquereR(decimal square)
        {
            if (square < 0) return 0;

            decimal root = square / 3;
            int i;
            for (i = 0; i < 35; i++)
                root = (root + square / root) / 2;
            return root;
        }

    }
    //using System;
    //using System.Text.RegularExpressions;





}














