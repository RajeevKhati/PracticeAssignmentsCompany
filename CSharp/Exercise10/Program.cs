using System;

namespace Exercise10
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue3<string> pq = new PriorityQueue3<string>();
            pq.Enqueue(1, "Binod");
            pq.Enqueue(8, "Adil");
            pq.Enqueue(2, "Suresh");
            pq.Enqueue(1, "Venkatesh");
            pq.Enqueue(4, "Adarsh");
            pq.Enqueue(3, "Raj");
            pq.Enqueue(10, "Sanket");
            

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
