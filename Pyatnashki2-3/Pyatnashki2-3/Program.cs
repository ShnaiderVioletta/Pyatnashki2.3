using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pyatnashki
{
    class Program
    {
        static public void Print(Game3 game)
        {
            Console.WriteLine(string.Format("Ход № {0}", game.Number));
            for (int i = 0; i < game.Length; i++)
            {
                for (int j = 0; j < game.Length; j++)
                {
                    Console.Write(string.Format("{0}\t", game[i, j]));
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Game3 game = new Game3(1, 3, 2, 4, 5, 0, 7, 8, 6);

                Print(game);

                while (!game.FinishGame())
                {
                    Console.Write("Введите значение, которое необходимо двигать: ");
                    int val = int.Parse(Console.ReadLine());

                    try
                    {
                        if (val < 0)
                        {
                            game.Conversaly(val * -1);
                        }
                        else
                        {
                            game.Shift(val);
                        }

                    }
                    catch (Exception ex)  // возможные ошибки в ходе игры
                    {
                        Console.WriteLine(string.Format("Неправильный ход! {0}", ex.Message));
                    }
                    Print(game);
                }
                Console.WriteLine("Поздравляем! Игра завершена за {0} ходов!", game.Number);
            }
            catch (Exception ex) //возможные ошибки при создании игры
            {
                Console.WriteLine(string.Format("Критическая ошибка! {0}", ex.Message));
            }
            Console.ReadKey();
        }
    }
}

