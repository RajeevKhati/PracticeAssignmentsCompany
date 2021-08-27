using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Exercise15
{
    class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<int> listOfNums = new ObservableCollection<int>();

            listOfNums.CollectionChanged += CollectionModified;

            listOfNums.Add(10);
            listOfNums.Add(20);
            listOfNums.Remove(10);
            listOfNums.Remove(20);
        }

        private static void CollectionModified(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == NotifyCollectionChangedAction.Add)
            {
                var item = e.NewItems[0];
                Console.WriteLine($"Element {item} is added in collection");
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                var item = e.OldItems[0];
                Console.WriteLine($"Element {item} is removed from collection");
            }

        }
    }
}
