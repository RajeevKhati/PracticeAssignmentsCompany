using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise10
{
    /// <summary>
    /// small number ==> higher priority
    /// </summary>
    class PriorityQueue3<T> where T : IEquatable<T>
    {
        private class PriorityNode
        {
            public int Priority { get; private set; }
            public T Data { get; private set; }

            public PriorityNode(int priority, T data)
            {
                this.Priority = priority;
                this.Data = data;
            }
        }

        private IList<PriorityNode> elements;

        public PriorityQueue3()
        {
            elements = new List<PriorityNode>();
        }


        //Why??
        public PriorityQueue3(IDictionary<int, IList<T>> elements) : this()
        {

        }

        public int Count;

        public bool Contains(T item)
        {
            foreach(PriorityNode node in elements)
            {
                if (node.Data.Equals(item))
                    return true;
            }

            return false;
        }

        public T Dequeue()
        {
            if (Count == 0)
                return default(T);

            swap(0, elements.Count - 1);
            T res = elements[elements.Count - 1].Data;
            elements.RemoveAt(elements.Count - 1);
            Count--;
            downheapify(0);
            return res;
        }

        private void downheapify(int parentIndex)
        {
            int min = parentIndex;

            int leftIndex = 2 * parentIndex + 1;
            if(leftIndex<elements.Count && elements[leftIndex].Priority < elements[min].Priority)
            {
                min = leftIndex;
            }

            int rightIndex = 2 * parentIndex + 2;
            if (rightIndex < elements.Count && elements[rightIndex].Priority < elements[min].Priority)
            {
                min = rightIndex;
            }

            if (min != parentIndex)
            {
                swap(parentIndex, min);
                downheapify(min);
            }

        }

        public void Enqueue(int priority, T item)
        {
            PriorityNode node = new PriorityNode(priority, item);
            elements.Add(node);
            Count++;

            if(Count!=1)
                upheapify(elements.Count-1);
        }

        private void upheapify(int index)
        {
            if (index == 0)
                return;

            int parentIndex = (index - 1) / 2;
            if(elements[index].Priority < elements[parentIndex].Priority)
            {
                swap(index, parentIndex);
                upheapify(parentIndex);
            }

        }

        private void swap(int index, int parentIndex)
        {
            PriorityNode temp = elements[index];
            elements[index] = elements[parentIndex];
            elements[parentIndex] = temp;
        }

        public T Peek()
        {
            if (Count == 0)
                return default(T);
            return elements[0].Data;
        }

        private int GetHighestPriority()
        {
            if (Count == 0)
                return -1;
            return elements[0].Priority;
        }

        public void Print()
        {
            foreach (PriorityNode node in elements)
            {
                Console.WriteLine($"Priority:{node.Priority} , Data: {node.Data}");
            }
            Console.WriteLine("*************");
        }
    }
}
