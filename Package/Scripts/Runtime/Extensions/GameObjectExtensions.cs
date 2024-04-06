using System;
using UnityEngine;

namespace Tequila.Extensions
{
    public static class GameObjectExtensions
    {
        public static bool TryGetComponentInParent<T>(this GameObject gameObject, out T component, Action<Exception> onException = default)
        {
            try
            {
                component = gameObject.GetComponentInParent<T>();

                return component != null;
            }
            catch (Exception exception)
            {
                onException?.Invoke(exception);
                component = default;

                return false;
            }
        }
    }
}
