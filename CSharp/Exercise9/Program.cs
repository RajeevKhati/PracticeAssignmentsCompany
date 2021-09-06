using System;

namespace Exercise9
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue2<string> pq = new PriorityQueue2<string>();
            pq.Enqueue("Binod");
            pq.Enqueue("Suresh");
            pq.Enqueue("Venkatesh");
            pq.Enqueue("Raj");
            pq.Enqueue("Adarsh");
            pq.Enqueue("Sanket");
            pq.Enqueue("Adil");

            pq.Print();

            Console.WriteLine("peek=" + pq.Peek());

            pq.Dequeue();
            pq.Print();
            Console.WriteLine("peek=" + pq.Peek());
            pq.Dequeue();
            pq.Print();
            Console.WriteLine("peek=" + pq.Peek());
            pq.Dequeue();
            pq.Print();
            Console.WriteLine("peek=" + pq.Peek());
        }
    }
}
