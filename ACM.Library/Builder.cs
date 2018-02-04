using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACM.Library
{
    public class Builder
    {
        /// <summary>
        /// Build and return sequance of int numbers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> BuildIntSequance()
        {
            return Enumerable.Range(0, 10);
        }

        /// <summary>
        /// Build and return repeatable sequance of int numbers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> BuildRepeatbleIntSequance()
        {
            return Enumerable.Repeat(1, 10);
        }

        /// <summary>
        /// Build and return sequance of chars
        /// </summary>
        /// <returns></returns>
        public IEnumerable<char> BuildCharSequance()
        {
            return Enumerable.Range(0, 10).Select((i) => (char)('A' + i));
        }

        /// <summary>
        /// Combine two sequances
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> CompareSequences()
        {
            var seq1 = Enumerable.Range(0, 10);
            var seq2 = Enumerable.Range(0, 10).Select((i) => i*i);

            //return seq1.Intersect(seq2);
            //return seq1.Except(seq2);
            //return seq1.Concat(seq2);
            //return seq1.Concat(seq2).Distinct();
            return seq1.Union(seq2);
        }
    }
}
