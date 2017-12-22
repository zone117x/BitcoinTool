using System;
using System.Collections.Generic;
using Java.Util;

namespace BitcoinKeyGen.Utils
{
    public static class JavaObjectSharpify
    {
        public static IEnumerable<string> ToStringArray(this IEnumeration enumeration)
        {
            while (enumeration.HasMoreElements)
            {
                yield return enumeration.NextElement().ToString();
            }
        }
    }
}
