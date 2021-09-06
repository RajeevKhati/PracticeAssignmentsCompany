using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise11
{
    static class ExtendedIntMethods
    {
        public static bool IsOdd(this Int32 num)
        {
            if (num % 2 == 0)
                return false;
            return true;
        }

        public static bool IsEven(this Int32 num)
        {
            if (num % 2 == 0)
                return true;
            return false;
        }

        public static bool IsPrime(this Int32 num)
        {
            if (num <= 1)
                return false;
            for(int i=2; i<=Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }

        public static bool IsDivisibleBy(this Int32 num, int div)
        {
            if (num % div == 0)
                return true;
            return false;
        }
    }
}
