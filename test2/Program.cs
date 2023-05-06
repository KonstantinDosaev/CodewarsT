using System;
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
using Microsoft.VisualBasic;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ResB.Millipede(new string[] { "exotic",
                "trade",
                "cable" }));
        }



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





}














