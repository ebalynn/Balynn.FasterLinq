using System;
using FasterLinq.Resources;

namespace FasterLinq
{
    internal static class Error
    {
        internal static ArgumentNullException ArgumentNull(string name)
        {
            return new ArgumentNullException(name);
        }

        internal static InvalidOperationException NoElements()
        {
            return new InvalidOperationException(SR.NoElements);
        }

        internal static InvalidOperationException NoMatch()
        {
            return new InvalidOperationException(SR.NoMatch);
        }
    }
}
