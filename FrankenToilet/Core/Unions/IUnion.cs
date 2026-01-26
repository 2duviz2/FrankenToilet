using System;
using JetBrains.Annotations;

namespace FrankenToilet.Core.Unions;
/// <summary>
///    Represents a union type that can hold one of several possible types.
/// </summary>
[PublicAPI]
public interface IUnion
{
    /// <summary>
    ///     The raw object stored in the union.
    /// </summary>
    object RawObj { get; }
    /// <summary>
    ///     Gets the possible types that this union can represent.
    /// </summary>
    Type[] GetPossibleTypes();
}