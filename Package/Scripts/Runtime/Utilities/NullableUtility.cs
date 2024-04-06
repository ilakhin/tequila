using System.Collections.Generic;

namespace Tequila.Utilities
{
    public static class NullableUtility
    {
        public static bool TryGetValue<T>(T? nullable, out T value)
            where T : struct
        {
            if (nullable.HasValue)
            {
                value = nullable.Value;

                return true;
            }

            value = default;

            return false;
        }

        public static bool TrySetValue<T>(ref T? nullable, T value)
            where T : struct
        {
            return TrySetValue(ref nullable, value, EqualityComparer<T>.Default);
        }

        public static bool TrySetValue<T>(ref T? nullable, T value, IEqualityComparer<T> comparer)
            where T : struct
        {
            if (nullable.HasValue)
            {
                var result = comparer.Equals(nullable.Value, value);

                if (result)
                {
                    return false;
                }
            }

            nullable = value;

            return true;
        }

        public static bool TrySetValueOnce<T>(ref T? nullable, T value)
            where T : struct
        {
            if (nullable.HasValue)
            {
                return false;
            }

            nullable = value;

            return true;
        }
    }
}
