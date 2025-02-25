using Lofi.Prelude.Data.Instance.Maybe.Type;

namespace Lofi.Prelude.Data.Instance.Maybe.Implementation;

internal sealed record Nothing<T>
    : INothing<T>
    where T : notnull;