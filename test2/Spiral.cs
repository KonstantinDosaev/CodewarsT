using System;
using System.Collections.Generic;
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
            spiral[0, 0] = 1;
            for (int i = 0; i == size; i++)
            {
                while (y == limitDown & x != limitUp && i != size) {  x++; spiral[y, x] = 1;}
                while (y != limitUp & x == limitUp && i != size) {   y++; spiral[y, x] = 1; } 
                while (y == limitUp & x != limitDown && i != size) 
                {   
                    x--; spiral[y, x] = 1;
                    if (y == limitUp && x == limitDown)
                    {
                        limitUp -= 2;
                        limitDown += 2;
                    }
                }              
                while ( x+2 == limitDown & y != limitDown && i != size) {   y--; spiral[y, x] = 1; }
                
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


        //и с размером 10:

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
