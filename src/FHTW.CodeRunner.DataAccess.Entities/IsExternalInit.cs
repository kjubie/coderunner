using System;
using System.Collections.Generic;
using System.Text;

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// This class is required to be able to use the "init;" keyword when compiling against netstandard2.1.
    /// If the target frameork gets changed to net5.0 or higher in the future, this class can be removed.
    /// </summary>
    internal static class IsExternalInit
    {
    }
}
