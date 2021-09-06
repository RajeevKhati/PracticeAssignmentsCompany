using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise9
{
    interface IPriority
    {
        int Priority { get; set; }
    }
    class PriorityQueue2<T> : IPriority where T : IEquatable<T>
    {
        //public int Priority { get; set; }
        private IDictionary<int, IList<T>> elements;

        private int _Priority;
        public int Priority
        {
            get
            {
                return _Priority;
            }
            set
            {
                _Priority = value;
            }
        }

        public PriorityQueue2()
        {
            elements = new Dictionary<int, IList<T>>();
            Priority = 0;
        }


        public PriorityQueue2(IEnumerable<T> elements) : this()
        {
            foreach(T element in elements)
            {
                Enqueue(element);
            }
        }

        public int Count;

        public bool Contains(T item)
        {
            foreach(var pair in elements)
            {
                if (item.Equals(pair.Value[0]))
                    return true;
            }
            return false;
        }

        public T Dequeue()
        {
            if (elements.Count == 0)
            {
                return default(T);
            }
            Count--;
            T res = elements[Priority][0];
            elements.Remove(Priority);
            Priority--;
            return res;
        }

        public void Enqueue(T item)
        {
            Count++;
            Priority++;
            IList<T> list = new List<T>();
            list.Add(item);
            elements.Add(Priority, list);
        }

        public T Peek()
        {
            if (elements.Count == 0)
            {
                return default(T);
            }
            T res = elements[Priority][0];
            return res;
        }

        private int GetHighestPriority()
        {
            return Priority;
        }

        public void Print()
        {
            foreach (int key in elements.Keys)
            {
                IList<T> list = elements[key];
                Console.Write($"{key} : ");
                foreach (T item in list)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("*************");
        }
    }
}
