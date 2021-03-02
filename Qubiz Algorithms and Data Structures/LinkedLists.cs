using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qubiz_Algorithms_and_Data_Structures
{
    static partial class LinkedLists
    {
        public static void Problem1()
        {
            var list = new LinkedList<int>(new[] { 1, 2, 3, 4, 5 });

            Console.WriteLine($"Initial list: {string.Join(" ", list)}");

            list = Methods.Reverse(list);
            Console.WriteLine($"Reversed list: {string.Join(" ", list)}");
        }

        public static void Problem2()
        {
            var list1 = new LinkedList<int>();
            var list2 = new LinkedList<int>();

            list2.AddLast(1);

            for (int i = 1; i <= 7; i++)
                if (i % 2 == 0)
                    list1.AddLast(i);
                else
                    list2.AddLast(i);
            
            Console.WriteLine($"list1: {string.Join(" ", list1)}");
            Console.WriteLine($"list2: {string.Join(" ", list2)}");

            var mergedList = Methods.Merge(list1, list2);
            Console.WriteLine($"Merged lists: {string.Join(" ", mergedList)}");
        }

        public static void Problem3()
        {
            var list = new LinkedList<int>();
            for (int i = 1; i <= 4; i++)
            {
                list.AddLast(i);
                list.AddLast(i);
            }

            Console.WriteLine($"Initial list: {string.Join(" ", list)}");

            list = Methods.RemoveDuplicates(list);
            Console.WriteLine($"Removed duplicates in list: {string.Join(" ", list)}");
        }

    }
}
