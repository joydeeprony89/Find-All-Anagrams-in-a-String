using System;
using System.Collections.Generic;

namespace Find_All_Anagrams_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = FindAnagrams("cbaebabacd", "abc");
            Console.WriteLine(string.Join("-", result));
        }

        static IList<int> FindAnagrams(string s, string p)
        {
            IList<int> result = new List<int>();
            int[] hash = new int[256];
            foreach (char c in p.ToCharArray())
                hash[(int)c]++;

            int left = 0;
            int right = 0;
            int count = 0;
            while(right < s.Length)
            {
                if(hash[(int)s[right]] > 0)
                {
                    hash[(int)s[right]]--;
                    count++;
                    right++;
                }
                else
                {
                    hash[(int)s[left]]++;
                    count--;
                    left++;
                }

                if(count == p.Length) result.Add(left);
            }
            return result;
        }
    }
}
