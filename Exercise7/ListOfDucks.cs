using Exercise5;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Exercise7
{
    class ListOfDucks : IEnumerable
    {
        List<Duck> MyListOfDucks;

        public ListOfDucks()
        {
            MyListOfDucks = new List<Duck>();
        }

        public void AddADuck(Duck duck)
        {
            MyListOfDucks.Add(duck);
        }

        public void RemoveADuck(Duck duck)
        {
            MyListOfDucks.Remove(duck);
        }

        public void RemoveAllDucks()
        {
            MyListOfDucks.Clear();
        }

        public IEnumerator GetEnumerator()
        {
            return (from duck in MyListOfDucks
                   orderby duck.Weight
                   select duck).GetEnumerator();
        }

        public void IterateInOrderOfWings()
        {
            var ducks = from duck in MyListOfDucks
                        orderby duck.NumberOfWings
                        select duck;
            foreach(Duck duck in ducks)
            {
                Console.WriteLine(duck);
            }
        }

    
    }
}
