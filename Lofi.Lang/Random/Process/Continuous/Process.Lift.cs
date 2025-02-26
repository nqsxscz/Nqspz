using Lofi.Lang.Random.Process.Continuous.Instance.Implementation;
using Lofi.Lang.Random.Process.Continuous.Instance.Type;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IContinuousProcess<T3> Lift<T1, T2, T3>(
        IContinuousProcess<T1> left,
        IContinuousProcess<T2> right,
        Func<T1, T2, T3> combinator)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => new LiftContinuousProcess<T1, T2, T3>(
            left,
            right,
            combinator);
}