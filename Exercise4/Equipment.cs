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
        public string Name;
        public string Description;
        public int DistanceMovedTillDate;
        public int MaintenanceCost;
        public TypeOfEquipment EquipmentType;

        public Equipment(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }


        public abstract void MovedBy(int distanceMoved);

        public virtual void PrintDetails()
        {
            Console.WriteLine("name : " + this.Name);
            Console.WriteLine("description: " + this.Description);
            Console.WriteLine("distance moved till date: " + this.DistanceMovedTillDate);
            Console.WriteLine("maintenance cost: " + this.MaintenanceCost);
            Console.WriteLine("type of equipment: " + this.EquipmentType);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
