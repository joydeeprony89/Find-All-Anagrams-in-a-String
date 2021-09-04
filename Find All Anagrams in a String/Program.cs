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
            var products = new int[] { 3, 2, 1, 5, 2, 1, 2, 1, 3, 4 };
            var candidate = new int[] { 1, 2, 3 };
            var anotherResult = FindAnagramsFromIntegerArray(products, candidate);
            Console.WriteLine(string.Join("-", anotherResult));
        }

        static IList<int> FindAnagrams(string s, string p)
        {
            IList<int> result = new List<int>();
            int[] hash = new int[256];
            foreach (char c in p)
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

        static IList<int> FindAnagramsFromIntegerArray(int[] product, int[] candidate)
        {
            Dictionary<int, int> hash = new Dictionary<int, int>();
            IList<int> result = new List<int>();
            foreach (int i in candidate)
                if (!hash.ContainsKey(i)) hash.Add(i, 1);
                else hash[i] += 1;

            int l = 0, r = 0, count = 0;
            while (r < product.Length)
            {
                if (hash.ContainsKey(product[r]) && hash[product[r]] > 0)
                {
                    hash[product[r]]--;
                    count++;
                    r++;
                }
                else
                {
                    if (!hash.ContainsKey(product[l]))
                    {
                        hash.Add(product[l], 1);
                    }
                    else
                    {
                        hash[product[l]]++;
                    }
                    count--;
                    l++;
                }
                if (count == candidate.Length) result.Add(l);
            }

            return result;
        }
    }
}
