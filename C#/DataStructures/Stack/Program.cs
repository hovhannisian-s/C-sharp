using System;
using MyStack;

class Program
{
    static void Main()
    {
        var stack1 = new MyStack<int>();
        stack1.Push(10);
        stack1.Push(20);
        stack1.Push(30);

        Console.WriteLine("Stack1 Count: " + stack1.Count()); // 3
        Console.WriteLine("Stack1 Top: " + stack1.Top());     // 30

        int popped = stack1.Pop();
        Console.WriteLine("Popped: " + popped);               // 30
        Console.WriteLine("New Top: " + stack1.Top());       // 20
        Console.WriteLine("New Count: " + stack1.Count());   // 2


        Console.WriteLine("Contains 10? " + stack1.Contains(10)); // True
        Console.WriteLine("Contains 30? " + stack1.Contains(30)); // False

        stack1.Clear();
        Console.WriteLine("Count after Clear: " + stack1.Count()); // 0
        Console.WriteLine("Empty? " + (stack1.Count() == 0));      // True


        int[] arr = { 1, 2, 3, 4 };
        var stack2 = new MyStack<int>(arr);
        Console.WriteLine("Stack2 Count: " + stack2.Count());      // 4
        Console.WriteLine("Stack2 Top: " + stack2.Top());          // 4

        var stack3 = new MyStack<int>(stack2);
        Console.WriteLine("Stack3 Count: " + stack3.Count());      // 4
        Console.WriteLine("Stack3 Top: " + stack3.Top());          // 4

        stack3.Pop();
        Console.WriteLine("After Pop Stack3 Top: " + stack3.Top()); // 3
        Console.WriteLine("Stack2 Top (unchanged): " + stack2.Top()); // 4

    
        var stackArray = stack3.ToArray();
        Console.WriteLine("Stack3 ToArray: " + string.Join(", ", stackArray)); // 3,2,1


        Console.WriteLine("Stack3 elements (foreach):");
        foreach (var item in stack3)
        {
            Console.WriteLine(item); // 3,2,1 (LIFO)
        }

        var emptyStack = new MyStack<int>();
        try
        {
            emptyStack.Pop();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message); // Stack is empty
        }

        try
        {
            emptyStack.Top();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message); // Stack is empty
        }
    }
}
