using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.src
{
    public static  class EnumerableExtensions
    {
        public static IEnumerable<T> Page<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be >= 1.");
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be >= 1.");

            
            int skip = (pageNumber - 1) * pageSize;
            int taken = 0;
            int index = 0;

            foreach (var item in source)
            {
                if (index < skip)
                {
                    index++;
                    continue;              
                }

                if (taken >= pageSize)
                    yield break;           

                yield return item;
                taken++;
                index++;
            }
           
        }

        public static T? FindById<T>(this IEnumerable<T> source, int id) where T : IHasId
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            foreach (var item in source)
            {
                if (item.Id == id)
                    return item;
            }

            return default;
        }

        public static IReadOnlyDictionary<int,T> ToDictionaryById<T>(this IEnumerable<T> source) where T : IHasId
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var dictionary = new Dictionary<int, T>();
            foreach (var item in source)
            {
                if (!dictionary.ContainsKey(item.Id))
                {
                    dictionary.Add(item.Id, item);
                }
                else
                {
                    throw new ArgumentException($"An item with Id {item.Id} already exists in the dictionary.");
                }
            }
            return dictionary;
        }
    }
}
