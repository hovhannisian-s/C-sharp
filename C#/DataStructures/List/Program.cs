using System;
using MyList;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== MyList<T> Testing ===");

        // 1️⃣ Add
        MyList<int> list = new MyList<int>();
        list.Add(10);
        list.Add(20);
        list.Add(30);
        Console.WriteLine("After Add:");
        list.Print(); // 10 20 30

        // 2️⃣ AddRange
        list.AddRange(new int[] { 40, 50 });
        Console.WriteLine("After AddRange:");
        list.Print(); // 10 20 30 40 50

        // 3️⃣ Insert
        list.Insert(2, 25);
        Console.WriteLine("After Insert 25 at index 2:");
        list.Print(); // 10 20 25 30 40 50

        // 4️⃣ InsertRange
        list.InsertRange(3, new int[] { 26, 27 });
        Console.WriteLine("After InsertRange at index 3:");
        list.Print(); // 10 20 25 26 27 30 40 50

        // 5️⃣ Remove / RemoveAt
        list.Remove(27);
        list.RemoveAt(0);
        Console.WriteLine("After Remove 27 and RemoveAt 0:");
        list.Print(); // 20 25 26 30 40 50

        // 6️⃣ RemoveRange
        list.RemoveRange(1, 2);
        Console.WriteLine("After RemoveRange index 1, count 2:");
        list.Print(); // 20 30 40 50

        // 7️⃣ Contains, IndexOf, LastIndexOf
        Console.WriteLine($"Contains 30? {list.Contains(30)}"); // True
        Console.WriteLine($"IndexOf 40: {list.IndexOf(40)}");   // 2
        Console.WriteLine($"LastIndexOf 50: {list.LastIndexOf(50)}"); // 3

        // 8️⃣ Find / FindAll / Exists
        int found = list.Find(x => x > 35);
        Console.WriteLine($"Find first > 35: {found}"); // 40

        var allGT25 = list.FindAll(x => x > 25);
        Console.Write("FindAll > 25: ");
        allGT25.Print(); // 30 40 50

        bool exists = list.Exists(x => x % 2 == 0);
        Console.WriteLine($"Exists even? {exists}"); // True

        // 9️⃣ ForEach
        Console.Write("ForEach x*2: ");
        list.ForEach(x => Console.Write(x * 2 + " "));
        Console.WriteLine();

        // 🔟 Reverse
        list.Reverse();
        Console.WriteLine("After Reverse:");
        list.Print(); // 50 40 30 20

        // 1️⃣1️⃣ Sort
        list.Sort();
        Console.WriteLine("After Sort ascending:");
        list.Print(); // 20 30 40 50

        list.Sort(false);
        Console.WriteLine("After Sort descending:");
        list.Print(); // 50 40 30 20

        // 1️⃣2️⃣ ToArray / CopyTo
        int[] arr = new int[list.ToArray().Length];
        list.CopyTo(arr);
        Console.Write("CopyTo array: ");
        foreach(var a in arr) Console.Write(a + " ");
        Console.WriteLine();

        // 1️⃣3️⃣ BinarySearch
        list.Sort();
        int idx = list.BinarySearch(40);
        Console.WriteLine($"BinarySearch 40: index {idx}"); // 2

        // 1️⃣4️⃣ TrimExcess
        list.TrimExcess();
        Console.WriteLine("After TrimExcess:");
        list.Print();

        // 1️⃣5️⃣ foreach support
        Console.Write("Iterate with foreach: ");
        foreach(var x in list)
            Console.Write(x + " ");
        Console.WriteLine();

        Console.WriteLine("=== MyList<T> Test Finished ===");
    }
}

