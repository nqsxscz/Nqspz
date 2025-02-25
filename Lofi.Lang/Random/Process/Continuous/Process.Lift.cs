using Lofi.Lang.Random.Process.Continuous.Instance.Implementation;
using Lofi.Lang.Random.Process.Continuous.Instance.Type;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IProcess<T3> Lift<T1, T2, T3>(
        IProcess<T1> left,
        IProcess<T2> right,
        Func<T1, T2, T3> combinator)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => new LiftProcess<T1, T2, T3>(
            left,
            right,
            combinator);
}