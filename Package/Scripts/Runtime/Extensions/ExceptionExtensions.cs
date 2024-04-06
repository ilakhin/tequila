using System;
using System.Collections.Generic;

namespace Tequila.Extensions
{
    public static class ExceptionExtensions
    {
        public static IEnumerable<Exception> GetInnerExceptions(this Exception exception)
        {
            for (var innerException = exception.InnerException; innerException != null; innerException = innerException.InnerException)
            {
                yield return innerException;
            }
        }
    }
}
