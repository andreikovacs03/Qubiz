using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qubiz_Algorithms_and_Data_Structures
{
    static partial class Arrays
    {
        static class Methods
        {
            public static int[] SelectionSort(int[] arr)
            {
                var resArr = arr.ToArray();

                for (int i = 0; i < resArr.Length - 1; i++)
                    for (int j = i + 1; j < resArr.Length; j++)
                        if (resArr[i] > resArr[j])
                            (resArr[i], resArr[j]) = (resArr[j], resArr[i]);

                return resArr;
            }

            public static int[] BubbleSort(int[] arr)
            {
                var resArr = arr.ToArray();

                bool ok = true;
                for (int i = 0; i < resArr.Length - 1 && ok; i++)
                {
                    ok = false;

                    for (int j = 0; j < resArr.Length - i - 1; j++)
                        if (resArr[j] > resArr[j + 1])
                        {
                            (resArr[j], resArr[j + 1]) = (resArr[j + 1], resArr[j]);
                            ok = true;
                        }
                }

                return resArr;
            }

            public static int[] Reverse(int[] arr)
            {
                var resArr = new int[arr.Length];

                for (int i = 0; i < arr.Length; i++)
                    resArr[resArr.Length - 1 - i] = arr[i];

                return resArr;
            }

            public static int[] Merge(int[] arr1, int[] arr2)
            {
                int[] resArr = new int[arr1.Length + arr2.Length];

                int i = 0, j = 0, k = 0;
                while (i < arr1.Length && j < arr2.Length)
                    if (arr1[i] < arr2[j])
                        resArr[k++] = arr1[i++];
                    else
                        resArr[k++] = arr2[j++];

                while (i < arr1.Length)
                    resArr[k++] = arr1[i++];

                while (j < arr2.Length)
                    resArr[k++] = arr2[j++];

                return resArr;
            }

            public static int[] SwapMinMax(int[] arr)
            {
                if (arr.Length < 2)
                    return arr;

                var resArr = arr.ToArray();
                int min, max, imin, imax;
                min = max = resArr[0];
                imin = imax = 0;

                for (int i = 0; i < resArr.Length; i++)
                    if (resArr[i] < min)
                    {
                        min = resArr[i];
                        imin = i;
                    }
                    else if (max < resArr[i])
                    {
                        max = resArr[i];
                        imax = i;
                    }

                (resArr[imin], resArr[imax]) = (resArr[imax], resArr[imin]);

                return resArr;
            }

            public static int FindMissing(int[] arr)
            {
                var freq = new int[101];

                foreach (var number in arr)
                    freq[number]++;

                for (int i = 1; i <= 100; i++)
                    if (freq[i] == 0)
                        return i;
                return -1;
            }
        }
    }
}
