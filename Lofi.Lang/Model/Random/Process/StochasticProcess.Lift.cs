using Lofi.Lang.Model.Random.Process.Instance.Type;

namespace Lofi.Lang.Model.Random.Process;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T3> Lift<T1, T2, T3>(
        IStochasticProcess<T1> left,
        IStochasticProcess<T2> right,
        Func<T1, T2, T3> combinator)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => throw new NotImplementedException();
}