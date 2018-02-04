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
    }
}
