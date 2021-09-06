using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    public class MallardDuck : Duck
    {
        public MallardDuck(int weight, int numberOfWings) : base(weight, numberOfWings)
        {
            this.DuckType = TypeOfDuck.Mallard;
        }
        public override void Fly()
        {
            Console.WriteLine("I can fly really fast..");
        }

        public override void Quack()
        {
            Console.WriteLine("I quack loud..");
        }
    }
}
