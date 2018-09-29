using System;

#if NET20 || NET35 || NETSTANDARD10 || NETCOREAPP10

namespace Cave.UnixTime
{
    /// <summary>
    /// Specifies that the attributed code should be excluded from code coverage information.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Event | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
    public sealed class ExcludeFromCodeCoverageAttribute : Attribute
    {
    }
}
#endif