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
        List<Duck> myList;

        public ListOfDucks()
        {
            myList = new List<Duck>();
        }

        public void AddADuck(Duck duck)
        {
            myList.Add(duck);
        }

        public void RemoveADuck(Duck duck)
        {
            myList.Remove(duck);
        }

        public void RemoveAllDucks()
        {
            myList.Clear();
        }

        public IEnumerator GetEnumerator()
        {
            return (from duck in myList
                   orderby duck.weight
                   select duck).GetEnumerator();
        }

        public void IterateInOrderOfWings()
        {
            var ducks = from duck in myList
                        orderby duck.numberOfWings
                        select duck;
            foreach(Duck duck in ducks)
            {
                Console.WriteLine(duck);
            }
        }

    
    }
}
