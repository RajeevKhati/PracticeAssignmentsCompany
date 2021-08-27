using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise4
{
    public enum TypeOfEquipment
    {
        Mobile,
        Immobile
    }
    public abstract class Equipment
    {
        public string name;
        public string description;
        public int distanceMovedTillDate;
        public int maintenanceCost;
        public TypeOfEquipment typeOfEquipment;

        public Equipment(string name, string description)
        {
            this.name = name;
            this.description = description;
        }


        public abstract void MovedBy(int distanceMoved);

        public virtual void PrintDetails()
        {
            Console.WriteLine("name : " + this.name);
            Console.WriteLine("description: " + this.description);
            Console.WriteLine("distance moved till date: " + this.distanceMovedTillDate);
            Console.WriteLine("maintenance cost: " + this.maintenanceCost);
            Console.WriteLine("type of equipment: " + this.typeOfEquipment);
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
