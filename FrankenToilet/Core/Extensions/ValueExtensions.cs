using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace FrankenToilet.Core.Extensions;

[PublicAPI]
public static class ValueExtensions
{
    extension<T>(T source) where T : struct
    {
        [PublicAPI]
        public T? AsNullable() => source;
        [PublicAPI]
        public StrongBox<T> Box() => new(source);
    }
}