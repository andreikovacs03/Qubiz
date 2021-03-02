using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qubiz_Algorithms_and_Data_Structures
{
    static partial class Arrays
    {
        public static void Problem1()
        {
            int[] arr = { 5, 4, 3, 2, 1 };

            var arrCopy = arr.ToArray();

            Console.WriteLine($"Initial array: {string.Join(" ", arr)}");

            arr = Methods.SelectionSort(arr);
            Console.WriteLine($"After selection sort: {string.Join(" ", arr)}");

            arrCopy = Methods.BubbleSort(arrCopy);
            Console.WriteLine($"After bubble sort: {string.Join(" ", arrCopy)}");
        }

        public static void Problem2()
        {
            int[] arr = { 5, 4, 3, 2, 1 };

            Console.WriteLine($"Initial array: {string.Join(" ", arr)}");

            arr = Methods.Reverse(arr);
            Console.WriteLine($"After reversion: {string.Join(" ", arr)}");
        }

        public static void Problem3()
        {
            int[] arr1 = { 1, 3, 5, 7 };
            int[] arr2 = { 0, 2, 4, 6 };

            Console.WriteLine($"Array1: {string.Join(" ", arr1)}");
            Console.WriteLine($"Array2: {string.Join(" ", arr2)}");

            var mergedArr = Methods.Merge(arr1, arr2);
            Console.WriteLine($"Merged array: {string.Join(" ", mergedArr)}");
        }

        public static void Problem4()
        {
            var arr = new int[99];
            int missing= 7;

            for (int i = 0, k = 1; i < arr.Length; i++)
            {
                if (k == missing)
                    k++;
                arr[i] = k++;
            }

            Console.WriteLine($"Missing number from initial array is: {missing}");

            int found = Methods.FindMissing(arr);
            Console.WriteLine($"Found missing number is: {found}");
        }

        public static void Problem5()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            Console.WriteLine($"Initial array: {string.Join(" ", arr)}");

            arr = Methods.SwapMinMax(arr);

            Console.WriteLine($"New array with min and max element sawpped: {string.Join(" ", arr)}");
        }
    }
}
