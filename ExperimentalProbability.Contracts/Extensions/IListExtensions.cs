using System.Collections;

namespace ExperimentalProbability.Contracts.Extensions
{
    public static class IListExtensions
    {
        public static void RewriteOrAddItem(this IList collection, int position, object item)
        {
            if (collection.Count >= position + 1)
            {
                collection[position] = item;
            }
            else
            {
                collection.Add(item);
            }
        }

        public static void TryAddAndRemove(this IList collection, object itemToAdd, object itemToRemove)
        {
            if (itemToAdd != null)
            {
                collection.Add(itemToAdd);
            }

            collection.Remove(itemToRemove);
        }
    }
}
