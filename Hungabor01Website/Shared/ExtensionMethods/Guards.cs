using System;

namespace Shared.ExtensionMethods
{
    public static class Guards
    {
        public static void ThrowExceptionIfNull(this object obj, string parameterName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        public static void ThrowExceptionIfNullOrWhiteSpace(this string str, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException(parameterName);
            }
        }
    }
}
