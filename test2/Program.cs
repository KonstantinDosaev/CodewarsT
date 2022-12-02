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
            int[,] test = Spiral.Spiralize(8);
            for (int i = 0; i < test.GetLength(0); i++)
            {
                for (int j = 0; j < test.GetLength(1) ; j++)
                {
                    Console.Write(test[i, j] + " ");
                }
                Console.WriteLine();
            }


;
        }

        //public static string Stb(string word)
        //{


        //}
    }






}














