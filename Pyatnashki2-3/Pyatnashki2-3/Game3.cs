using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyatnashki
{
    class Game3 : Game2
    {
        private int number; 
        private Log log;

        public int Number
        {
            get { return number; }
        }
        public Game3(params int[] val) : base(val) 
        {
            log = new Log(); 
            number = 0;
        }
        public void Conversaly(int movesAgo) //Возврат игры на количество ходов назад
        {
            List<Move> moves = log.GetLog();
            int countOfTurns = moves.Count;
            for (int i = countOfTurns - 1; i >= countOfTurns - movesAgo; i--) //меняем кости в обратном порядке, пока не дойдем до нужного хода
            {
                Point A = moves[i].A;
                Point B = moves[i].B;

                int val = field[A.Row, A.Column];
                if (val > 0) val = field[A.Row, A.Column];
                if (val < 0) val = field[B.Row, B.Column];//вычисление кости, которую будем менять с нулевой костью

                base.Shift(val);
                log.DeleteLast();
            }
            number = number - movesAgo;
        }
        public override void Shift(int value)
        {
            base.Shift(value);
            number++;
            log.AddMove(number, GetLocation(0), GetLocation(value));
        }

    }
}
