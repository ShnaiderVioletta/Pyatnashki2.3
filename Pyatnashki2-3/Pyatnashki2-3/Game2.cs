using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyatnashki
{
    class Game2 : Game
    {
        public Game2(params int[] val)
        {
            const int numberOfIterations = 11; //количество итераций для рандомизации стартовой последовательности
            CheckIt(val); //проверка переданных параметров для создания игры

            int size = (int)Math.Sqrt(val.Length); //вычисляем размер игры
            int[,] mas = new int[size, size]; //инициализируем поле

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    mas[i, j] = val[i * size + j];
                }
            } //инициализируем поле

            for (int k = 0; k < numberOfIterations; k++)
            {
                List<Point> nearBones = new List<Point>();   //лист с соседними костями
                Point Position0 = new Point(-1, -1); //кость с нулевым значением
                Point PositionToSwap; //кость, с которой будем меняться местами

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (mas[i, j] == 0)//ищем кость со значением 0
                        {
                            Position0 = new Point(j, i);

                            if (i - 1 >= 0) nearBones.Add(new Point(j, i - 1));
                            if (i + 1 <= size - 1) nearBones.Add(new Point(j, i + 1));
                            if (j - 1 >= 0) nearBones.Add(new Point(j - 1, i));
                            if (j + 1 <= size - 1) nearBones.Add(new Point(j + 1, i));//заносим данные о соседних костях в лист
                        }
                    }
                }

                if (nearBones.Count > 0) //если при прохождении массива были найдены 0-кости
                {
                    Random random = new Random();
                    PositionToSwap = nearBones[random.Next(nearBones.Count - 1)];//выбираем случайную кость для замены
                    swap(ref mas[Position0.Row, Position0.Column], ref mas[PositionToSwap.Row, PositionToSwap.Column]); //перемещаем кости
                }
            }

            List<int> lst = new List<int>(); //формируем лист для передачи в качестве параметров конструктору
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    lst.Add(mas[i, j]);
                }
            }
            Inicialize(lst.ToArray());//передаем в качестве параметров для создания новой игры
        }

        public bool FinishGame()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if ((field[i, j] != (i * size + j + 1) && (i != size - 1 || j != size - 1)) ||
                        (field[i, j] != 0 && i == size - 1 && j == size - 1)) return false;
                }//проверяем на условие отсутствия ходов
            }
            return true;//иначе - выигрыш
        }

    }
}
