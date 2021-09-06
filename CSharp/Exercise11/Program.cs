using System;

namespace Exercise11
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 10;
            int num2 = 9;
            int num3 = 13;
            int num4 = 18;

            Console.WriteLine(num1.IsOdd());
            Console.WriteLine(num2.IsOdd());
            Console.WriteLine(num1.IsEven());
            Console.WriteLine(num2.IsEven());
            Console.WriteLine(num3.IsPrime());
            Console.WriteLine(num2.IsPrime());
            Console.WriteLine(num4.IsDivisibleBy(3));
            Console.WriteLine(num4.IsDivisibleBy(11));


        }
    }
}
