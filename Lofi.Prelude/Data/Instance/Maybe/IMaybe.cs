using Lofi.Prelude.Data.Instance.Maybe.TypeConstructor;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Data.Instance.Maybe;

/// <summary>
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IMaybe<out T>
    : ITypeConstructor<IMaybe, T>
    where T : notnull;