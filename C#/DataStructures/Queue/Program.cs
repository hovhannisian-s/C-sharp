using MyQueue;
using System;

class Program
{
    static void Main()
    {
        var queue = new MyQueue<int>();

        Console.WriteLine("Enqueue 1, 2, 3");
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        Console.WriteLine("Peek: " + queue.Peek()); // 1
        Console.WriteLine("Count: " + queue.Count()); // 3

        Console.WriteLine("Dequeue: " + queue.Dequeue()); // 1
        Console.WriteLine("Peek after Dequeue: " + queue.Peek()); // 2
        Console.WriteLine("Count: " + queue.Count()); // 2

        Console.WriteLine("Enqueue 4, 5");
        queue.Enqueue(4);
        queue.Enqueue(5);

        Console.WriteLine("Queue elements:");
        foreach (var item in queue)
        {
            Console.Write(item + " "); // 2 3 4 5
        }
        Console.WriteLine();

        Console.WriteLine("ToArray test:");
        var arr = queue.ToArray();
        Console.WriteLine(string.Join(", ", arr)); // 2, 3, 4, 5

        Console.WriteLine("Contains 3? " + queue.Contains(3)); // True
        Console.WriteLine("Contains 10? " + queue.Contains(10)); // False

        Console.WriteLine("Clear queue");
        queue.Clear();
        Console.WriteLine("Count after Clear: " + queue.Count()); // 0

        try
        {
            queue.Dequeue(); // Should throw exception
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Exception on Dequeue from empty queue: " + ex.Message);
        }
    }
}
