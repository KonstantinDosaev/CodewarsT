using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace test2
{
    internal class ResB
    {
        
        public static bool HasSurvived(int[] attackers, int[] defenders)
        {
            var minLength = attackers.Length > defenders.Length ? defenders.Length : attackers.Length;
            for (int i = 0; i < minLength; i++)
            { 
                int temA = attackers[i];
                int temB = defenders[i];
                defenders[i] -= temA;
                attackers[i] -= temB;
            }

            var t = defenders.Count(p => p > 0);
            var tm = attackers.Count(p => p > 0);
            if (t == tm)  return defenders.Sum() >= attackers.Sum();
            return t > tm;
        }


        // удалить минимальное значение в массиве,первое вхождение
        public static List<int> RemoveSmallest(List<int> numbers)
        {
            numbers.Remove(numbers.Min());
            return numbers;
        }


        // сумма чисел в промежутке между двумя заданными
        public static int GetSum(int a, int b)
        {
            var result = a;
            while (a != b)
            {
                if (a<b)
                {
                    a += 1;
                    result += a;
                }
                else
                {
                    a -= 1;
                    result += a;
                }
            }
            return result;
        }

        public static bool Millipede(string[] arr)
        {
            var myArr = arr.Where(w=> w[0] == w[^1]).Select(s=> s[0].ToString()).Concat(arr.Where(w => w[0] != w[^1])).OrderBy(o=>o);
            
            var one = myArr.Where(w => w.Length == 1).GroupBy(g=>g).Select(s=>s.Key).ToList();
            var ar = myArr.Where(w => w.Length > 1).ToList();

            if (ar.Count == 0)
                return one.Count == 1;

            int j = 0;
            while (one.Count != 0 && j < ar.Count)
            {
                if (ar[j][0] == one[0][0])
                {
                    ar[j] = one[0] + ar[j];
                    one.RemoveAt(0);
                    j = 0;
                    continue;
                }

                if (ar[j][^1] == one[0][0])
                {
                    ar[j] = ar[j] + one[0];
                    one.RemoveAt(0);
                    j = 0;
                }

                j++;
            }

            for (int i = 1; i < ar.Count; i++)
            {
                if (ar[i][0] == ar[0][^1])
                {
                    ar[0] = ar[0] + ar[i];
                    ar.RemoveAt(i);
                    i = 0;
                    continue;
                }

                if (ar[i][^1] == ar[0][0])
                {
                    ar[0] = ar[i] + ar[0];
                    ar.RemoveAt(i);
                    i = 0;
                    continue;
                }
            }

            return ar.Count == 1 && one.Count == 0;
        }

        public static int[] AddingShifted(int[][] arrayOfArrays, int shift)
        {
            int[][] myArr = new int[arrayOfArrays.Length][];
            int[] nul = new int[shift];
            var myList = new List<int>();
            for (int i = 0; i < myArr.Length; i++)
            {
                List<int> l = new List<int>();
                for (int j = 0; j < arrayOfArrays.Length; j++)
                {
                    if (j == i)
                    {
                        l.AddRange(arrayOfArrays[i]);  
                    }
                    else
                    {
                      l.AddRange(nul);   
                    }
                   
                }
                myArr[i] = l.ToArray();
                
            }
            for (int i = 0; i < myArr[0].Length; i++)
            {
                int temp = 0;
                for (int j = 0; j < myArr.Length; j++)
                {
                    temp += myArr[j][i];
                }
                myList.Add(temp);
            }

            return myList.ToArray();
        }

        public static int Number(List<int[]> peopleListInOut)
        {
            int temp1 = 0;
            int temp2 = 0;
            for (int i = 0; i < peopleListInOut.Count; i++)
            {
                temp1 += peopleListInOut[i][0];
                temp2 += peopleListInOut[i][1];
            }
            return temp1 - temp2;
        }

        static int IsSolved(int[,] board)
        {
            int[] hor = new int[3];
            int[] vert = new int[3];
            int n = 0;
            for (int i = 0; i < 3; i++)
            {

                for (int j = 0; j < 3; j++)
                {
                    hor[j] = board[i, j];
                    vert[j] = board[j, i];
                    if (board[i, j] == 0) n++;
                }

                if (hor.Distinct().Count() == 1 && hor[i] != 0)
                    return hor[i];


                if (vert.Distinct().Count() == 1 && vert[i] != 0)
                    return vert[i];

            }

            if ((board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] || board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0]) && board[1, 1] != 0)
                return board[1, 1];

            return n > 1 ? -1 : 0;
        }

        public static int SumOfMinimums(int[,] numbers)
        {
            var result = 0;
            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                var temp = numbers[i, 0];
                for (int j = 1; j < numbers.GetLength(1); j++)
                {
                    
                    if (temp > numbers[i, j]) temp = numbers[i, j];
                }
                result += temp;
            }
            return result;
        }

        public static int[] RoundUp(int number, int[] list)
        {
            var temp = new int[list.Length];
            for (int i = 0; i < list.Length; i++)
            {
                temp[i] = list[i] - number;
            }

            if (temp.Length == 0) return Array.Empty<int>();

            int les = temp.Where(l => l < 0).DefaultIfEmpty(number + 1).Max();
            int mor = temp.Where(m => m > 0).DefaultIfEmpty(number - 1).Min();
            if (Math.Abs(les) == mor)
            {
                return list.Where(l => l == les + number || l == mor + number).ToArray();
            }

            return Math.Abs(les) > mor ? new[] {mor + number } : new[] { les + number };
        }

        public static int MrOdd(string str)
        {
            //var t = str.GroupBy(g => g).Where(w => w.Key =='d' || w.Key == 'o').Min()!.Count();
           
            var list = new List<string>();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'o')
                    list.Add(new string("o"));
                if (str[i] == 'd')
                {
                    string? temp = list.FirstOrDefault(w => w.Length < 3);
                    var t = list.IndexOf(temp!);
                    if (t != -1)
                     list[t] = temp!.Insert(temp.Length, str[i].ToString());
                }
            }
            return list.Count(w => w.Length == 3);
        }

        public static string[][] VolleyballPositions(string[][] formation, int k)
        {
            Console.WriteLine(1000%6 +6);
            if (k > 6)
                k = k % 6 + 6;
            for (int i = 0; i < k; i++)
            {
                (formation[0][1], formation[1][0]) = (formation[1][0], formation[0][1]);
                (formation[0][1], formation[3][0]) = (formation[3][0], formation[0][1]);
                (formation[0][1], formation[2][1]) = (formation[2][1], formation[0][1]);
                (formation[0][1], formation[3][2]) = (formation[3][2], formation[0][1]);
                (formation[0][1], formation[1][2]) = (formation[1][2], formation[0][1]);
            }
            return formation;
        }

        public static int solveExpression(string expression)
        { 

            int missingDigit = -1;
            var op = new Regex(@"-?\?*\d*\?*\d*?\d*\?*\d*(\?|\d)+(\-|\*|\+)?").Match(expression);
            var opp = op.Value[op.Length - 1];

            for (int i = 0; i < 10; i++)
            {
               if (!expression.Contains(Convert.ToString(i)))
               {
                   var replace = expression.Replace("?", (i).ToString());
                    replace = new Regex(@"\d+-{1}\d+").Match(replace).Value.Length==0 ? replace : replace.Replace("-"," ");
                   var numbers = new Regex(@"-?\d+").Matches(replace);
                   var temp = opp switch
                   {
                       '+' => Convert.ToInt32(numbers[0].Value) + Convert.ToInt32(numbers[1].Value),
                       '-' => Convert.ToInt32(numbers[0].Value) - Convert.ToInt32(numbers[1].Value),
                       '*' => Convert.ToInt32(numbers[0].Value) * Convert.ToInt32(numbers[1].Value),
                       _ => 0
                   };

                   if (temp == Convert.ToInt32(numbers[2].Value) && numbers.Select(s=>s.Value.Replace("-","")).Count(w => w.Length>1 && w[0] == '0')==0)
                   {
                       return i;
                   }
               }

            }
            


            //string dg = mat[0].Value;
            //Console.WriteLine(Convert.ToInt32(mat[0].Value));
            return missingDigit;
        }

        public static int CircleSlash(int n)
        {
            var num = 2;

            while (num<n)
            {
                num = num * 2;
            }

            if (num == n)
                return 1;

            var res = n - (num-1- n);
            return res;
        }

        //двоичные числа кратные семи
        public static string MultipleOf7()
        {
            return  new Regex(@"^(0|(^$)|1((0(01|111)*(00|110))*(1|0(01|111)*10))(01*0(1(10|000)*(11|0(000)*01))*(0|1(10|000)*0(000)*1))*1)+$").ToString();
        }

        public static long NextBiggerNumber(long n)
        {
            var st = Convert.ToString(n);

            for (int i = st.Length-1; i > 0; i--)
            {
                if (st[i] > st[i-1])
                {
                    var last = st.Skip(i).OrderBy(o => o).ToList();
                    var first = st.Take(i).ToList();
                    var ind = last.IndexOf(last.First(f => Convert.ToInt32(f) > Convert.ToInt32(first[^1])));

                    (first[^1], last[ind]) = (last[ind] , first[^1]);
                     
                    st = new string(first.Concat(last).ToArray());

                    break;
                }
            }

            var result = Convert.ToInt64(st);

            return result > n ? result : -1 ;

        }


        //
        static int prevMatches;
        static int numArr;
        static List<int> overNum = null!;
        static bool lastNum;
        static int indexOne;
        static int indexTwo;
        
        public static int[] TryToGuess(int matches)
        {
            if (matches == -1)
            {
                prevMatches = 0;
                numArr = -1;
                overNum = new List<int>(); 
                lastNum = false;
                indexOne = -1;
                indexTwo = -1;
            }
            
            if (matches == 1 && overNum.Count < 2)
            {
                overNum.Add(numArr);
            }

            if (overNum.Count >= 2 )
            {
                if (overNum.Count == 2)
                {
                    overNum.AddRange(new[] { overNum[1], overNum[1] });
                    return overNum.ToArray();
                }

                if (indexOne ==-1 || indexTwo == -1)
                {
                    
                    switch (matches)
                    {
                        case 2:
                            indexOne = overNum.IndexOf(overNum.Min());
                            
                            break;
                        case 0:
                            indexTwo = overNum.IndexOf(overNum.Min());
                            
                            break;
                    }
                    if (indexOne != -1 && indexTwo != -1)
                    {
                        overNum[indexOne] = overNum.Min();
                        overNum[indexTwo] = overNum.Max();

                        return overNum.ToArray();

                    }
                    for (int i = 1; i < overNum.Count; i++)
                    {
                        if (overNum[i - 1] < overNum[i])
                        {
                            (overNum[i], overNum[i - 1]) = (overNum[i - 1], overNum[i]);
                            break;
                        }
                    }
                }
                else
                {
                    if (matches == 2)
                    {
                        
                        if (prevMatches == 3)
                        {
                            overNum[overNum.IndexOf(overNum.First(f => f != overNum[indexOne] && f != overNum[indexTwo]))]--;
                            overNum[overNum.LastIndexOf(overNum.Last(f => f != overNum[indexOne] && f != overNum[indexTwo]))]++;
                            lastNum = true;
                        }
                        else
                        {
                            for (int i = 0; i < overNum.Count; i++)
                            {
                                if (i != indexOne && i != indexTwo)
                                {
                                    overNum[i]++;
                                }
                            }
                        }

                        prevMatches = matches;
                    }

                    if (matches == 3)
                    {
                        if (!lastNum)
                            overNum[overNum.IndexOf( overNum.First(f=>f != overNum[indexOne]&& f != overNum[indexTwo]))]++;
                        else
                            overNum[overNum.LastIndexOf(overNum.Last(f => f != overNum[indexOne] && f != overNum[indexTwo]))]++;

                        prevMatches = matches;

                    }
                }
                return overNum.ToArray();
            }
 
            numArr++;
            
            return new[] { numArr, numArr, numArr, numArr };

        }
        //
    }
}
