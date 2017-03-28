using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyatnashki
{
    class Move 
    {
        public int Num;
        public Point A;
        public Point B;

        public Move(int n, Point a, Point b)
        {
            this.Num = n;
            this.A = a;
            this.B = b;
        }
    }
}
