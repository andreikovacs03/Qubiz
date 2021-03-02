using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qubiz_Algorithms_and_Data_Structures
{
    static partial class Strings
    {

        public static void Problem1()
        {
            string a = "abcd";
            string b = "dcba";

            bool anagrams = Methods.Anagrams(a, b);

            Console.WriteLine($"'{a}' and '{b}' are anagrams? {anagrams}");
        }

        public static void Problem2()
        {
            string str = "reverse me";

            Console.WriteLine($"Initial string: '{str}'");

            str = Methods.Reverse(str);
            Console.WriteLine($"Foreach reverse: '{str}'");

            str = Methods.Reverse_Recursive(str);
            Console.WriteLine($"Recursive reverse: '{str}'");
        }

        public static void Problem3()
        {
            string str = "radar";

            bool palindrom = Methods.Palindrome(str);
            Console.WriteLine($"'{str}' is a palindrome (reverse)? {palindrom}");

            palindrom = Methods.PalindromeOnHalf(str);
            Console.WriteLine($"'{str}' is a palindrome? {palindrom}");
        }

        public static void Problem4()
        {
            string sentence = "I am occurring occurring";

            string word = Methods.OccurrenceMax(sentence);

            Console.WriteLine($"Highest occurring word in '{sentence}' is: '{word}'");
        }
    }
}
