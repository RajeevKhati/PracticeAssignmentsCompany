using System;

namespace Exercise14
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p = new Product(1651, 55, false);
            Inventory inv = new Inventory();
            //connecting publisher and subscriber
            p.PriceChange += inv.OnPriceChange;
            p.DefectiveProductFound += inv.OnDefectiveProductFound;

            inv.AddProduct(p, 5);
            inv.Print();
            p.Price = 50;
            inv.Print();
            p.IsDefective = true;
            inv.Print();

        }
    }
}
