using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Exercise14
{
    
    class Product : IEquatable<Product>
    {
        public event EventHandler<int> PriceChange;
        public event EventHandler DefectiveProductFound;

        private int _Id;
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        private int _Price;
        public int Price
        {
            get
            {
                return _Price;
            }
            set
            {
                //activating event
                OnPriceChange(value);
                _Price = value;
            }
        }

        private bool _IsDefective;
        public bool IsDefective
        {
            get
            {
                return _IsDefective;
            }
            set
            {
                if (value)
                    OnDefectiveProductFound();
                _IsDefective = value;
            }
        }

        public Product(int id, int price, bool isDefective)
        {
            this.Id = id;
            this.Price = price;
            this.IsDefective = isDefective;
        }

        //Raised an event
        protected virtual void OnPriceChange(int value)
        {
            if (PriceChange != null)
            {
                PriceChange(this, value);
            }
        }

        protected virtual void OnDefectiveProductFound()
        {
            if(DefectiveProductFound != null)
            {
                DefectiveProductFound(this, EventArgs.Empty);
            }
        }


        public bool Equals(Product other)
        {
            return this.Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"id: {Id}, price: {Price}, defective: {IsDefective}";
        }
    }
}
