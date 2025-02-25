using Lofi.Lang.Model.Random.Process.Instance.Type;
using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Lang.Model.Random.Process;

public static partial class StochasticProcess
{
    public static IStochasticProcess<TimeSpan> Differentiate(
        this IStochasticProcess<DateTime> operand)
        => throw new NotImplementedException();
    
    public static IStochasticProcess<T> Differentiate<T>(
        this IStochasticProcess<T> operand)
        where T : IAdditiveGroup<T>
        => throw new NotImplementedException();
}