using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise14
{
    class Inventory
    {
        public IDictionary<Product, int> Products;
        public int TotalValue;

        public Inventory()
        {
            Products = new Dictionary<Product, int>();
        }

        public bool AddProduct(Product product, int quantity)
        {
            
            if (product.IsDefective == false && Products.ContainsKey(product) == false)
            {
                Products.Add(product, quantity);
                this.TotalValue += product.Price * quantity;
                return true;
            }

            return false;
        }

        public bool RemoveProduct(Product product)
        {
            if (Products.ContainsKey(product))
            {
                Products.Remove(product);
                this.TotalValue -= product.Price * Products[product];
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateProductQuantity(Product product, int val, bool addition)
        {
            if (Products.ContainsKey(product))
            {
                if (addition)
                {
                    Products[product] += val;
                    this.TotalValue += product.Price * val;
                }
                else
                {
                    if (val > Products[product])
                    {
                        Console.WriteLine("Doesn't have sufficient products..");
                        return false;
                    }
                    Products[product] -= val;
                    this.TotalValue -= product.Price * val;
                    if (Products[product] == 0)
                    {
                        Products.Remove(product);
                    }
                }
                return true;
            }
            return false;
        }

        //capturing price change event
        public void OnPriceChange(object source, int value)
        {
            Product p = (Product)source;
            if (Products.ContainsKey(p))
            {
                this.TotalValue = (this.TotalValue - (p.Price * Products[p])) + (value * Products[p]);
            }
        }

        public void OnDefectiveProductFound(object source, EventArgs args)
        {
            Product p = (Product)source;
            if (Products.ContainsKey(p))
            {
                this.TotalValue = this.TotalValue - p.Price * Products[p];
                Products.Remove(p);
            }
        }

        public void Print()
        {
            foreach(var entry in Products)
            {
                Console.WriteLine("Product = "+entry.Key+" , Quantity = "+entry.Value +
                                  ", Total value = " + this.TotalValue);
            }
            Console.WriteLine("*************");
        }



    }
}
