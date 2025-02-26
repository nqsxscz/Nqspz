using Lofi.Lang.Model.Random.Process.Continuous.Instance.Implementation.Differential;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Differential;
using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Lang.Model.Random.Process.Continuous;

public static partial class StochasticProcess
{
    public static IDifferentialStochasticProcess<T> Differentiate<T>(
        this IStochasticProcess<DateTime> operand,
        Func<TimeSpan, T> converter)
        where T : IAdditiveGroup<T>
        => new TimeDifferentialStochasticProcess<T>(
            operand, 
            converter);
    
    public static IDifferentialStochasticProcess<T> Differentiate<T>(
        this IStochasticProcess<T> operand)
        where T : IAdditiveGroup<T>
        => new GenericDifferentialStochasticProcess<T>(
            operand);
}