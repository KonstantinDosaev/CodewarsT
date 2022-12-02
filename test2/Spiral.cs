using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2
{
    internal class Spiral
    {
        public static int[,] Spiralize(int size)
        {
            int[,] spiral = new int[size, size];
            int x = 0;
            int y = 0;
            int limitUp = size - 1;
            int limitDown = 0;
            int counter = 0;
            spiral[0, 0] = 1;
            while (counter != size)
            {
                while (y == limitDown & x != limitUp && counter != size) { x++; spiral[y, x] = 1; }
                counter = counter != size ? counter + 1 : counter;
                while (y != limitUp & x == limitUp && counter != size) { y++; spiral[y, x] = 1; }
                counter = counter != size ? counter + 1 : counter;
                while (y == limitUp & x != limitDown && counter != size)
                {
                    x--; spiral[y, x] = 1;
                    if (y == limitUp && x == limitDown)
                    {
                        limitUp -= 2;
                        limitDown += 2;
                    }
                }
                counter = counter != size ? counter + 1 : counter;
                while (x + 2 == limitDown & y != limitDown && counter != size) { y--; spiral[y, x] = 1; }
                counter = counter != size ? counter + 1 : counter;
            }

            return spiral;
            }

        public static int[,] SpiralizeVer2(int size)
        {
            int[,] spiral = new int[size, size];

            int x = 0;
            int limit = (int)(Math.Round((size / 4.0), MidpointRounding.ToPositiveInfinity));

            for (int i = 1; i <= limit  ; i++)
            {
                for (int y = x; y <= size - 1; y++)
                {
                    if ((size - 1) - x < 3) x-=1;
                    spiral[x, y] = 1; 
                    spiral[y, size - 1] = 1;
                    
                    spiral[size - 1, y] = 1;
                    
                    if (y != x + 1 ) spiral[y, x] = 1;
                    else spiral[y + 1, x + 1] = 1;
                }
                x += 2;
                size -= 2;
            } 
            
            return spiral;
        }
    }
}
        // 00000
        // ....0
        // 000.0
        // 0...0
        // 00000


       

        // 0000000000
        // .........0
        // 00000000.0
        // 0......0.0
        // 0.0000.0.0
        // 0.0..0.0.0
        // 0.0....0.0
        // 0.000000.0
        // 0........0
        // 0000000000

//00000       ....0       000.0                                                                   0...0       00000

//0000000000  .........0  00000000.0  0......0.0  0.0000.0.0  0.0..0.0.0  0.0....0.0  0.000000.0  0........0  0000000000
