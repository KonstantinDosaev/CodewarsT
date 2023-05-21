using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
//using Microsoft.CodeDom.Providers.DotNetCompilerPlatform;
using Microsoft.VisualBasic;

namespace test2
{
    class Program
    {
        private static DataTable Dt { get; } = new DataTable();
        static void Main(string[] args)
        {
            var r = "  4+2*((226-(5*3)^2)^2+(10.7-7.4)^2-6.89) ";
            Console.WriteLine(ResC.Calculate(r));
           //
           //Console.WriteLine(4+2*(1+10.89-6.89));
            
            ////var u = Convert.ToDouble(r.Select(s => s).ToArray());
            //var u = Dt.Compute(r,"");
            //Console.WriteLine(u);
        }




        ////for ResB.TryToGuess
        //public static void Play()
        //{
        //    int playersAttempts = 0;
        //    int[] dig = new int[] { 0,1,2,9 };
        //    int matches = -1;
        //    int[] answer = new int[4];
        //    answer = ResB.TryToGuess(matches);
        //    while (!Enumerable.SequenceEqual(answer, dig) && playersAttempts < 100)
        //    {
        //        int result = 0;
        //        for (int k = 0; k < 4; k++)
        //            if (answer[k] == dig[k])
        //                result++;
        //        matches = result;
        //        if (matches < 4)
        //        {
        //            playersAttempts++;
        //            answer = ResB.TryToGuess(matches);
        //        }
        //    }
        //    Console.WriteLine((playersAttempts, 16, "The code was {0}", string.Join("", dig)));
        //}

    }


    public static class Calculator
    {
        // Создадим экземпляр генератора и компилятора C#-кода
        public static double Calc(string s) => CSharpScript.EvaluateAsync<double>(s).Result;
    }
}

















