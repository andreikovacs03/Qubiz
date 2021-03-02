using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qubiz_Algorithms_and_Data_Structures
{
    static partial class Numbers
    {
        public static void Problem1()
        {
            uint n = 5;

            uint fact = Methods.Factorial_Recursive_Short(n);
            Console.WriteLine($"Factorial Recursive (short): {fact}");

            fact = Methods.Factorial_Recursive(n);
            Console.WriteLine($"Factorial Recursive: {fact}");

            fact = Methods.Factorial_Iterative(n);
            Console.WriteLine($"Factorial Iterative: {fact}");
        }

        public static void Problem2()
        {
            int a = 10, b = 5;
            Console.WriteLine($"Initial values: {a}, {b}");

            Methods.Swap_Tuple(ref a, ref b);
            Console.WriteLine($"Swap Tuple: {a}, {b}");

            Methods.Swap_Tuple(ref a, ref b);
            Console.WriteLine($"Swap Sum: {a}, {b}");
        }

        public static void Problem3()
        {
            uint n = 5;

            uint fib = Methods.Fibonacci_Iterative(n);
            Console.WriteLine($"Fibonacci iterative of {n} is: {fib}");

            fib = Methods.Fibonacci_Recursive(n);
            Console.WriteLine($"Fibonacci recursive of {n} is: {fib}");

        }

        public static void Problem4()
        {
            int n = 1001;
            bool palindrome = Methods.Palindrome(n);
            Console.WriteLine($"{n} is palindrome ? {palindrome}");
        }

        public static void Problem5()
        {
            uint a = 15, b = 45;

            uint gcd = Methods.GCD(a, b);
            Console.WriteLine($"Greatest common divisor of {a} and {b} is: {gcd}");

            uint lcm = Methods.LCM(a, b);
            Console.WriteLine($"Least common multiple of {a} and {b} is: {lcm}");
        }
    }
}
