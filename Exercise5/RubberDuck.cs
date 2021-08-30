using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    public class RubberDuck : Duck
    {
        public RubberDuck(int weight, int numberOfWings) : base(weight, numberOfWings)
        {
            this.DuckType = TypeOfDuck.Rubber;
        }
        public override void Fly()
        {
            Console.WriteLine("I can't fly...");
        }

        public override void Quack()
        {
            Console.WriteLine("I squeak...");
        }
    }
}
