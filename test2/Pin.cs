using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2
{
    internal class Pin
    {
        public static List<string> GetPINs(string observed)
        {
            var u = observed.Select(c => c - '0').ToArray();

            string[][] arr =
            {
                new string[] { "0", "8" },
                new string[] { "1", "2", "4" },
                new string[] { "1", "2", "3", "5" },
                new string[] { "2", "3", "6" },
                new string[] { "1", "4", "5", "7" },
                new string[] { "2", "4", "5", "6", "8" },
                new string[] { "3", "5", "6", "9" },
                new string[] { "4", "7", "8" },
                new string[] { "5", "7", "8", "9", "0" },
                new string[] { "6", "8", "9" },
            };

            if (u.Length == 1)
                return arr[u[0]].ToList();

            List<string> result = new List<string>();

            for (int i = 0; i < arr[u[0]].Length; i++)
            {
                for (int j = 0; j < arr[u[1]].Length; j++)
                {
                    result.Add(arr[u[0]][i] + arr[u[1]][j]);
                }
            }

            if (u.Length > 2)
            {

                for (int i = 2; i < u.Length; i++)
                {
                    int currList = result.Count;
                    for (int j = 0; j < currList; j++)
                    {
                        for (int k = 0; k < arr[u[i]].Length; k++)
                        {
                            result.Add(result[j] + arr[u[i]][k]);
                        }
                    }

                    result.RemoveRange(0, currList);
                }
            }

            return result;
        }
    }
}
 // все возможные комбинации пин кода ,каждое из заданых циф может быть соседней по горизонтали или по вертикали пр.23 : 2=> 2,1,3,5   3=> 3,2,6 
    //┌───┬───┬───┐
    //│ 1 │ 2 │ 3 │
    //├───┼───┼───┤
    //│ 4 │ 5 │ 6 │
    //├───┼───┼───┤
    //│ 7 │ 8 │ 9 │
    //└───┼───┼───┘
    //    │ 0 │