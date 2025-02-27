using Lofi.Lang.Stochastic.Process.Continuous.Instance.Implementation.Differential;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Differential;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Wiener;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Stochastic.Process.Continuous;

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
        this IWienerStochasticProcess<T> operand,
        Func<TimeSpan, T> converter)
        where T : IReal<T>
        => new WienerDifferentialStochasticProcess<T>(
            operand,
            converter);
    
    public static IDifferentialStochasticProcess<T> Differentiate<T>(
        this IStochasticProcess<T> operand)
        where T : IAdditiveGroup<T>
        => new GenericDifferentialStochasticProcess<T>(
            operand);
}