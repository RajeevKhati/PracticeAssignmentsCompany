using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise4
{
    public class MobileEquipment : Equipment
    {
        public int numberOfWheels;

        public MobileEquipment(int numberOfWheels, string name, string description) : base(name, description)
        {
            this.numberOfWheels = numberOfWheels;
            this.EquipmentType = TypeOfEquipment.Mobile;
        }

        public override void MovedBy(int distanceMoved)
        {
            this.DistanceMovedTillDate += distanceMoved;
            this.MaintenanceCost += numberOfWheels * distanceMoved;
        }

        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine("number of wheels: " + numberOfWheels);
            Console.WriteLine("***************");
        }
    }
}
