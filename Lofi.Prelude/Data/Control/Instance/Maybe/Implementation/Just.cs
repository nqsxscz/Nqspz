using Lofi.Prelude.Data.Control.Instance.Maybe.Type;

namespace Lofi.Prelude.Data.Control.Instance.Maybe.Implementation;

internal sealed record Just<T>(T Value)
    : IJust<T>;