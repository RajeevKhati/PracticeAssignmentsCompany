using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise13
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> listOfNums = GetListOfNumbers();
            Print(listOfNums);

            IList<string> listOfStrings = new List<string>
            {
                "raj", "sanket", "sb","adarsh", "mayank", "rahul"
            };

            Console.WriteLine(listOfNums.CustomMax());
            Console.WriteLine(listOfStrings.CustomMax());
            Console.WriteLine(listOfNums.CustomMin());
            Console.WriteLine(listOfStrings.CustomMin());

        }

        private static void Print(IEnumerable<int> list)
        {
            foreach (int num in list)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        private static IList<int> GetListOfNumbers()
        {
            IList<int> list = new List<int>();
            Random r = new Random();
            for (int i = 0; i < 20; i++)
            {
                list.Add(r.Next(1, 100));
            }

            return list;
        }
    }
}
