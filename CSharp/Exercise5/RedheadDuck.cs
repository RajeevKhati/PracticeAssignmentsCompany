using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    public class RedheadDuck : Duck
    {

        public RedheadDuck(int weight, int numberOfWings) : base(weight, numberOfWings)
        {
            this.DuckType = TypeOfDuck.Redhead;
        }
        public override void Fly()
        {
            Console.WriteLine("I fly really slow...");
        }

        public override void Quack()
        {
            Console.WriteLine("I quack mild...");
        }
    }
}
