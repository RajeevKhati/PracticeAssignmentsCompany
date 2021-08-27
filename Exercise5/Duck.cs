using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    public enum TypeOfDuck
    {
        Rubber, Mallard, Redhead
    }
    public abstract class Duck : IDuck
    {
        public int weight;
        public int numberOfWings;
        public TypeOfDuck typeOfDuck;

        public Duck(int weight, int numberOfWings)
        {
            this.weight = weight;
            this.numberOfWings = numberOfWings;
        }

        public abstract void Fly();
        public abstract void Quack();

        public void Details()
        {
            Console.WriteLine("Weight: " + this.weight);
            Console.WriteLine("Number of wings: " + this.numberOfWings);
            Console.WriteLine("Type of duck: " + this.typeOfDuck);
            this.Fly();
            Console.WriteLine("AND");
            this.Quack();

        }

        public override string ToString()
        {
            return $"Type: {typeOfDuck}, Weight: {weight}, Number of wings: {numberOfWings}";
        }

    }
}
