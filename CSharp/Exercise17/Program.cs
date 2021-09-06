using System;

namespace Exercise17
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            while (true)
            {
                if (count > 5)
                {
                    throw new CustomException();
                }
                count++;
                Console.WriteLine("Enter number from 1 to 5");
                int num = 0;
                try
                {
                    num = int.Parse(Console.ReadLine());
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                
                if(num<1 && num > 5)
                {
                    Console.WriteLine("Please enter a number from 1 to 5");
                    continue;
                }
                switch (num)
                {
                    case 1: 
                        Console.WriteLine("Enter Even Number.");
                        string input1 = Console.ReadLine();
                        if (Validate(input1, 'e'))
                        {
                            int x = int.Parse(input1);
                            if (x % 2 == 0)
                            {
                                Console.WriteLine("SUCCESS!!!!!!!");
                            }
                            else
                            {
                                Console.WriteLine("Not a even number");
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter Odd Number");
                        string input2 = Console.ReadLine();
                        if (Validate(input2, 'o'))
                        {
                            int x = int.Parse(input2);
                            if (x % 2 == 1)
                            {
                                Console.WriteLine("SUCCESS!!!!!!!");
                            }
                            else
                            {
                                Console.WriteLine("Not a odd number");
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter Prime Number.");
                        string input3 = Console.ReadLine();
                        if (Validate(input3, 'p'))
                        {
                            int x = int.Parse(input3);
                            if(x<=1)
                                Console.WriteLine("Not prime");
                            else
                            {
                                bool res = true;
                                for (int i = 2; i <= Math.Sqrt(x); i++)
                                {
                                    if (x % i == 0)
                                        res = false;
                                }
                                if(res)
                                    Console.WriteLine("SUCCESS!!!!!!!");
                                else
                                {
                                    Console.WriteLine("Not a prime");
                                }
                            }
                            
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter Negative Number");
                        string input4 = Console.ReadLine();
                        if (Validate(input4, 'n'))
                        {
                            int x = int.Parse(input4);
                            if (x < 0)
                            {
                                Console.WriteLine("SUCCESS!!!!!!!");
                            }
                            else
                            {
                                Console.WriteLine("Not a negative number");
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("Enter Zero");
                        string input5 = Console.ReadLine();
                        if (Validate(input5, 'z'))
                        {
                            int x = int.Parse(input5);
                            if (x == 0)
                            {
                                Console.WriteLine("SUCCESS!!!!!!!");
                            }
                            else
                            {
                                Console.WriteLine("Not a zero");
                            }
                        }
                        break;

                }

            }

        }

        private static bool Validate(string input, char ch)
        {
            bool isPossible = int.TryParse(input, out int num);
            if(isPossible)
            {
                if (num < 0 && ch!='n')
                {
                    throw new Exception("input is not a positive Integer");
                }
                return true;
            }
            else if(double.TryParse(input, out double num1))
            {
                throw new Exception("input cannot have decimal in it");
            }
            else
            {
                throw new Exception("input is not a valid positive Integer");
            }
        }
    }
}
