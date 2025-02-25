using Lofi.Prelude.Data.Instance.Maybe.Type;

namespace Lofi.Prelude.Data.Instance.Maybe.Implementation;

internal sealed record Just<T>(T Value)
    : IJust<T>;