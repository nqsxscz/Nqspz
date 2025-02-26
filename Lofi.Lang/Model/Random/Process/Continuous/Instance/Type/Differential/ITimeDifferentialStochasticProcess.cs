using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Differential;

public interface ITimeDifferentialStochasticProcess<out T>
    : IDifferentialStochasticProcess<T>
    where T : IAdditiveGroup<T>
{
    IStochasticProcess<DateTime> Operand { get; }
    
    Func<TimeSpan, T> Converter { get; }
}