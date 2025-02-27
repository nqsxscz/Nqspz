using Lofi.Lang.Model.Random.Trajectory.Type;
using Lofi.Lang.Model.Random.Trajectory.TypeConstructor;
using Lofi.Prelude.Data.Instance.Seq.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Trajectory;

public static class RandomTrajectory
{
    public static ISeq<T> ToSeq<T>(
        this ITrajectory<T> trajectory)
        where T : notnull
        => throw new NotImplementedException();
    
    public static ITrajectory<T> ToTrajectory<T>(
        this ITypeConstructor<ITrajectory, T> operand)
        where T : notnull
        => (ITrajectory<T>) operand;

    public static ITrajectory<T> ToTrajectory<T>(
        this ISeq<T> operand)
        where T : notnull
        => throw new NotImplementedException();

    public static ITrajectory<T2> Select<T1, T2>(
        this ITrajectory<T1> operand,
        Func<T1, T2> selector)
        where T1 : notnull
        where T2 : notnull
        => throw new NotImplementedException();
    
    public static ITrajectory<T3> Lift<T1, T2, T3>(
        ITrajectory<T1> left,
        ITrajectory<T2> right,
        Func<T1, T2, T3> combinator)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => throw new NotImplementedException();
    
    public static ITrajectory<(T1, T2)> Zip<T1, T2>(
        this ITrajectory<T1> operand1,
        ITrajectory<T2> operand2)
        where T1 : notnull
        where T2 : notnull
        => throw new NotImplementedException();
    
    public static ITrajectory<(T1, T2, T3)> Zip<T1, T2, T3>(
        ITrajectory<T1> operand1,
        ITrajectory<T2> operand2,
        ITrajectory<T3> operand3)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => throw new NotImplementedException();
    
    public static ITrajectory<(T1, T2, T3, T4)> Zip<T1, T2, T3, T4>(
        ITrajectory<T1> operand1,
        ITrajectory<T2> operand2,
        ITrajectory<T3> operand3,
        ITrajectory<T4> operand4)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        where T4 : notnull
        => throw new NotImplementedException();
    
    public static ITrajectory<T2> ScanLeft<T1, T2>(
        this ITrajectory<T1> operand,
        T2 init,
        Func<T2, T1, T2> accumulator)
        where T1 : notnull
        where T2 : notnull
        => throw new NotImplementedException();

    public static ITrajectory<T3> ScanLeft<T1, T2, T3>(
        ITrajectory<T1> operand1,
        ITrajectory<T2> operand2,
        T3 init,
        Func<T3, T1, T2, T3> accumulator)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => operand1
            .Zip(operand2)
            .ScanLeft(
                init,
                (x, t) => 
                    accumulator(
                        x, 
                        t.Item1, 
                        t.Item2));
    
    public static ITrajectory<T4> ScanLeft<T1, T2, T3, T4>(
        ITrajectory<T1> operand1,
        ITrajectory<T2> operand2,
        ITrajectory<T3> operand3,
        T4 init,
        Func<T4, T1, T2, T3, T4> accumulator)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        where T4 : notnull
        => Zip(
                operand1,
                operand2,
                operand3)
            .ScanLeft(
                init,
                (x, t) => 
                    accumulator(
                        x, 
                        t.Item1, 
                        t.Item2, 
                        t.Item3));
    
    public static ITrajectory<T5> ScanLeft<T1, T2, T3, T4, T5>(
        ITrajectory<T1> operand1,
        ITrajectory<T2> operand2,
        ITrajectory<T3> operand3,
        ITrajectory<T4> operand4,
        T5 init,
        Func<T5, T1, T2, T3, T4, T5> accumulator)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        where T4 : notnull
        where T5 : notnull
        => Zip(
                operand1,
                operand2,
                operand3,
                operand4)
            .ScanLeft(
                init,
                (x, t) => 
                    accumulator(
                        x, 
                        t.Item1, 
                        t.Item2, 
                        t.Item3, 
                        t.Item4));
}