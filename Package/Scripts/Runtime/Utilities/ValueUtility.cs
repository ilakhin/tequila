using System;
using System.Collections.Generic;

namespace Tequila.Utilities
{
    public static class ValueUtility
    {
        public static bool TrySetReference<T>(ref T sourceValue, T targetValue)
            where T : class
        {
            var equalsResult = Equals(sourceValue, targetValue);

            if (equalsResult)
            {
                return false;
            }

            sourceValue = targetValue;

            return true;
        }

        public static bool TrySetSingle(ref float sourceValue, float targetValue)
        {
            var approximatelyResult = MathF.Abs(targetValue - sourceValue) < MathF.Max(0.000001f * MathF.Max(MathF.Abs(sourceValue), MathF.Abs(targetValue)), MathF.E * 8);

            if (approximatelyResult)
            {
                return false;
            }

            sourceValue = targetValue;

            return true;
        }

        public static bool TrySetString(ref string sourceValue, string targetValue)
        {
            return TrySetString(ref sourceValue, targetValue, StringComparer.Ordinal);
        }

        public static bool TrySetString(ref string sourceValue, string targetValue, IEqualityComparer<string> comparer)
        {
            return TrySetValue(ref sourceValue, targetValue, comparer);
        }

        public static bool TrySetValue<T>(ref T sourceValue, T targetValue)
        {
            return TrySetValue(ref sourceValue, targetValue, EqualityComparer<T>.Default);
        }

        public static bool TrySetValue<T>(ref T sourceValue, T targetValue, IEqualityComparer<T> comparer)
        {
            var equalsResult = comparer.Equals(sourceValue, targetValue);

            if (equalsResult)
            {
                return false;
            }

            sourceValue = targetValue;

            return true;
        }
    }
}
