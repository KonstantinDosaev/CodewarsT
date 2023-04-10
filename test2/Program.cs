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

            //Console.WriteLine(ResB.GetSum(-3,2));



            //Console.WriteLine(ResB.RoundUp(10, new int[] { 1, 2, 4, 8, 16, 32 }));

            Console.WriteLine(Regex.Match("", ResB.MultipleOf7()) + $"\t num   ");

         

            //for (int i = 0; i < 100; i++)
            //{


            //    //Console.WriteLine(ResB.MultipleOf7(Convert.ToString(i,2)) + $"\t num   {i}");
            //    Console.WriteLine(Regex.Match(Convert.ToString(i, 2), ResB.MultipleOf7()) + $"\t num   {i}");
            //}


        }


        //public static string Stb(string word)
        //{

        //}

    }






}














