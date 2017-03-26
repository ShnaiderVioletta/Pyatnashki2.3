using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyatnashki
{
    class Log
    {
        List<Move> moves = new List<Move>();

        public void AddMove(int n, Point a, Point b)
        {
            moves.Add(new Move(n, a, b));
        }

        public void DeleteLast()
        {
            moves.Remove(moves[moves.Count - 1]);
        }

        public List<Move> GetLog()
        {
            return this.moves;
        }

        public void Clear()
        {
            moves = new List<Move>();
        }
    }
}
