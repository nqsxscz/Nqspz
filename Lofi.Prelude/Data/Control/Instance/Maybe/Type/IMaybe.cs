using Lofi.Prelude.Data.Control.Instance.Maybe.TypeConstructor;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Data.Control.Instance.Maybe.Type;

public interface IMaybe<out T>
    : ITypeConstructor<IMaybe, T>
    where T : notnull;