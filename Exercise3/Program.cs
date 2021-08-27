using System;
using System.Collections.Generic;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Enter two numbers in range 2 and 1000.Please input smaller number first");

            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();
            int low = int.Parse(input1);
            int hi = int.Parse(input2);
            while (low > hi || low<2 || hi>1000)
            {
                Console.WriteLine("Please enter a small number first then a greater number or a valid range");
                low = int.Parse(Console.ReadLine());
                hi = int.Parse(Console.ReadLine());
            }

            bool[] sieve = GetSieve();

            for (int i =low; i<=hi; i++)
            {
                if (sieve[i] == false)
                {
                    Console.WriteLine(i);
                }
            }

        }

        private static bool[] GetSieve()
        {
            /*
             * false -> prime number
             * true -> not a prime number
             */
            bool[] isPrime = new bool[1000+1];
            isPrime[0] = true;
            isPrime[1] = true;
            for(int i=2; i*i<isPrime.Length; i++)
            {
                if (isPrime[i] == false)
                {
                    for(int j=2*i; j<isPrime.Length; j += i)
                    {
                        isPrime[j] = true;
                    }
                }
            }

            return isPrime;
        }
    }
}
