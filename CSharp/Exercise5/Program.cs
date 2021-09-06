using System;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            IDuck rubber = new RubberDuck(20, 2);
            IDuck redhead = new RedheadDuck(15, 2);
            IDuck mallard = new MallardDuck(25, 2);

            rubber.Details();
            redhead.Details();
            mallard.Details();
        }
    }
}
