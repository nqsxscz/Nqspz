using Lofi.Prelude.Data.Control.Instance.Identity.TypeConstructor;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Data.Control.Instance.Identity.Type;

public interface IIdentity<out T>
    : ITypeConstructor<IIdentity, T>
{
    T Value { get; }
}