using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qubiz_Algorithms_and_Data_Structures
{
    static partial class LinkedLists
    {
        static class Methods
        {
            public static LinkedList<int> Reverse(LinkedList<int> list)
            {
                var resList = new LinkedList<int>();

                foreach (var number in list)
                    resList.AddFirst(number);

                return resList;
            }

            public static LinkedList<int> Merge(LinkedList<int> list1, LinkedList<int> list2)
            {
                var resList = new LinkedList<int>();

                var head1 = list1.First;
                var head2 = list2.First;

                while (list1.Count > 0 && list2.Count > 0)
                    if (head1.Value < head2.Value)
                    {
                        resList.AddLast(head1.Value);
                        head1 = head1.Next;
                        list1.RemoveFirst();
                    }
                    else
                    {
                        resList.AddLast(head2.Value);
                        head2 = head2.Next;
                        list2.RemoveFirst();
                    }

                while (list1.Count > 0)
                {
                    resList.AddLast(head1.Value);
                    head1 = head1.Next;
                    list1.RemoveFirst();
                }

                while (list2.Count > 0)
                {
                    resList.AddLast(head2.Value);
                    head2 = head2.Next;
                    list2.RemoveFirst();
                }

                return resList;
            }

            public static LinkedList<int> RemoveDuplicates(LinkedList<int> list)
            {
                var resList = new LinkedList<int>();

                int previousNumber = list.First.Value;
                resList.AddLast(previousNumber);

                foreach (var number in list)
                    if (number != previousNumber)
                    {
                        previousNumber = number;
                        resList.AddLast(number);
                    }

                return resList;
            }
        }
    }
}
