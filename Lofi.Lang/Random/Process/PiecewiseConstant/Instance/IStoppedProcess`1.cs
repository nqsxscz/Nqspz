using Lofi.Lang.Random.Process.Continuous.Instance;
using Lofi.Lang.Random.Sequence.Instance;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant.Instance;

public interface IStoppedProcess<out T> :
    IProcess<T>,
    ITypeConstructor<IStoppedProcess, T>
    where T : notnull
{
    IStoppingSequence StoppingSequence { get; }
}