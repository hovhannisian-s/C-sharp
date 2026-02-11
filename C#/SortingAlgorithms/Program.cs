using MyProject1;
using MyProject2;
class Program
{
    static void Main()
    {
        int[] arr = {5,22,3,84,-78,4,5,-69,-3};
        SortingAlgorithms.InsertionSort(arr,false);
        System.Console.WriteLine(string.Join(" ",arr));
        SortingAlgorithms.InsertionSort(arr,true);
        System.Console.WriteLine(string.Join(" ",arr));


        int[] arr2 = {4,2,61,-7,42,-5,94,-2};
        SortingAlgorithms.SelectionSort(arr2, false);
        System.Console.WriteLine(string.Join(" ", arr2));
        SortingAlgorithms.SelectionSort(arr2, true);
        System.Console.WriteLine(string.Join(" ", arr2));

        int[] arr3 = {3,1,5,4,2,5,8,6,4,8,5};
        SortingAlgorithms.CountingSortForInt(arr3,false);
        System.Console.WriteLine(string.Join(" ", arr3));
        SortingAlgorithms.CountingSortForInt(arr3,true);
        System.Console.WriteLine(string.Join(" ", arr3));

        char[] arr4 = {'c','f','q','z','v','k'};
        SortingAlgorithms.CountingSortForChar(arr4,false);
        System.Console.WriteLine(string.Join(" ", arr4));
        SortingAlgorithms.CountingSortForChar(arr4,true);
        System.Console.WriteLine(string.Join(" ", arr4));

        int[] arr5 = {-75,45,14,2,-6,-14,-8,4,1,5,-8};
        SortingAlgorithms.SelectionSort(arr5, false);
        System.Console.WriteLine(string.Join(" ", arr5));
        SortingAlgorithms.SelectionSort(arr5, true);
        System.Console.WriteLine(string.Join(" ", arr5));

        int[] arr6 = {2,15,-85,7,321,458,-741,65};
        FastSortingAlgorithms.MergeSort(arr6, false);
        System.Console.WriteLine(string.Join(" ", arr6));


        double[] arr7 = {22,15.6,22,4,-45,0.5,-12.2};
        FastSortingAlgorithms.QuickSort(arr7);
        System.Console.WriteLine(string.Join(" ", arr7));


    }

}