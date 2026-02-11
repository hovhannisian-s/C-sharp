namespace MyProject2
{
    public static class FastSortingAlgorithms
    {
        // --------------------------------------------//
        // Merge Sort (generic, ascending/descending)  //
        // --------------------------------------------//
        public static void MergeSort<T>(T[] arr, bool asc = true) where T : IComparable<T>
        {
            MergeSortAlg(arr, 0, arr.Length - 1, asc);
        }
        private static void MergeSortAlg<T>(T[] arr, int first, int last, bool asc) where T : IComparable<T>
        {
            if(first < last)
            {
                // Calculate middle index safely to avoid overflow
                int mid = first + (last - first) / 2; 


                MergeSortAlg(arr, first, mid, asc);
                MergeSortAlg(arr, mid + 1, last, asc);

                // Merge two sorted halves
                Merge(arr, first, mid, last, asc);
            }
        }

        private static void Merge<T>(T[] arr, int first, int mid, int last, bool asc) where T : IComparable<T>
        {
            T[] tempArr = new T[arr.Length];

            int first1 = first;
            int last1 = mid;

            int first2 = mid + 1;
            int last2 = last;

            int tempIndex = first;

            // Compare elements from both halves and copy smaller/larger (based on asc)
            while((first1 <= last1) && (first2 <= last2))
            {
                int cmp = arr[first1].CompareTo(arr[first2]);
                bool takeFirst = asc ? cmp <= 0 : cmp > 0;
                tempArr[tempIndex++] = takeFirst ? arr[first1++] : arr[first2++];
            }


            // Copy remaining elements from first and second half (if any)

            while(first1 <= last1)
            {
                tempArr[tempIndex++] = arr[first1++];
            }

            while(first2 <= last2)
            {
                tempArr[tempIndex++] = arr[first2++];
            }

            // Copy merged result back into original array
            for(int i = first; i <= last; ++i)
            {
                arr[i] = tempArr[i];
            }
        }



        // --------------------------------------------//
        // Quick Sort (generic, ascending/descending)  //
        // --------------------------------------------//
        public static void QuickSort<T>(T[] arr, bool asc = true) where T : IComparable<T>
        {
            QuickSortAlg(arr, 0, arr.Length - 1, asc);
        }

        private static void QuickSortAlg<T>(T[] arr, int first, int last, bool asc) where T : IComparable<T>
        {
            if(first < last)
            {
                // Partition array and get final pivot position
                int pivotIndex = PartitionRandom(arr, first, last, asc);

                // Recursively sort left and right sides of pivot
                QuickSortAlg(arr, first, pivotIndex - 1, asc);
                QuickSortAlg(arr, pivotIndex + 1, last, asc);
            }
        }

        private static int PartitionRandom<T>(T[] arr, int first, int last, bool asc) where T : IComparable<T>
        {
            int pivotIndex = RandomPivot(first, last);
            (arr[pivotIndex], arr[last]) = (arr[last], arr[pivotIndex]);
            T pivot = arr[last];
            int left = first;
            int right = last - 1;

            bool done = false;
            while(!done)
            {

                // Move left pointer while elements are in correct order
                while (left <= right && (asc ? arr[left].CompareTo(pivot) < 0 : arr[left].CompareTo(pivot) > 0))
                {
                    ++left;
                }

                // Move right pointer while elements are in correct order
                while (left <= right && (asc ? arr[right].CompareTo(pivot) > 0 : arr[right].CompareTo(pivot) < 0))
                {
                    --right;
                }


                // Swap elements if pointers haven't crossed
                if (left < right)
                { 
                    (arr[left], arr[right]) = (arr[right], arr[left]);
                    ++left;
                    --right;
                }
                else
                {
                    done = true;
                }
            }

            // Place pivot into its final sorted position
            (arr[left], arr[last]) = (arr[last], arr[left]);
            return left;
        }

        private static int RandomPivot(int first, int last)
        {
            return Random.Shared.Next(first, last + 1);
        }
    }
}