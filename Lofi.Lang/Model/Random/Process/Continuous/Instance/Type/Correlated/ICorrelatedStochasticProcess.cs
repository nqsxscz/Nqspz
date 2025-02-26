using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Correlated;

public interface ICorrelatedStochasticProcess<out T>
    : IStochasticProcess<T>
    where T : IReal<T>
{
    IStochasticProcess<T> Operand { get; }
    
    T Correlation { get; }
}