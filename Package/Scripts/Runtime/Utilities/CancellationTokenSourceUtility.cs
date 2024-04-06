using System;
using System.Threading;

namespace Tequila.Utilities
{
    public static class CancellationTokenSourceUtility
    {
        public static bool TryCancel(CancellationTokenSource cancellationTokenSource, Action<Exception> onException = default)
        {
            return TryCancel(cancellationTokenSource, false, onException);
        }

        public static bool TryCancel(CancellationTokenSource cancellationTokenSource, bool throwOnFirstException, Action<Exception> onException = default)
        {
            if (cancellationTokenSource == null)
            {
                return false;
            }

            try
            {
                cancellationTokenSource.Cancel(throwOnFirstException);

                return true;
            }
            catch (Exception exception)
            {
                onException?.Invoke(exception);

                return false;
            }
        }

        public static bool TryGetCancellationToken(CancellationTokenSource cancellationTokenSource, out CancellationToken cancellationToken)
        {
            if (cancellationTokenSource == null)
            {
                return false;
            }

            if (cancellationTokenSource.IsCancellationRequested)
            {
                return false;
            }

            cancellationToken = cancellationTokenSource.Token;

            return true;
        }
    }
}
