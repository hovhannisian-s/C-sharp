namespace MyProject1
{
    public static class SortingAlgorithms
    {
        // -----------------------------------------------//
        // Insertion Sort (generic, ascending/descending) //
        // -----------------------------------------------//
        public static void InsertionSort<T>(T[] arr, bool asc = true) where T : IComparable<T>        
        {
            for(int i = 1; i < arr.Length; ++i)
            {
                T currentNum = arr[i];
                int j = i;
                // Move elements greater/smaller than currentNum to the right
                while((j > 0) && (asc ? arr[j - 1].CompareTo(currentNum) > 0 : arr[j - 1].CompareTo(currentNum) < 0 ))
                {
                    arr[j] = arr[j - 1];
                    --j;   
                }
                // Place currentNum in its correct position
                arr[j] = currentNum;
            } 
            
        }

        // -----------------------------------------------//
        // Selection Sort (generic, ascending/descending) //
        // -----------------------------------------------//
        public static void SelectionSort<T>(T[] arr, bool asc = true) where T : IComparable<T>
        {
            for(int i = arr.Length - 1; i > 0; --i)
            {
                int MinMaxIndex = 0;
                for(int j = 1; j <= i; ++j)
                {
                    // Find the min/max element in the unsorted portion
                    if(asc ? arr[j].CompareTo(arr[MinMaxIndex]) > 0 : arr[j].CompareTo(arr[MinMaxIndex]) < 0)
                    {
                        MinMaxIndex = j;
                    }
                }
                // Swap the found min/max with the last element in unsorted portion
                (arr[MinMaxIndex], arr[i]) = (arr[i],arr[MinMaxIndex]);
            }
        }

        // --------------------------------------------//
        // Bubble Sort (generic, ascending/descending) //
        // --------------------------------------------//
        public static void BubbleSort<T>(T[] arr, bool asc = true) where T : IComparable<T>
        {
            bool sorted = false;
            int pass = 1;
            // Continue passes until no swaps are made
            while(!sorted && (arr.Length - pass > 0))
            {
                sorted = true;
                // Compare adjacent elements and swap if needed
                for(int i = 0; i < arr.Length - pass; ++i)
                {
                    if(asc ? arr[i].CompareTo(arr[i + 1]) > 0 : arr[i].CompareTo(arr[i + 1]) < 0)
                    {
                        (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]);
                        sorted = false;
                    }
                }
                ++pass; // next pass ignores last sorted elements
            }
        }


        // ---------------------------------------------------------//
        // Counting Sort for int array (non-negative integers only) //
        // Stable, ascending / descending                           //
        // ---------------------------------------------------------//
        public static void CountingSortForInt(int[] arr, bool asc = true)
        {
            if (arr.Length == 0)
            { 
                return;
            }

            int maxValue = arr[0];
            foreach (int num in arr)
            {
                if (num > maxValue)
                { 
                    maxValue = num;
                }
            }

            int[] CountOfNumbers = new int[maxValue + 1];

            foreach (int num in arr)
            {
                CountOfNumbers[num]++;
            }

            // Build prefix sum array depending on ascending/descending
            if (asc)
            {
                for (int i = 1; i < CountOfNumbers.Length; i++)
                {
                    CountOfNumbers[i] += CountOfNumbers[i - 1];
                }
            }
            else
            {
                for (int i = CountOfNumbers.Length - 2; i >= 0; i--)
                {
                    CountOfNumbers[i] += CountOfNumbers[i + 1];
                }
            }

            int[] OutputArr = new int[arr.Length];

            // Build output array (loop backwards to ensure stability)
            for (int i = arr.Length - 1; i >= 0; i--)
            { 
                OutputArr[CountOfNumbers[arr[i]] - 1] = arr[i];
                CountOfNumbers[arr[i]]--;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = OutputArr[i];
            }
        }


        // --------------------------------//
        // Counting Sort for char array    //
        // Stable, ascending or descending //
        // --------------------------------//
        public static void CountingSortForChar(char[] arr, bool asc = true)
        {
            if (arr.Length == 0)
            { 
                return;
            }

            char maxChar = arr[0];
            foreach (char num in arr)
            {
                if (num > maxChar)
                { 
                    maxChar = num;
                }
            }

            int[] CountOfNumbers = new int[maxChar + 1];

            foreach (char num in arr)
            {
                CountOfNumbers[num]++;
            }

            if (asc)
            {
                for (int i = 1; i < CountOfNumbers.Length; i++)
                {
                    CountOfNumbers[i] += CountOfNumbers[i - 1];
                }
            }
            else
            {
                for (int i = CountOfNumbers.Length - 2; i >= 0; i--)
                {
                    CountOfNumbers[i] += CountOfNumbers[i + 1];
                }
            }

            char[] OutputArr = new char[arr.Length];
            for (int i = arr.Length - 1; i >= 0; i--)
            { 
                OutputArr[CountOfNumbers[arr[i]] - 1] = arr[i];
                CountOfNumbers[arr[i]]--;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = OutputArr[i];
            }
        }
    }
}