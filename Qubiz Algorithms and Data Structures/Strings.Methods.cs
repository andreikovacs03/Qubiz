using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qubiz_Algorithms_and_Data_Structures
{
    static partial class Strings
    {
        static class Methods
        {
            public static bool Anagrams(string a, string b)
            {

                if (a.Length != b.Length)
                    return false;

                var dictA = new Dictionary<char, int>();
                var dictB = new Dictionary<char, int>();

                foreach (var letter in a)
                    if (dictA.ContainsKey(letter))
                        dictA[letter]++;
                    else
                        dictA.Add(letter, 1);

                foreach (var letter in b)
                    if (dictB.ContainsKey(letter))
                        dictB[letter]++;
                    else
                        dictB.Add(letter, 1);

                foreach (var letter in dictA.Keys)
                    if (!(dictB.ContainsKey(letter) && dictB[letter] == dictA[letter]))
                        return false;

                return true;
            }

            public static string Reverse(string str)
            {
                string result = "";

                foreach (var letter in str)
                    result = letter + result;

                return result;
            }

            public static string Reverse_Recursive(string str)
            {
                if (str.Length > 0)
                    return Reverse_Recursive(str.Remove(0, 1)) + str[0];
                   //return str[str.Length - 1] + Reverse_Recursive(str.Remove(str.Length - 1, 1));
                return "";
            }

            public static bool Palindrome(string str) => str == Reverse(str);

            public static bool PalindromeOnHalf(string str)
            {
                for (int i = 0; i < str.Length / 2; i++)
                    if (str[i] != str[str.Length - 1 - i])
                        return false;
                return true;
            }

            public static string OccurrenceMax(string sentence)
            {
                var dict = new Dictionary<string, int>();

                var sentenceList = sentence.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);

                if (sentenceList.Length == 0)
                    return "";

                string result = sentenceList[0];
                int maxOccurrence = 1;

                foreach (var word in sentenceList)
                    if (dict.ContainsKey(word))
                    {
                        dict[word]++;
                        if (dict[word] > maxOccurrence)
                        {
                            maxOccurrence = dict[word];
                            result = word;
                        }
                    }
                    else
                        dict.Add(word, 1);

                return result;
            }
        }
    }
}
