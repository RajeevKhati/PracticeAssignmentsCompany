using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise4
{
    public class ImmobileEquipment : Equipment
    {
        public int weight;

        public ImmobileEquipment(int weight, string name, string description) : base(name, description)
        {
            this.weight = weight;
            this.typeOfEquipment = TypeOfEquipment.Immobile;
        }

        public override void MovedBy(int distanceMoved)
        {
            this.distanceMovedTillDate += distanceMoved;
            this.maintenanceCost += weight * distanceMoved;
        }

        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine("weight: " + weight);
        }
    }
}
