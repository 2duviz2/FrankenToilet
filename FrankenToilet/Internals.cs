using System;
using Microsoft.CodeAnalysis;

// ReSharper disable CheckNamespace
// ReSharper disable UnusedType.Global
namespace System.Runtime.CompilerServices
{
    /// <summary>
    ///     Attribute to enable 'init' accessors in records and init-only properties. Don't use it directly.
    /// </summary>
    [Embedded]
    internal static class IsExternalInit;
}

namespace Microsoft.CodeAnalysis
{
    /// <summary>
    ///     Undocumented attribute that Zombie told me about. Don't use it unless you know what you're doing.
    /// </summary>
    [Embedded]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Delegate | AttributeTargets.Enum |
                    AttributeTargets.Interface | AttributeTargets.Struct)]
    internal sealed class EmbeddedAttribute : Attribute;
}