using Lofi.Lang.Model.Random.Process.Continuous.Instance.Implementation.Lift;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;

namespace Lofi.Lang.Model.Random.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T3> Lift<T1, T2, T3>(
        IStochasticProcess<T1> left,
        IStochasticProcess<T2> right,
        Func<T1, T2, T3> combinator)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => new LiftStochasticProcess<T1,T2,T3>(
            left, 
            right, 
            combinator);
}