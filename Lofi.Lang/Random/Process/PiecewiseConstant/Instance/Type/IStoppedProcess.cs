using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.TypeConstructor;
using Lofi.Lang.Random.Sequence.Instance.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;

public interface IStoppedProcess<out T> :
    IProcess<T>,
    ITypeConstructor<IStoppedProcess, T>
    where T : notnull
{
    IStoppingSequence StoppingSequence { get; }
}