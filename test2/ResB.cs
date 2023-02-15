using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


        // сумма чисел впрмежутке между двумя заданными
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

        //public static bool Millipede(string[] arr)
        //{
        //    //List<string> myList = arr.ToList();
        //    //myList.Sort();
        //    //int i = 0;
        //    //bool bl = true;
        //    //while (bl)
        //    //{
        //    //    bl = false;
        //    //    for (int j = 1; j < myList.Count; j++)
        //    //    {
        //    //        if ((myList[i])[myList[i].Length - 1] == (myList[j])[0] || (myList[j])[myList[j].Length - 1] == (myList[i])[0])
        //    //        {
        //    //            string temOne = myList[i];
        //    //            string temTwo = myList[j];
        //    //            if((myList[j])[myList[j].Length - 1] == (myList[i])[0]) myList.Add(temTwo + temOne);
        //    //            else myList.Add(temOne + temTwo);
        //    //            myList.Remove(temOne);
        //    //            myList.Remove(temTwo);
        //    //            bl = true;
        //    //            break;
        //    //        }
        //    //    }
        //    //}
        //    //if (arr.Contains(" ")) return false;
        //    var one = arr.Select(o => o[0]);
        //    var last = arr.Where(l => l.Length > 1).Select(l => l[^1]);
        //    var result = one.Concat(last).GroupBy(r=>r).Select(r=> r.Count()).Where(r => r%2 != 0).ToArray();
        //    var d = arr.Where(n => n.Length == 1).ToArray().Length;
        //    Console.WriteLine(d);
        //    if (arr.Where(n => n.Length == 1).ToArray().Length == arr.Length && one.Concat(last).GroupBy(r => r).ToArray().Length > 1) return false;
        //    return result.Length <= 2;
        //    //Console.WriteLine(result);
        //    //foreach (var VARIABLE in result)
        //    //{
        //    //    Console.WriteLine(VARIABLE);
        //    //}
        //   // return true;
        //}

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
    }
}
