using Lofi.Prelude.Data.Instance.Identity.TypeConstructor;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Data.Instance.Identity.Type;

public interface IIdentity<out T>
    : ITypeConstructor<IIdentity, T>
{
    T Value { get; }
}