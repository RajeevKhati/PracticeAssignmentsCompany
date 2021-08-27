using System;
using System.Collections.Generic;
using Exercise5;

namespace Exercise7
{
    class Program
    {
        static void Main(string[] args)
        {
            ListOfDucks ducks = new ListOfDucks();
            ducks = getDucks();

            //this foreach iterates ducks collection according to increasing number of weights
            foreach(Duck duck in ducks)
            {
                Console.WriteLine(duck);
            }
            Console.WriteLine("***************");
            ducks.IterateInOrderOfWings();

        }

        private static ListOfDucks getDucks()
        {
            Duck d1 = new RubberDuck(1, 1);
            Duck d2 = new RubberDuck(2, 3);
            Duck d3 = new MallardDuck(16, 2);
            Duck d4 = new MallardDuck(11, 5);
            Duck d5 = new RedheadDuck(26, 6);
            Duck d6 = new RedheadDuck(23, 2);
            Duck d7 = new RubberDuck(10, 4);
            Duck d8 = new RubberDuck(50, 7);

            ListOfDucks ducks = new ListOfDucks();
            ducks.AddADuck(d1);
            ducks.AddADuck(d6);
            ducks.AddADuck(d3);
            ducks.AddADuck(d4);
            ducks.AddADuck(d2);
            ducks.AddADuck(d5);
            ducks.AddADuck(d7);
            ducks.AddADuck(d8);

            return ducks;

        }
    }
}
