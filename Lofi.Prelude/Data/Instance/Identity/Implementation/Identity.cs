using Lofi.Prelude.Data.Instance.Identity.Type;

namespace Lofi.Prelude.Data.Instance.Identity.Implementation;

internal sealed record Identity<T>(
    T Value)
    : IIdentity<T>;