using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.CSharp;
using System.CodeDom;
using System.Globalization;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace test2
{
    internal class ResC
    {
        public static string Mix(string s1, string s2)
        {
            var a = s1.Where(char.IsLower).GroupBy(g => g).OrderByDescending(o => o.Count()).Where(s => s.Count() > 1);
            var b = s2.Where(char.IsLower).GroupBy(g => g).OrderByDescending(o => o.Count()).Where(s => s.Count() > 1);

            List<string> aList = a.Select(i => $"1:{string.Join("", Enumerable.Repeat(i.Key, i.Count()))}").ToList();
            List<string> bList = b.Select(i => $"2:{string.Join("", Enumerable.Repeat(i.Key, i.Count()))}").ToList();
            
            aList.AddRange(bList);

            aList = aList.OrderBy(i => i[^1]).ToList();
            for (int i = 0; i < aList.Count-1; i++)
            {
                if (aList[i][^1] == aList[i + 1][^1])
                {
                    if (aList[i].Length == aList[i + 1].Length)
                    {
                        aList[i] = aList[i].Remove(0,1);
                        aList[i] = "=" + aList[i];
                        aList.RemoveAt(i+1);
                        continue;
                    }
                        
                    if (aList[i].Length < aList[i + 1].Length)
                        aList.RemoveAt(i);
                    else
                        aList.Remove(aList[i+1]);
                }

            }
            aList = aList.OrderByDescending(i => i.Length).ThenBy(t => t[0]).ToList();


            return String.Join("/", aList.ToArray());
        }

        public static bool Line(char[][] grid)
        {
            var listRoute = new List<(int, int, char)>();
            var listTemp = new List<(int, int, char)>();
            var res = 0;
            if (grid.Select(s => s.Count(c => c != 'X')).Sum() is > 2 or 1) return false;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 'X')
                    {
                        listRoute.Add((i, j, 'X'));

                        for (int k = 0; k < listRoute.Count; k++)
                        {
                            var one = listRoute[k].Item1;
                            var two = listRoute[k].Item2;

                            if (grid[one][two] == 'X')
                            {
                                listTemp.Clear();
                                if (listRoute.Count > 1)
                                    break;

                                Right(one, two);
                                Left(one, two);
                                Up(one, two);
                                Down(one, two);
                                if (listTemp.Count is > 1 or 0) break;

                                listRoute.Add(listTemp[0]);
                            }

                            if (grid[one][two] == '+')
                            {
                                listTemp.Clear();
                                if (listRoute[k].Item3 is 'r' or 'l')
                                {
                                    Up(one, two);
                                    Down(one, two);
                                }
                                if (listRoute[k].Item3 is 'u' or 'd')
                                {

                                    Left(one, two);
                                    Right(one, two);
                                }

                                if (listTemp.Count == 0 || listTemp.Count is > 1) break;

                                listRoute.Add(listTemp[0]); 
                                
                            }

                            if (grid[one][two] == '-')
                            {
                                listTemp.Clear();
                                switch (listRoute[k].Item3)
                                {
                                    case 'r':
                                        Right(one, two);
                                        break;
                                    case 'l':
                                        Left(one, two);
                                        break;
                                }
                                if (listTemp.Count is > 1 or 0) break;
                                listRoute.Add(listTemp[0]);
                                
                            }

                            if (grid[one][two] == '|')
                            {
                                listTemp.Clear();
                                switch (listRoute[k].Item3)
                                {
                                    case 'u':
                                        Up(one, two);
                                        break;
                                    case 'd':
                                        Down(one, two);
                                        break;
                                }
                                if (listTemp.Count is > 1 or 0) break;
                                listRoute.Add(listTemp[0]);
                            }


                        }

                        if (grid.Select(s=>s.Count(c=>c != ' ')).Sum() == listRoute.Count)
                        {
                            res+=1;
                        }
                        listRoute.Clear();
                    }
                }
            }
            return res != 0;

            void Right(int one, int two)
            {
                if (two < grid[one].Length - 1)
                {
                    if (!"| ".Contains(grid[one][two + 1]) && listRoute.Count(c => c.Item1 == one && c.Item2 == two + 1) == 0)
                    {
                        listTemp.Add((one, two + 1, 'r'));
                    }
                }
            }
            void Left(int one, int two)
            {
                if (two != 0)
                {
                    if (!"| ".Contains(grid[one][two - 1]) && listRoute.Count(c => c.Item1 == one && c.Item2 == two - 1) == 0)
                    {
                        listTemp.Add((one, two - 1, 'l'));
                    }
                }
            }

            void Up(int one, int two)
            {
                if (one != 0)
                {
                    if (!"- ".Contains(grid[one - 1][two]) && listRoute.Count(c => c.Item1 == one - 1 && c.Item2 == two) == 0)
                    {
                        listTemp.Add((one - 1, two, 'u'));
                    }
                }
            }

            void Down(int one, int two)
            {
                if (one < grid.Length - 1)
                {
                    if (!"- ".Contains(grid[one + 1][two]) && listRoute.Count(c => c.Item1 == one + 1 && c.Item2 == two) == 0)
                    {
                        listTemp.Add((one + 1, two, 'd'));
                    }
                }
            }


            

        }

        //public static double upsideDown(string x, string y)
        //{

        //    var f = "1" + string.Join("", Enumerable.Repeat('0', (x.Length-1)));
        //    var counter = 0;
        //    var a = Convert.ToUInt64(x);
        //    var b = Convert.ToUInt64(y);
        //    var c = Convert.ToUInt64(f);

        //    bool q = true;
        //    var ar = new[] {1, 2, 7, 9, 10 };

        //    for (var i = a; i <= b; i++)
        //    {

        //        var temp = Convert.ToString(i);

        //        if (temp.Contains('3') || temp.Contains('4') || temp.Contains('7')) continue;

        //        if (temp[0] == '0' && temp[^1] == '0' || temp[0] == '1' && temp[^1] == '1' ||
        //            temp[0] == '8' && temp[^1] == '8' || temp[0] == '9' && temp[^1] == '6' || temp[0] == '6' && temp[^1] == '9')
        //        {
        //            var countL = 0;
        //            for (int j = 0; j <= temp.Length / 2; j++)
        //            {
        //                switch (temp[j])
        //                {
        //                    case '1' when temp[^(j + 1)] == '1':
        //                        q = true;
        //                        break;
        //                    case '0' when temp[^(j + 1)] == '0':
        //                        q = true;
        //                        break;
        //                    case '8' when temp[^(j + 1)] == '8':
        //                        q = true;
        //                        break;
        //                    case '6' when temp[^(j + 1)] == '9':
        //                        q = true;
        //                        break;
        //                    case '9' when temp[^(j + 1)] == '6':
        //                        q = true;
        //                        break;
        //                    default: q = false; break;
        //                }

        //                if (!q)
        //                {
        //                    break;
        //                }
        //            }

        //            if (q)
        //            {
        //                counter++;
        //                Console.WriteLine(temp);
        //            }
        //        }

        //    }
        //    return counter;
        //}


        //// calculate


        private static DataTable Dt { get; } = new DataTable();
        public static double Calculate(string s)
        {
            s = s.Replace(" ", "");
            //Console.WriteLine(s);

            // var regDeg = new Regex(@"\d+\^.+").Matches(s).ToString();
            //var t = Math.Pow(numMatch, degMatch);
           
            while (s.Contains('^'))
            {
                var numMatch = new Regex(@$"(\d+\.?\d*\^)|(\(\-*\d+\.?\d*(\-|\+|\*|\/)\d+\.?\d*\)\^)").Match(s).ToString().Replace("^", "");
                var degMatch = new Regex(@$"(\^\d+\.?\d*)|(\^\(\-*\d+\.?\d*(\-|\+|\*|\/)\d+\.?\d*\))").Match(s).ToString().Replace("^", "");
                //if (degMatch.Count(c=>c ==')') + degMatch.Count(c => c == '(')%2 != 0)
                //    degMatch = degMatch.Remove(degMatch.Length - 1);
                var s1 = numMatch;
                var s2 = degMatch;
                var numMatchDecimal = Math.Round(CSharpScript.EvaluateAsync<double>(numMatch).Result,2);
                var degMatchDecimal = Math.Round(CSharpScript.EvaluateAsync<double>(degMatch).Result,2);
                s = s.Replace($"{numMatch}^{degMatch}", Math.Round(Math.Pow(numMatchDecimal, degMatchDecimal),2).ToString(CultureInfo.InvariantCulture));
                //s = new Regex(@"((\d+\.?\d*)|(\(\-*\d+\.?\d*(\-|\+|\*|\/)\d+\.?\d*\)))\^((\d+\.?\d*)|(\(\-*\d+\.?\d*(\-|\+|\*|\/)\d+\.?\d*\)))").Replace(s, (Math.Pow(numMatchDecimal, degMatchDecimal).ToString()));
            }

            if (s.Contains('/'))
            {
                var regDeg = s.Select(s => Convert.ToString(s)).ToArray();
                for (int i = 0; i < regDeg.Length; i++)
                {
                    if (regDeg[i] == "/")
                        regDeg[i] = "d" + regDeg[i];
                }

                s = string.Join("", regDeg);
            }
            
            

            return CSharpScript.EvaluateAsync<double>(s).Result; 
        }

        //

    }
}
