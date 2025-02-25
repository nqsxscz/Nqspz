using System.Diagnostics.CodeAnalysis;

namespace Lofi.Prelude.Type;

[SuppressMessage("ReSharper", "UnusedTypeParameter")]
public interface ITypeConstructor<TC, out T>
    where TC: notnull
    where T : notnull;