using System;

namespace Exercise8
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<string> pq = new PriorityQueue<string>();
            pq.Enqueue(1, "Binod");
            pq.Enqueue(2, "Suresh");
            pq.Enqueue(1, "Venkatesh");
            pq.Enqueue(3, "Raj");
            pq.Enqueue(4, "Adarsh");
            pq.Enqueue(10, "Sanket");
            pq.Enqueue(8, "Adil");

            pq.Print();

            Console.WriteLine("peek="+pq.Peek());

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
