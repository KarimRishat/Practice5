using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Metodichka
{
    class Program
    {
        static void PrintMatrix (int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static int[] GetVowСonsCount(char[] text)
        {
            string RUS_VOWELS = "аеёиоуыэюя";
            int[] vowsConsCount = new int[2] { 0, 0 };
            
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    if (RUS_VOWELS.Contains(char.ToLower(text[i]).ToString()))
                        vowsConsCount[0]++;
                    else
                        vowsConsCount[1]++;
                }
            }
            return vowsConsCount;
        }
        
        static int[,] Mult(int[,] a,int[,] b)
        {
            int[,] c = new int[a.GetLength(0),b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return c;
        }
        static double[] MonthValues(int[,] temper)
        {
            double[] values = new double[temper.GetLength(0)];
            for (int i = 0; i < temper.GetLength(0); i++)
            {
                double sum = 0;
                for (int j = 0; j < temper.GetLength(1); j++)
                {
                    sum += temper[i, j];
                }
                values[i] = Math.Round(sum / temper.GetLength(1), 1);
            }
            return values;
        }
        static void Main(string[] args)
        {
            //Task 1
            Random rnd = new Random();
            char[] Text = File.ReadAllText(@"Text.txt", Encoding.Default).ToCharArray();
            int[] VowСonsCount = GetVowСonsCount(Text);
            Console.WriteLine("Количество гласных букв в тексте: "+VowСonsCount[0]);
            Console.WriteLine("Количество согласных букв в тексте:"+VowСonsCount[1]);
            //Task 2
            Console.WriteLine("\nTask6.2\nКак вводить матрицы?\n1.Вручную;  2.Случайно");
            byte x = 2;
            if (!byte.TryParse(Console.ReadLine(),out x))
            {
                throw new FormatException("Необходимо ввести число");
            }
            switch (x)
            {
                case 1:
                    Console.WriteLine("Введите число строк и столбцов матрицы А:");
                    int n1 = Convert.ToInt32(Console.ReadLine()), m1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите число строк и столбцов матрицы В:");
                    int n2 = Convert.ToInt32(Console.ReadLine()), m2 = Convert.ToInt32(Console.ReadLine());
                    int[,] a = new int[n1, m1];
                    int[,] b = new int[n2, m2];
                    Console.WriteLine("Matrix A:");
                    for (int i = 0; i < n1; i++)
                    {
                        for (int j = 0; j < m1; j++)
                        {
                            a[i, j] = int.Parse(Console.ReadLine());
                        }
                    }
                    Console.WriteLine("Matrix B:");
                    for (int i = 0; i < n2; i++)
                    {
                        for (int j = 0; j < m2; j++)
                        {
                            b[i, j] = int.Parse(Console.ReadLine());
                        }
                    }
                    Console.WriteLine("A:");
                    PrintMatrix(a);
                    Console.WriteLine("B:");
                    PrintMatrix(b);
                    if (m1 == n2)
                    {
                        Console.WriteLine("Result:");
                        int[,] c = Mult(a, b);
                        PrintMatrix(c);
                    }
                    else
                    {
                        Console.WriteLine("Не получится умножить матрицы");
                    }
                    break;
                case 2:
                    int z = rnd.Next(1, 10);
                    n1 = rnd.Next(2, 10);
                    m2 = rnd.Next(2, 10);
                    int[,] a2 = new int[n1, z];
                    int[,] b2= new int[z, m2];
                    for (int i = 0; i < n1; i++)
                    {
                        for (int j = 0; j < z; j++)
                        {
                            a2[i, j] = rnd.Next(-100, 100);
                        }
                    }
                    for (int i = 0; i < z; i++)
                    {
                        for (int j = 0; j < m2; j++)
                        {
                            b2[i, j] = rnd.Next(-100, 100);
                        }
                    }
                    Console.WriteLine("A:");
                    PrintMatrix(a2);
                    Console.WriteLine("B:");
                    PrintMatrix(b2);
                    Console.WriteLine("Result:");
                    int[,] c2 = Mult(a2, b2);
                    PrintMatrix(c2);
                    break;
                default:
                    Console.WriteLine("1 или 2!");
                    break;
            }
            //Task 3
            int[,] temperature = new int[12, 30];
            for (int i = 0; i < temperature.GetLength(0); i++)
            {
                for (int j = 0; j < temperature.GetLength(1); j++)
                {
                    temperature[i, j] = rnd.Next(600)/10-30;
                }
            }
            double[] values = MonthValues(temperature);
            Array.Sort(values);
            Console.WriteLine($"Отсортированные средние значения равны: {String.Join(" ", values)}");
            Console.ReadKey();
        }
    }
}
