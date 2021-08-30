using System;
using System.Linq;
using System.Collections.Generic;
using Exercise4;

namespace Exercise6
{
    class Program
    {
        static List<Equipment> list = new List<Equipment>();
        static void Main(string[] args)
        {

            PrintInstructions();
            bool loop = true;
            while (loop)
            {
                
                string input = Console.ReadLine();
                if(!int.TryParse(input, out int num))
                {
                    Console.WriteLine("Please enter valid input");
                    continue;
                }

                switch (num)
                {
                    case 1:
                        CreateAnEquipment();
                        break;
                    case 2:
                        DeleteAnEquipment();
                        break;
                    case 3:
                        MoveAnEquipment();
                        break;
                    case 4:
                        ListAllEquipments();
                        break;
                    case 5:
                        ShowDetailsOfAnEquipment();
                        break;
                    case 6:
                        ListAllMobileEquipments();
                        break;
                    case 7:
                        ListAllImmobileEquipments();
                        break;
                    case 8:
                        ListEquipmentsWhichAreNotMoved();
                        break;
                    case 9:
                        list.Clear();
                        break;
                    case 10:
                        list.RemoveAll(e => e.EquipmentType.CompareTo(TypeOfEquipment.Immobile) == 0);
                        break;
                    case 11:
                        list.RemoveAll(e => e.EquipmentType.CompareTo(TypeOfEquipment.Mobile) == 0);
                        break;
                    case 12:
                        PrintInstructions();
                        break;
                    case 13:
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Please enter valid input");
                        break;
                }
                PrintStars();

            }

        }

        private static void ShowDetailsOfAnEquipment()
        {
            Console.WriteLine("Enter name of equipment");
            string name = Console.ReadLine();
            foreach (Equipment equipment in list)
            {
                if (equipment.Name.ToLower().Equals(name.ToLower()))
                {
                    equipment.PrintDetails();
                    return;
                }
            }
            Console.WriteLine("No such equipment found");
        }

        private static void MoveAnEquipment()
        {
            Console.WriteLine("Enter name of equipment");
            string name = Console.ReadLine();
            Console.WriteLine("Enter distance by which it was moved");
            int dist = int.Parse(Console.ReadLine());
            foreach (Equipment equipment in list)
            {
                if (equipment.Name.ToLower().Equals(name.ToLower()))
                {
                    equipment.MovedBy(dist);
                    return;
                }
            }
            Console.WriteLine("No such equipment found");
        }

        private static void DeleteAnEquipment()
        {
            Console.WriteLine("Enter name of equipment");
            string name = Console.ReadLine();

            int i = 0;
            foreach(Equipment equipment in list)
            {
                if (equipment.Name.ToLower().Equals(name.ToLower()))
                {
                    list.RemoveAt(i);
                    return;
                }
                i++;
            }
            Console.WriteLine("No such equipment found");
        }

        private static void CreateAnEquipment()
        {
            Console.WriteLine("Press 1 to create Mobile equipments");
            Console.WriteLine("Press 2 to create Immobile equipments");
            Console.WriteLine("Press 3 to create some random equipments");
            int num = int.Parse(Console.ReadLine());
            switch (num)
            {
                case 1:
                    Console.WriteLine("Enter number of wheels");
                    int wheels = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter name of equipment");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter description");
                    string desc = Console.ReadLine();
                    Equipment mobile = new MobileEquipment(wheels, name, desc);
                    list.Add(mobile);
                    break;
                case 2:
                    Console.WriteLine("Enter weight");
                    int wt = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter name of equipment");
                    string name1 = Console.ReadLine();
                    Console.WriteLine("Enter description");
                    string desc1 = Console.ReadLine();
                    Equipment immobile = new ImmobileEquipment(wt, name1, desc1);
                    list.Add(immobile);
                    break;
                case 3:
                    CreateRandomEquipments();
                    break;
                default:
                    Console.WriteLine("Please enter valid input");
                    break;

            }

        }

        private static void PrintInstructions()
        {
            Console.WriteLine("Press One of the following numbers: ");
            Console.WriteLine("1 to Create and equipment");
            Console.WriteLine("2 to Delete an equipment");
            Console.WriteLine("3 to Move an equipment");
            Console.WriteLine("4 to List all equipment.");
            Console.WriteLine("5 to Show details of an equipment.");
            Console.WriteLine("6 to List all mobile equipment");
            Console.WriteLine("7 to List all Immobile equipment");
            Console.WriteLine("8 List all equipment that have not been moved till now");
            Console.WriteLine("9 to Delete all equipment");
            Console.WriteLine("10 to Delete all immobile equipment");
            Console.WriteLine("11 to Delete all mobile equipment");
            Console.WriteLine("12 to display menu");
            Console.WriteLine("13 to quit application");
        }

        private static void ListEquipmentsWhichAreNotMoved()
        {
            var notMovedEquipments = from equipment in list
                                     where equipment.DistanceMovedTillDate == 0
                                     select equipment;
            Console.WriteLine("Listing all equipments which haven't been moved till date...");
            foreach (Equipment equipment in notMovedEquipments)
            {
                Console.WriteLine(equipment);
            }
        }

        private static void ListAllImmobileEquipments()
        {
            var allImmobileEquipments = list.FindAll(e => e.EquipmentType.CompareTo(TypeOfEquipment.Immobile) == 0);
            Console.WriteLine("Listing all Immobile equipments...");
            foreach (Equipment equipment in allImmobileEquipments)
            {
                Console.WriteLine(equipment.Name + " : " + equipment.Description);
            }
        }

        private static void ListAllMobileEquipments()
        {
            var allMobileEquipments = list.FindAll(e => e.EquipmentType.CompareTo(TypeOfEquipment.Mobile) == 0);
            Console.WriteLine("Listing all mobile equipments...");
            foreach(Equipment equipment in allMobileEquipments)
            {
                Console.WriteLine(equipment.Name + " : " + equipment.Description);
            }
        }

        private static void ListAllEquipments()
        {
            Console.WriteLine("Listing all equipments...");
            foreach(Equipment equipment in list)
            {
                Console.WriteLine(equipment.Name + " : " + equipment.Description);
            }
        }

        private static void PrintStars()
        {
            Console.WriteLine("***********************");
        }

        private static void CreateRandomEquipments()
        {
            Equipment jcb = new MobileEquipment(4, "JCB", "Used in digging.");
            Equipment jeep = new MobileEquipment(4, "Jeep", "Used in travelling when you have more number of people.");
            Equipment tractor = new MobileEquipment(4, "Tractor", "Used in transporting goods.");

            Equipment ladder = new ImmobileEquipment(12, "Ladder", "Used to reach a particular height.");
            Equipment trolley = new ImmobileEquipment(100, "Trolley", "Used to move limited objects to a particular distance.");
            Equipment rack = new ImmobileEquipment(500, "Rack", "Used to store useful things to use later");

            list.Add(jcb);
            list.Add(ladder);
            list.Add(trolley);
            list.Add(jeep);
            list.Add(tractor);
            list.Add(rack);
        }
    }
}
