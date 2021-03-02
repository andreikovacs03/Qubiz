using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qubiz_Algorithms_and_Data_Structures
{
    partial class Numbers
    {
        static class Methods
        {
            public static uint Factorial_Recursive_Short(uint n) => n * (n > 1 ? Factorial_Recursive_Short(n - 1) : 1);

            public static uint Factorial_Recursive(uint n)
            {
                if (n > 1)
                    return n * Factorial_Recursive(n - 1);
                return 1;
            }

            public static uint Factorial_Iterative(uint n)
            {
                uint result = 1;

                for (uint i = 2; i <= n; i++)
                    result *= i;

                return result;
            }

            public static uint Fibonacci_Iterative(uint n)
            {
                uint x = 1, y = 1;

                for (int i = 2; i <= n; i++)
                    (x, y) = (y, x + y);

                return y;
            }

            public static uint Fibonacci_Recursive(uint n)
            {
                if (n >= 2)
                    return Fibonacci_Recursive(n-1) + Fibonacci_Iterative(n-2);
                return 1;
            }

            public static bool Palindrome(int n)
            {
                int aux = n;
                int mirror = 0;

                for (; aux > 0; aux /= 10)
                    mirror = mirror * 10 + aux % 10;

                return mirror == n;
            }


            public static void Swap_Tuple(ref int a, ref int b)
            {
                (a, b) = (b, a);
            }

            public static void Swap_Sum(ref int a, ref int b)
            {
                a += b;
                b = a - b;
                a = a - b;
            }

            public static uint GCD(uint a, uint b)
            {
                while (b != 0)
                {
                    uint remainder = a % b;
                    a = b;
                    b = remainder;
                }

                return a;
            }

            public static uint LCM(uint a, uint b) => (a * b) / GCD(a, b);
        }
    }
}
