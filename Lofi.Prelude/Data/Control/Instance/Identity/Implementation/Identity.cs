using Lofi.Prelude.Data.Control.Instance.Identity.Type;

namespace Lofi.Prelude.Data.Control.Instance.Identity.Implementation;

internal sealed record Identity<T>(
    T Value)
    : IIdentity<T>;