using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.TypeConstructor;
using Lofi.Lang.Random.Sequence.Instance.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;

public interface IPiecewiseConstantContinuousProcess<out T> :
    IContinuousProcess<T>,
    ITypeConstructor<IPiecewiseConstantProcess, T>
    where T : notnull
{
    IStoppingSequence StoppingSequence { get; }
}