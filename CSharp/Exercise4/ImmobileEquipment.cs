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
            this.EquipmentType = TypeOfEquipment.Immobile;
        }

        public override void MovedBy(int distanceMoved)
        {
            this.DistanceMovedTillDate += distanceMoved;
            this.MaintenanceCost += weight * distanceMoved;
        }

        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine("weight: " + weight);
            Console.WriteLine("***************");
        }
    }
}
