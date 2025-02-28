using Lofi.Lang.Stochastic.Trajectory.Implementation;
using Lofi.Lang.Stochastic.Trajectory.Type;
using Lofi.Lang.Stochastic.Trajectory.TypeConstructor;
using Lofi.Prelude.Control;
using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Data.Control;
using Lofi.Prelude.Data.Control.Instance.Seq.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Stochastic.Trajectory;

public static class RandomTrajectory
{
    public static ISeq<T> ToSeq<T>(
        this ITrajectory<T> trajectory)
        where T : notnull
        => trajectory switch
        {
            ISeqTrajectory<T> { Values: var values} =>
                values,
            _ => Seq.Empty<T>()
        };
    
    public static ITrajectory<T> ToTrajectory<T>(
        this ITypeConstructor<ITrajectory, T> operand)
        where T : notnull
        => (ITrajectory<T>) operand;

    public static ITrajectory<T> ToTrajectory<T>(
        this ISeq<T> values)
        where T : notnull
        => new SeqTrajectory<T>(values);
    
    public static ITrajectory<T> ToTrajectory<T>(
        this T t)
        where T : notnull
        => t.ToSeq()
            .ToTrajectory();

    public static ITrajectory<T2> Select<T1, T2>(
        this ITrajectory<T1> operand,
        Func<T1, T2> selector)
        where T1 : notnull
        where T2 : notnull
        => operand
            .ToSeq()
            .Enumerable
            .Select(selector)
            .ToSeq()
            .ToTrajectory();

    public static ITrajectory<T3> Lift<T1, T2, T3>(
        ITrajectory<T1> left,
        ITrajectory<T2> right,
        Func<T1, T2, T3> combinator)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => left
            .ToSeq()
            .Lift(
                right.ToSeq(), 
                combinator)
            .ToSeq()
            .ToTrajectory();

    public static ITrajectory<T2> ScanRight<T1, T2>(
        this ITrajectory<T1> operand,
        T2 init,
        Func<T1, T2, T2> accumulator)
        where T1 : notnull
        where T2 : notnull
        => operand
            .ToSeq()
            .ScanRight(
                init,
                accumulator)
            .ToSeq()
            .ToTrajectory();

    public static T2 AggregateRight<T1, T2>(
        this ITrajectory<T1> operand,
        T2 init,
        Func<T1, T2, T2> accumulator)
        where T1 : notnull
        where T2 : notnull
        => operand
            .ToSeq()
            .AggregateRight(
                init,
                accumulator);

    public static ITypeConstructor<TF, ITrajectory<T2>>
        Traverse<TF, T1, T2>(
            this ITrajectory<T1> operand,
            Func<T1, ITypeConstructor<TF, T2>> traverse)
        where TF : IApplicative<TF>
        where T1 : notnull
        where T2 : notnull
        => operand
            .ToSeq()
            .Traverse(traverse)
            .Select(Seq.ToSeq)
            .Select(ToTrajectory);
}