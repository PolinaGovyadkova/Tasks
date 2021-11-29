using System.Collections.Generic;
using System.Linq;

namespace Parser
{
    public static class ElementSkiper
    {
        public static IEnumerable<TSource> SkipLast<TSource>(this IEnumerable<TSource> source, int count)
        {
            var array = source.ToArray();

            for (var i = count; i < array.Length; i++)
            {
                yield return array[i];
            }
        }
    }
}