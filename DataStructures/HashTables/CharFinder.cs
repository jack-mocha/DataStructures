using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.HashTables
{
    public class CharFinder
    {
        public char FirstNonRepeatedChar(string content)
        {
            var repeated = new Dictionary<char, int>(); //int stores how many times the char is repeated
            var nonRepeated = new Dictionary<char, int>(); //int stores the index of the char

            for(int i = 0; i < content.Length; i++)
            {
                char c = content[i];
                if (repeated.ContainsKey(c))
                    repeated[c] = repeated[c] + 1;

                if(nonRepeated.ContainsKey(c))
                {
                    repeated.Add(c, 2);
                    nonRepeated.Remove(c);
                }
                else
                    nonRepeated.Add(c, i);
            }

            var max = Int32.MaxValue;
            char res = '\0';
            foreach(var n in nonRepeated) //find the lowest index
            {
                if (n.Value < max)
                {
                    res = n.Key;
                    max = n.Value;
                }
            }

            return res;
        }

        /// <summary>
        /// First iteration of the string: record how many times a char is repeated
        /// Second iteration of the string: find the first char that has count of one
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public char CleanerFirstNonRepeatedChar(string content)
        {
            var dic = new Dictionary<char, int>();
            foreach(var c in content)
            {
                if (dic.ContainsKey(c))
                    dic[c] = dic[c] + 1;
                else
                    dic.Add(c, 1);
            }

            foreach(var c in content)
            {
                if (dic[c] == 1)
                    return c;
            }

            return Char.MinValue;
        }
    }
}
