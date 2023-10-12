using System;
using System.Collections.Generic;
using System.IO;


namespace Tumakovdz6
{
    class Program
    {
        /// <summary>
        /// Умножение 2-ух матриц 2-го порядка.
        /// </summary>
        /// <param name="Mat1"> Матрица 1 </param>
        /// <param name="Mat2"> Матрица 2 </param>
        /// <returns> Результат умножения двух матриц. </returns>
        static int[,] Mats(int[,] Mat1, int[,] Mat2)
        {
            int[,] resMats = new int[2, 2];

            for (int i = 0; i < Mat1.GetLength(0); i++)
            {
                for (int j = 0; j < Mat2.GetLength(0); j++)
                {
                    resMats[i, j] = Mat1[i, 0] * Mat2[0, j] + Mat1[i, 1] * Mat2[1, j];
                }
            }

            return resMats;
        }

        /// <summary>
        /// Вывод матрицы 2-го порядка
        /// </summary>
        /// <param name="mat"> Массив </param>
        static void CreateMatrices(int[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write(String.Format("{0, 3}", mat[i, j]));
                }

                Console.WriteLine();

            }
        }

        /// <summary>
        /// Умножение 2-ух матриц 2-го порядка.
        /// </summary>
        /// <param name="Mat1"> Матрица 1 </param>
        /// <param name="Mat2"> Матрица 2 </param>
        /// <returns> Результат умножения двух матриц. </returns>
         static LinkedList<int> Mats(LinkedList<int> Mat1List, LinkedList<int> Mat2List)
        {
            LinkedList<int> resultMatrixList = new LinkedList<int>();

            resultMatrixList.AddLast(Mat1List.First.Value * Mat2List.First.Value + Mat1List.First.Next.Value * Mat2List.Last.Previous.Value);
            resultMatrixList.AddLast(Mat1List.First.Value * Mat2List.First.Next.Value + Mat1List.First.Next.Value * Mat2List.Last.Value);
            resultMatrixList.AddLast(Mat1List.Last.Previous.Value * Mat2List.First.Value + Mat1List.Last.Value * Mat2List.Last.Previous.Value);
            resultMatrixList.AddLast(Mat1List.Last.Previous.Value * Mat2List.First.Next.Value + Mat1List.Last.Value * Mat2List.Last.Value);

            return resultMatrixList;
        }

        /// <summary>
        /// Вывод матрицы 2-го порядка
        /// </summary>
        /// <param name="mat"> Массив </param>
        static void CreateMats(LinkedList<int> mat)
        {
            int count = 0;

            foreach (int number in mat)
            {
                Console.Write(String.Format("{0, 3}", number));
                count++;

                if (count % 2 == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Вычисление средней значение температуры 
        /// </summary>
        /// <param name="temp"> Температура  </param>
        /// <returns> Средняя температура </returns>
        static double[] CalculatesTemp(int[,] temp)
        {
            double[] monthTemp = new double[temp.GetLength(0)];

            for (int i = 0; i < temp.GetLength(0); i ++)
            {
                int tempSum = 0;

                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    tempSum += temp[i, j];
                }

                monthTemp[i] = (double)tempSum / temp.GetLength(1);
            }

            return monthTemp;
        }

        /// <summary>
        /// Вычисление среднего значения температуры
        /// </summary>
        /// <param name="monthTemp"> Средняя температура </param>
        static void CreateTemperature(double[] monthTemp)
        {
            for (int i = 0; i < monthTemp.Length; i++)
            {
                DateTime month = new DateTime(1000, 1, 1).AddMonths(i);
                string monthname = month.ToString("MMMMM");

                Console.WriteLine($"Средняя температура за {monthname} была {monthTemp[i]:F} градусов");
            }
        }

         /// <summary>
        /// Вычисление среднего значения температуры
        /// </summary>
        /// <param name="temp"> Температура </param>
        /// <returns> Средняя тепмература </returns>
        static Dictionary<string, double> CalculatesTemp(Dictionary<string, int[]> temp)
        {
            Dictionary<string, double> monthTempDictionary = new Dictionary<string, double>();

            foreach (KeyValuePair<string, int[]> month in temp)
            {
                int tempSum = 0;

                for (int i = 0; i < month.Value.Length; i++)
                {
                    tempSum += month.Value[i];
                }

                monthTempDictionary.Add(month.Key, (double)tempSum / month.Value.Length);
            }

            return monthTempDictionary;
        }

        /// <summary>
        /// Вычисление среднего значения температуры
        /// </summary>
        /// <param name="monthTempDictionary"> Средняя температура </param>
        static void CreateTemp(Dictionary<string, double> monthTempDictionary)
        {
            foreach (KeyValuePair<string, double> month in monthTempDictionary)
            {
                Console.WriteLine($"Средняя темепература за {month.Key} была {month.Value:F} градусов");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\nУПРАЖНЕНИЕ 6.2. Умножает матрицы 2-го порядка\n");

            Random randNum = new Random();
            int[,] Mat1 = new int[2, 2];
            int[,] Mat2 = new int[2, 2];
            int[,] resMats;

            for (int i = 0; i < Mat1.GetLength(0); i++)
            {
                for (int j = 0; j < Mat2.GetLength(1); j++)
                {
                    Mat1[i, j] = randNum.Next(10);
                    Mat2[i, j] = randNum.Next(10);
                }
            }

            resMats = Mats(Mat1, Mat2);

            CreateMatrices(Mat1);
            Console.WriteLine("*");
            CreateMatrices(Mat2);
            Console.WriteLine("=");
            CreateMatrices(resMats);

            Console.WriteLine("\nУПРАЖНЕНИЕ 6.2, но с использованием LINKEDLIST\n");

            Random ranNum = new Random();
            LinkedList<int> Mat1List = new LinkedList<int>();
            LinkedList<int> Mat2List = new LinkedList<int>();
            LinkedList<int> resMatList = new LinkedList<int>();

            for (int i = 0; i <= 3; i++)
            {
                Mat1List.AddLast(ranNum.Next(10));
                Mat2List.AddLast(ranNum.Next(10));
            }

            resMatList = Mats(Mat1List, Mat2List);

            CreateMats(Mat1List);
            Console.WriteLine("*");
            CreateMats(Mat2List);
            Console.WriteLine("=");
            CreateMats(resMatList);
        
            Console.WriteLine("\nУПРАЖНЕНИЕ 6.3.\n");

            Random randTemp = new Random();
            int[,] temp = new int[12, 30];
            double[] TempAr = new double[12];
            double YearTemp1 = 0;


            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    temp[i, j] = randTemp.Next(-91, 56);
                }
            }

            TempAr = CalculatesTemp(temp);
            CreateTemperature(TempAr);

            for (int i = 0; i < TempAr.Length; i++)
            {
                YearTemp1 += TempAr[i];
            }

            YearTemp1 /= TempAr.Length;


            Console.WriteLine("\nУПРАЖНЕНИЯ 6.3, но с использованием DICTIONARY\n");

            Dictionary<string, int[]> yearTemp = new Dictionary<string, int[]>();
            Dictionary<string, double> monthTempList = new Dictionary<string, double>();
            randTemp = new Random();
            YearTemp1 = 0;

            for (int i = 0; i < 12; i++)
            {
                int[] monthTemp = new int[30];

                for (int j = 0; j < 30; j++)
                {
                    monthTemp[j] = randTemp.Next(-91, 56);
                }

                DateTime month = new DateTime(1000, 1, 1).AddMonths(i);
                string monthname = month.ToString("MMMM");
                yearTemp.Add(monthname, monthTemp);
            }

            monthTempList = CalculatesTemp(yearTemp);
            CreateTemp(monthTempList);

            foreach (KeyValuePair<string, double> mounth in monthTempList)
            {
                YearTemp1 += mounth.Value;
            }

            YearTemp1 /= yearTemp.Count;

        }
    }
}