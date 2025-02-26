using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Lang.Random.Sequence;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class Process
{
    public static IPiecewiseConstantContinuousProcess<T3> Lift<T1, T2, T3>(
        IPiecewiseConstantContinuousProcess<T1> left,
        IPiecewiseConstantContinuousProcess<T2> right,
        Func<T1, T2, T3> combinator)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => Continuous.Process.Lift(
                left,
                right,
                combinator)
            .Discretize(
                left.StoppingSequence
                    .Union(
                        right.StoppingSequence));

    public static IPiecewiseConstantContinuousProcess<T3> Lift<T1, T2, T3>(
        IContinuousProcess<T1> left,
        IPiecewiseConstantContinuousProcess<T2> right,
        Func<T1, T2, T3> combinator)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => Lift(
            left.Discretize(
                right.StoppingSequence),
            right,
            combinator);

    public static IPiecewiseConstantContinuousProcess<T3> Lift<T1, T2, T3>(
        IPiecewiseConstantContinuousProcess<T1> left,
        IContinuousProcess<T2> right,
        Func<T1, T2, T3> combinator)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => Lift(
            left,
            right.Discretize(
                left.StoppingSequence),
            combinator);
}