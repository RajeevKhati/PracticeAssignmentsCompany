using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise12
{

    class Program
    {

        static void Main(string[] args)
        {
            IList<int> list = GetListOfNumbers();
            Console.WriteLine("Original List :-");
            Print(list);
            //1.Find Odd - Lambda Expression
            IEnumerable<int> oddNums = list.Where(num => num % 2 == 1);
            Console.WriteLine("Odd Numbers :-");
            Print(oddNums);

            //2.Find Even - Lambda Expression with curly braces
            IEnumerable<int> evenNums = list.Where(num => { 
                                            return num % 2 == 0; 
                                        });
            Console.WriteLine("Even Numbers :-");
            Print(evenNums);

            //3.Find Prime - Anonymous Method
            IEnumerable<int> primeNums = list.Where(delegate (int num) {
                if (num <= 1)
                    return false;
                for(int i=2; i<=Math.Sqrt(num); i++)
                {
                    if (num % i == 0)
                        return false;
                }
                return true;
            });
            Console.WriteLine("Prime Numbers :-");
            Print(primeNums);

            //4.Find Prime - Lambda Expression
            IEnumerable<int> primeNums2 = list.Where(num => {
                if (num <= 1)
                    return false;
                for (int i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0)
                        return false;
                }
                return true;
            });
            Console.WriteLine("Again Prime Numbers :-");
            Print(primeNums2);

            //5.Find Elements greater than 5 - Method Group Conversion Syntax
            //Correction needed
            Func<int, bool> greaterThan5 = GreaterThan5;
            IEnumerable<int> numsGreaterThan5 = list.Where(greaterThan5);
            Console.WriteLine("Numbers Greater Than 5 :-");
            Print(numsGreaterThan5);

            //6.Find Less than Five – Delegate Object in Where – Method Group Conversion Syntax in Constructor of Object
            Func<int, bool> lessThan5 = new Func<int, bool>(LessThan5);
            IEnumerable<int> numsLessThan5 = list.Where(lessThan5);
            Console.WriteLine("Numbers Less than 5 :-");
            Print(numsLessThan5);

            //7.Find 3k – Delegate Object in Where –Lambda Expression in Constructor of Object
            Func<int,bool> find3K = new Func<int,bool>(num => num%3==0);
            IEnumerable<int> threeK = list.Where(find3K);
            Console.WriteLine("Multiples of 3 :-");
            Print(threeK);

            //8.Find 3k + 1 - Delegate Object in Where –Anonymous Method in Constructor of Object
            Func<int, bool> find3KPlus1 = new Func<int, bool>(delegate (int num) { return num % 3 == 1; });
            IEnumerable<int> threeKPlus1 = list.Where(find3KPlus1);
            Console.WriteLine("Numbers who leave remainder as 1 when divided by 3");
            Print(threeKPlus1);

            //9. Find 3k + 2 - Delegate Object in Where – Lambda Expression Assignment
            Func<int, bool> find3KPlus2 = num => num % 3 == 2;
            IEnumerable<int> threeKPlus2 = list.Where(find3KPlus2);
            Console.WriteLine("Numbers who leave remainder as 2 when divided by 3");
            Print(threeKPlus2);

            //10.Find anything - Delegate Object in Where – Anonymous Method Assignment
            Func<int, bool> negativeNums = delegate (int num) { return num < 0; };
            IEnumerable<int> negNums = list.Where(negativeNums);
            Console.WriteLine("Negative numbers :-");
            Print(negNums);

            //11.Find anything - Delegate Object in Where – Method Group Conversion Assignment
            Func<int, bool> positiveNums = PositiveNums;
            IEnumerable<int> posNums = list.Where(positiveNums);
            Console.WriteLine("Positive Numbers :-");
            Print(posNums);

        }

        private static bool PositiveNums(int num)
        {
            return num>0;
        }

        private static bool LessThan5(int num)
        {
            return num < 5;
        }

        private static bool GreaterThan5(int num)
        {
            return num > 5;
        }

        private static void Print(IEnumerable<int> list)
        {
            foreach(int num in list)
            {
                Console.Write(num+" ");
            }
            Console.WriteLine();
        }

        private static IList<int> GetListOfNumbers()
        {
            IList<int> list = new List<int>();
            list.Add(18);
            Random r = new Random();
            for(int i=0; i<30; i++)
            {
                list.Add(r.Next(-100, 100));
            }

            return list;
        }
    }
}
