using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string to convert it to an integer");
            string str = Console.ReadLine();
            DisplayConvertedInt(str);

            Console.WriteLine("Enter a string to convert it to a float");
            str = Console.ReadLine();
            DisplayConvertedFloat(str);

            Console.WriteLine("Enter a string to convert it to a boolean (Only \"true\" and \"false\" is permitted)");
            str = Console.ReadLine();
            DisplayConvertedBoolean(str);

        }

        private static void DisplayConvertedInt(string str)
        {
            //1st method to convert string to integer

            bool isPossible = int.TryParse(str, out int i1);

            //isPossible will be true if str can be converted to integer otherwise it will be false
            if (isPossible)
                Console.WriteLine("Coversion from string to int using int.TryParse() "+i1);
            else
            {
                Console.WriteLine($"String {str} cannot be converted into integer");
                //returning if string is not a valid integer
                return;
            }


            //2nd method to convert string to integer
            int i2 = int.Parse(str);
            Console.WriteLine("Coversion from string to int using int.Parse() "+ i2);


            //3rd method to convert string to integer
            int i3 = Convert.ToInt32(str);
            Console.WriteLine("Coversion from string to int using Convert.ToInt32() "+i3);
        }


        private static void DisplayConvertedFloat(string str)
        {
            bool isPossible = float.TryParse(str, out float f1);

            //isPossible will be true if str can be converted to float otherwise it will be false
            if (isPossible)
                Console.WriteLine("Coversion from string to float using float.TryParse() " + f1);
            else
            {
                Console.WriteLine($"String {str} cannot be converted into float");
                //returning if string is not a valid float
                return;
            }


            //2nd method to convert string to float
            float f2 = float.Parse(str);
            Console.WriteLine("Coversion from string to float using float.Parse() " + f2);


            //3rd method to convert string to float
            //*********might lost precision***********
            float f3 = (float)Convert.ToDouble(str);
            Console.WriteLine("Coversion from string to float using Convert.ToDouble() " + f3);
        }


        private static void DisplayConvertedBoolean(string str)
        {
            bool isPossible = bool.TryParse(str, out bool b1);

            //isPossible will be true if str can be converted to boolean otherwise it will be false
            if (isPossible)
                Console.WriteLine("Coversion from string to boolean using bool.TryParse() " + b1);
            else
            {
                Console.WriteLine($"String {str} cannot be converted into boolean");
                //returning if string is not a valid boolean
                return;
            }


            //2nd method to convert string to boolean
            bool b2 = bool.Parse(str);
            Console.WriteLine("Coversion from string to boolean using bool.Parse() " + b2);


            //3rd method to convert string to boolean
            bool b3 = Convert.ToBoolean(str);
            Console.WriteLine("Coversion from string to boolean using Convert.ToBoolean() " + b3);
        }
    }
}

