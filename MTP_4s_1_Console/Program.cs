using System;
using MTP_4s._1;

namespace MTP_4s_1_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> hs = new HashSet<string>();
            for (int i = 0; i < 5; i++)
            {
                hs.Add(i.ToString());
            }
            foreach (var item in hs)
            {
                Console.WriteLine(item);
            }
            /*HashSet<int> hs1 = new HashSet<int>();
            HashSet<int> hs2 = new HashSet<int>();
            HashSet<int> hs3 = new HashSet<int>();
            hs1.Add(1);
            hs1.Add(2);
            hs1.Add(3);
            hs2.Add(3);
            hs2.Add(4);
            hs2.Add(5);
            hs3 = hs1.Union(hs2);
            Console.WriteLine(hs3.Count);*/
            /*string a = "a";
            string b = "a";
            int c = Convert.ToInt32(a);
            Console.WriteLine("a : " + c.GetHashCode());
            c = Convert.ToInt32(b);
            Console.WriteLine("b : " + c.GetHashCode());*/

            /*HashSet<int> hs = new HashSet<int>();

            hs.Add(7);
            hs.Add(77);
            hs.Add(77);

            Console.WriteLine(hs.Count);*/

            /*badhash.Add("Петя");
            badhash.Add("Вася");
            badhash.Add("Зина");
            badhash.Add("Инга");

            Console.WriteLine(badhash.Contains("Петя"));
            Console.WriteLine(badhash.Contains("Вася"));
            Console.WriteLine(badhash.Contains("Зина"));
            Console.WriteLine(badhash.Contains("Инга"));*/
            /*Console.WriteLine("Количество элементов : " + badhash.Count);
            Console.WriteLine("Пустота : " + badhash.isEmpty);

            Console.WriteLine("Существование элемента 5 : " + badhash.Contains(5));
            Console.WriteLine("Существование элемента 10 : " + badhash.Contains(10));

            badhash.Remove(5);
            Console.WriteLine("Количество элементов : " + badhash.Count);

            badhash.Clear();

            Console.WriteLine("Существование элемента 5 : " + badhash.Contains(5));

            Console.WriteLine("Количество элементов : " + badhash.Count);
            Console.WriteLine("Пустота : " + badhash.isEmpty);*/

            Console.ReadKey();
        }
    }
}
