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
        public int Weight;
        public int NumberOfWings;
        public TypeOfDuck DuckType;

        public Duck(int weight, int numberOfWings)
        {
            this.Weight = weight;
            this.NumberOfWings = numberOfWings;
        }

        public abstract void Fly();
        public abstract void Quack();

        public void Details()
        {
            Console.WriteLine("Weight: " + this.Weight);
            Console.WriteLine("Number of wings: " + this.NumberOfWings);
            Console.WriteLine("Type of duck: " + this.DuckType);
            this.Fly();
            Console.WriteLine("AND");
            this.Quack();

        }

        public override string ToString()
        {
            return $"Type: {DuckType}, Weight: {Weight}, Number of wings: {NumberOfWings}";
        }

    }
}
