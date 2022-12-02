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
            foreach (var VARIABLE in ArrayDiff(new int[] { 1,2,2 }, new int[] { 2}))
            {
                Console.WriteLine(VARIABLE);
            }
// Console.WriteLine(Res.GetNames(new int[,] { { 7, 1, 5, 8 }, { 2, 1, 4, 9 }, { 3, 2, 4, 7 } }));

//Console.WriteLine(ArrayPlusArray(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }));



;
        }
        public static int[] ArrayDiff(int[] a, int[] b)
        {
            
            //List<int> result = new List<int>();
            //result.AddRange(a);
            //foreach (var item in a.Intersect(b))
            //{
            //    result.RemoveAll(p=> p == item);
            //}
            //return result.ToArray();
            return a.Where(x=> !b.Contains(x)).ToArray();



          
        }

        //public static string Stb(string word)
        //{


        //}
    }






}














