using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Classwork
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task1
            int n = 10, countB = 0, countC = 0;
            int[] Bavar = new int[n];
            int[] Scand = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                Bavar[i] = rnd.Next(0, 9);
                Scand[i] = rnd.Next(0, 9);
            }
            Console.WriteLine("Task1");
            for (int i = 0; i < Bavar.Length; i++)
            {
                if (Bavar[i] == 5)
                {
                    countB++;
                }
                if (Scand[i] == 5)
                {
                    countC++;
                }
            }
            if (countC == countB)
            {
                Console.WriteLine("Drinks All Round! Free Beers on Bjorg!");
            }
            else
            {
                Console.WriteLine("Ой,Бьорг - пончик! Ни для кого пива!");
            }
            //Task2
            Console.WriteLine("Task2\nИзначальный список картинок");
            string path = @"Cards";
            IEnumerable<string> img = Directory.EnumerateFiles(path, "*.png");
            List<string> images = img.ToList();
            foreach (string item in images)
            {
                Console.WriteLine(item.Remove(0, 6));
            }
            for (int i = 0; i < images.Count; i++)
            {
                string tmp = images[i];
                images.RemoveAt(i);
                images.Insert(rnd.Next(images.Count), tmp);
            }
            Console.WriteLine("\nПеремешанный массив:");
            foreach (string item in images)
            {
                Console.WriteLine(item.Remove(0, 6));
            }

            Console.ReadKey();
        }
    }
}
