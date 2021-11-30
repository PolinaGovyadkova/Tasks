using System.Collections.Generic;
using System.Linq;

namespace Parser.Helper
{
    /// <summary>
    /// ElementSkiper
    /// </summary>
    public static class ElementSkiper
    {
        /// <summary>
        /// Skips the last.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
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