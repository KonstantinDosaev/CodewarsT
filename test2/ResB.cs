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

        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {

            List<T> j = new List<T>();
            //j.Add(iterable.FirstOrDefault<T>(defaultValue:" "));
            foreach (var item in iterable)
            {
                if (j.Count == 0||!Equals(item, j.Last()))
                {
                    j.Add(item);
                }
            }
            return (IEnumerable<T>)j;

            //var i = iterable.Where(i => i != iterable.GetEnumerator().MoveNext());
            //return (IEnumerable<T>)f;

        }
    }
}
