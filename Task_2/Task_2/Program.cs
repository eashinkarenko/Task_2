using System;
using System.IO;

namespace Task_2
{
    class Program
    {
        public static long solve(long x1, long y1, long x2, long y2) //функция нахождения, сколько отрезков от пересечения до пересечения клеток на линии 
        { //пересечение - это дерево. Всё сводится к нахождению НОД 
            long dx = Math.Abs(x1 - x2); //абсолютная разница между абциссами 
            long dy = Math.Abs(y1 - y2); //абсолютная разница между ординатами 
            if (dx == 0) return dy; //если отрезок вертикальный 
            else if (dy == 0) return dx; //если отрезок горизонтальный 
            else
            {
                while (dy > 0)
                {
                    long t = dx % dy;
                    dx = dy;
                    dy = t;
                }
                return dx;
            }
        }

        static void Main(string[] args)
        {
            long x1, x2, x3, y1, y2, y3;
            using (StreamReader sr = new StreamReader("INPUT.txt")) //ввод из файла 
            {
                string[] spl = sr.ReadLine().Split();
                x1 = Convert.ToInt32(spl[0]);
                y1 = Convert.ToInt32(spl[1]);
                x2 = Convert.ToInt32(spl[2]);
                y2 = Convert.ToInt32(spl[3]);
                x3 = Convert.ToInt32(spl[4]);
                y3 = Convert.ToInt32(spl[5]);
                long answer = solve(x1, y1, x2, y2) + solve(x1, y1, x3, y3) + solve(x2, y2, x3, y3); //решение 

                File.WriteAllText("OUTPUT.txt", answer.ToString()); //вывод в файл
            }
        }
    }
}
