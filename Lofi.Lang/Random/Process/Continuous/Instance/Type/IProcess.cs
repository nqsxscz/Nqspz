using Lofi.Lang.Random.Process.Continuous.Instance.TypeConstructor;
using Lofi.Lang.Random.Process.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance.Type;

public interface IProcess<out T>
    : ITypeConstructor<IProcess, T>
    where T : notnull
{
    ITypeConstructor<TC, T> Accept<TC>(
        IProcessVisitor<TC> visitor)
        where TC : notnull;
}