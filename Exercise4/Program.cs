using System;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            Equipment jeep = new MobileEquipment(4, "jeep", "this is jeep");
            Equipment ladder = new ImmobileEquipment(6, "ladder", "this is ladder");

            jeep.MovedBy(20);
            ladder.MovedBy(10);

            jeep.PrintDetails();
            ladder.PrintDetails();
        }
    }
}
