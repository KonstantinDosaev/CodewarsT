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

            Console.WriteLine(DuplicateEncode("eyeedG)meOeeeben"));
            //foreach (var VARIABLE in ArrayDiff(new int[] { 1,2,2 }, new int[] { 2}))
            //{
            //    Console.WriteLine(VARIABLE);
            //}
            // Console.WriteLine(Res.GetNames(new int[,] { { 7, 1, 5, 8 }, { 2, 1, 4, 9 }, { 3, 2, 4, 7 } }));

            //Console.WriteLine(ArrayPlusArray(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }));



            ;
        }

        public static string DuplicateEncode(string word)
        {
            //word = word.ToLower();
            //var y = string.Join("", word.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key));
            //string result = "";
            //foreach (var item in word) word = y.Contains(item) ? result += ")" : result += "(";
            return new string(word.ToLower().Select(w => word.ToLower().Count(i=> i == w)==1 ? ')' : '(').ToArray());

        }

        //public static string Stb(string word)
        //{

        //}
    }






}














