using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

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

                                //if (listTemp.Count is > 1)
                                //{
                                //    var xList = listTemp.ToArray();

                                //    foreach (var item in xList)
                                //    {
                                //        listTemp.Clear();
                                //        if (grid[item.Item1][item.Item2] == '+')
                                //        {
                                //            if (item.Item3 is 'r' or 'l')
                                //            {
                                //                Up(item.Item1, item.Item2);
                                //                Down(item.Item1, item.Item2);
                                //            }
                                //            if (item.Item3 is 'u' or 'd')
                                //            {
                                //                Right(item.Item1, item.Item2);
                                //                Left(item.Item1, item.Item2);
                                //            }
                                //        }
                                //        else
                                //        {
                                //            switch (item.Item3)
                                //            {
                                //                case 'r':
                                //                    Right(one, two);
                                //                    break;
                                //                case 'l':
                                //                    Left(one, two);
                                //                    break;
                                //                case 'u':
                                //                    Up(one, two);
                                //                    break;
                                //                case 'd':
                                //                    Down(one, two);
                                //                    break;
                                //            }
                                //        }

                                //        if (listTemp.Count == 1)
                                //        {
                                //            listRoute.Add(item);

                                //            break;
                                //        }
                                //    }
                                //}
                                //else

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





    }
}
