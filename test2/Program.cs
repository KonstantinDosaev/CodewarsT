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

            User user= new User();
            user.rank = -4;
            user.incProgress(8);
            //user.incProgress(-5);

            user.incProgress(7);
            Console.WriteLine(user.progress);
            Console.WriteLine(user.rank);


            //user.incProgress(-7);
            //Console.WriteLine(user.progress);
            //user.incProgress(-6);
            //Console.WriteLine(user.rank);
            //Console.WriteLine(user.progress);
            //user.incProgress(-5);
            //user.incProgress(-5);
            //Console.WriteLine(user.rank);
            //Console.WriteLine(user.progress);
            //user.incProgress(-9);
            //Console.WriteLine(user.progress);
            //Console.WriteLine(user.rank);
        }

        //public static string Stb(string word)
        //{


        //}
    }






}














