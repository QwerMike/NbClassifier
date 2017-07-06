using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbClassifier.Model
{
    public static class DocumentHelper
    {
        public static string[] ExtractWordsFromDocument(string document)
        {
            string cleared = new string(
                    (from c in document
                     where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
                     select c).ToArray());

            return cleared.Split(' ');
        }

        public static int MaxElementIndex<T>(this IEnumerable<T> sequence)
            where T : IComparable<T>
        {
            int maxIndex = -1;
            T maxValue = default(T);

            int index = 0;
            foreach (T value in sequence)
            {
                if (value.CompareTo(maxValue) > 0 || maxIndex == -1)
                {
                    maxIndex = index;
                    maxValue = value;
                }
                index++;
            }

            return maxIndex;
        }
    }
}