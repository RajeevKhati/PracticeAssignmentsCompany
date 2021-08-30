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

            IList<string> listOfNames = new List<string>
            {
                "raj", "sanket", "sb","adarsh", "mayank", "rahul", "keshav", "shubham", "vikas", "mukesh", "farhan", "roshan"
            };

            //Testing CustomAll
            Console.WriteLine(listOfNums.CustomAll(num => num is int));
            Console.WriteLine(listOfNames.CustomAll(name => name is object));

            //Testing CustomAny
            Console.WriteLine(listOfNums.CustomAny(num => num>5));
            Console.WriteLine(listOfNames.CustomAny(name => name.StartsWith('z')));

            //Testing CustomMax
            Console.WriteLine(listOfNums.CustomMax());
            Console.WriteLine(listOfNames.CustomMax());

            //Testing CustomMin
            Console.WriteLine(listOfNums.CustomMin());
            Console.WriteLine(listOfNames.CustomMin());

            //Testing CustomWhere
            IEnumerable<int> evenNums = listOfNums.CustomWhere(num => num % 2 == 0);
            Print(evenNums);
            IEnumerable<string> nameStartingWithR = listOfNames.CustomWhere(name => name.StartsWith('r'));
            Print(nameStartingWithR);

            //Testing CustomSelect
            IEnumerable<int> doubleOfNumbers = listOfNums.CustomSelect(num => num*2);
            Print(doubleOfNumbers);
            IEnumerable<string> namesAppendedWithFullStop = listOfNames.CustomSelect(name => name + ".");
            Print(namesAppendedWithFullStop);

        }

        private static void Print<T>(IEnumerable<T> list)
        {
            foreach (T value in list)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }

        //This method generates some random numbers, insert it into a list and returns it.
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
