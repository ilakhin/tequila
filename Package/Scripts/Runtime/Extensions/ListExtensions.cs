using System;
using System.Collections.Generic;

namespace Tequila.Extensions
{
    public static class ListExtensions
    {
        public static bool TryRemoveAt<T>(this IList<T> list, int index, out T item, Action<Exception> onException = default)
        {
            try
            {
                item = list[index];
                list.RemoveAt(index);

                return true;
            }
            catch (Exception exception)
            {
                onException?.Invoke(exception);
                item = default;

                return false;
            }
        }
    }
}
