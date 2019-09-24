using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab2Rassohin
{
    class Program
    {
        private static int sizeMatr;
        static void Main(string[] args)
        {
            Console.WriteLine("Создадим уникальную матрицу и заполним ее. Готовы к генерации? (отрицательные ответы не принимаются, хе-хе)");

            //Используем регулярные выражения, чтобы найти все вхождения подстроки "да" в строке из Console.ReadLine();
            Regex regex = new Regex(@"да(\w*)", RegexOptions.IgnoreCase);
            string result = Console.ReadLine();

            //Ищем вхождения подстроки в строку
            MatchCollection matches = regex.Matches(result);
            
            
            if (matches.Count > 0)
            {
                Console.WriteLine("Вы сказали ДА, начинаем");
                //Используем класс Random
                Random random = new Random();

                //Объявим случаюную квадратную матрицу (двумерный массив) с нечетной стороной

                sizeMatr = random.Next(3, 15);
                if (sizeMatr % 2 == 0)
                {
                    sizeMatr--;
                }
                int[,] matr = new int[sizeMatr, sizeMatr];

                //Инициализация матрицы
                matrInput(matr, sizeMatr);
                Console.WriteLine("Вот, что получилось: ");
                matrOutput(matr, sizeMatr);
                Console.WriteLine();

                //Переведем матрицу в одномерный массив для сортировка
                int[] arr = getArray(matr);
                Console.WriteLine("Одномерный массив");
                arrayOutputLine(arr);
                Console.WriteLine();

                //Сортируем одномерный массив
                Array.Sort(arr);
                Console.WriteLine("Отсортированный одномерный массив массив");
                arrayOutputLine(arr);
                Console.WriteLine();

                Console.WriteLine("ИТОГ");
                spiralParse(matr, arr, sizeMatr);

                Console.ReadLine();

            }
            
        }

        /// <summary>
        /// Функция для ввода данных в матрицы
        /// </summary>
        private static void matrInput(int[,] matr, int size)
        {
           
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int k = 0; k < size; k++)
                {
                    
                    matr[i, k] = random.Next(1, 100);
                }
            }
        }

        /// <summary>
        /// Функция для вывода матрицы в консоль
        /// </summary>
        private static void matrOutput(int[,] matr, int size)
        {
            //GetLength(0) - длина строк
            //GetLength(1) - длина столбцов
            for (int i = 0; i < size; i++)
            {
                for (int k = 0; k <size; k++)
                {
                    Console.Write("{0}\t", matr[i, k]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Выводит массив в строку
        /// </summary>
        /// <param name="arr"></param>
        private static void arrayOutputLine(int[] arr)
        {
            foreach (int element in arr)
            {
                Console.Write("{0}  ", element);
            }
        }

        /// <summary>
        /// Массив из матрицы
        /// </summary>
        /// <param name="matr"></param>
        /// <returns></returns>
        public static int[] getArray(int[,] matr)
        {
            //GetLength(0) - длина строк
            //GetLength(1) - длина столбцов
            int[] arrayFromMatr = new int[matr.Length];
            
            //Счетчик массива
            int numStepArr =0;

            for (int i = 0; i < matr.GetLength(0); i++)
                for (int k = 0; k < matr.GetLength(1); k++)
                    arrayFromMatr[numStepArr++] = matr[i, k];
            return arrayFromMatr;
        }

        /// <summary>
        /// Спираль
        /// </summary>
        /// <param name="matr"></param>
        /// <param name="arr"></param>
        /// <param name="size"></param>
        private static void spiralParse(int[,] matr, int[] arr, int size)
        {
            //начинаем наше движение в центре
            int center = size / 2;
            int matrSize = arr.Length;

            int d = 0; // 0 - движение вправо, //1 - вверх, // 2-влево // 3-вниз
            
            //Позиция
            int x = center;
            int y = center;
            int minX = x;
            int maxX = x;
            int minY = y;
            int maxY = y;
            for (int i = 0; i < matrSize; i++)
            {
                matr[y, x] = arr[i]; //Заполняем

                switch (d)
                {
                    case 0:
                        x += 1;
                      //  Console.WriteLine("x: {0}, y: {1}", x, y);
                        if (x > maxX)
                        {
                            d = 1;
                            maxX = x;
                          
                            continue;
                        }
                        
                        break;
                    case 1:
                        y -= 1;
                       // Console.WriteLine("x: {0}, y: {1}", x, y);
                        if (y < minY)
                        {
                            d = 2;
                            minY = y;
                          
                            continue;
                        }

                        break;
                    case 2:
                        x -= 1;
                      //  Console.WriteLine("x: {0}, y: {1}", x, y);
                        if (x < minX)
                        {
                            d = 3;

                            minX = x;
                     
                            continue;
                        }

                        break;
                    case 3:
                        y += 1;
                     //   Console.WriteLine("x: {0}, y: {1}", x, y);
                        if (y > maxY)
                        {
                            d = 0;
                            maxY = y;
                          
                            continue;
                        }

                        break;
                }
            }

            matrOutput(matr, size);



        }
    }
}


