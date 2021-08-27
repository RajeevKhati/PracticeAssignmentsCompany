using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise8
{
    /// <summary>
    /// Assuming ===> smaller the number, higher the priority
    /// objects of type T that have same priority will be stored in list and element at end of the list will be considered as highest priority.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class PriorityQueue<T> where T : IEquatable<T>
    {
        private IDictionary<int, IList<T>> elements;

        public PriorityQueue()
        {
            elements = new Dictionary<int, IList<T>>();
        }

        //Why this()?
        public PriorityQueue(IDictionary<int, IList<T>> elements)
        {
            this.elements = elements;
        }

        public int Count;

        public bool Contains(T item)
        {
            foreach(KeyValuePair<int, IList<T>> element in elements)
            {
                IList<T> list = element.Value;
                if (list.Contains(item))
                    return true;
            }

            return false;
        }

        public T Dequeue()
        {
            if (elements.Count == 0)
                return default(T);

            int min = GetHighestPriority();

            

            IList<T> list = elements[min];

            T dequeueItem = list[list.Count-1];
            list.RemoveAt(list.Count - 1);

            if (list.Count == 0)
            {
                elements.Remove(min);
            }

            Count--;

            return dequeueItem;
        }

        public void Enqueue(int priority, T item)
        {
            if (elements.ContainsKey(priority))
            {
                IList<T> list = elements[priority];
                list.Add(item);
            }
            else
            {
                IList<T> list = new List<T>();
                list.Add(item);
                elements.Add(priority, list);
            }

            Count++;
        }

        public T Peek()
        {
            if (elements.Count == 0)
                return default(T);

            int min = int.MaxValue;
            foreach (int key in elements.Keys)
            {
                if (key < min)
                {
                    min = key;
                }
            }

            IList<T> list = elements[min];
            T peekItem = list[list.Count - 1];

            return peekItem;
        }

        private int GetHighestPriority()
        {

            int min = int.MaxValue;
            foreach (int key in elements.Keys)
            {
                if (key < min)
                {
                    min = key;
                }
            }

            return min;
        }

        public void Print()
        {
            foreach (int key in elements.Keys)
            {
                IList<T> list = elements[key];
                Console.Write($"{key} : ");
                foreach(T item in list)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("*************");
        }

    }
}
