﻿using System;
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
            this.typeOfEquipment = TypeOfEquipment.Mobile;
        }

        public override void MovedBy(int distanceMoved)
        {
            this.distanceMovedTillDate += distanceMoved;
            this.maintenanceCost += numberOfWheels * distanceMoved;
        }

        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine("number of wheels: " + numberOfWheels);
        }
    }
}
