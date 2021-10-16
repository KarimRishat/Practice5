using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 2\nВведите фразу Гордона Рамзи из 4 слов");
            string phrase = Console.ReadLine().ToUpper();
            string vowels = "УЕЁЭОАЫЯИЮAEYUIO";
            if (phrase.Split().Length.Equals(4))
            {
                string newphrase = phrase.Replace(" ", "!!!! ").Replace("А", "@").Replace("A","@");
                for (int i = 0; i < newphrase.Length; i++)
                {
                    if (vowels.Contains(newphrase[i]))
                    {
                        newphrase = newphrase.Replace(newphrase[i], '*');
                    }
                }
                Console.WriteLine(newphrase + "!!!!");
            }
            else
            {
                Console.WriteLine("Введено не 4 слова");
            }
            Console.ReadKey();
        }
    }
}
