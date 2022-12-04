using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

            Console.WriteLine(DigitalRoot(123));
            //foreach (var VARIABLE in ArrayDiff(new int[] { 1,2,2 }, new int[] { 2}))
            //{
            //    Console.WriteLine(VARIABLE);
            //}
            // Console.WriteLine(Res.GetNames(new int[,] { { 7, 1, 5, 8 }, { 2, 1, 4, 9 }, { 3, 2, 4, 7 } }));

            //Console.WriteLine(ArrayPlusArray(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }));



            ;
        }


        //public static string Stb(string word)
        //{

        //}
        //сумма цифр многозначного числа покаа не останится  однозначное 123 => 1+2+2=5
        public static int DigitalRoot(long n)
        {
            while(n > 9){ n = n.ToString().Select(c => c - '0').Aggregate((x, y) => x + y); }
             
            return (int)Convert.ToInt64(n);
        }
    }






}














