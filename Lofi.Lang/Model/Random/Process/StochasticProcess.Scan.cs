using Lofi.Lang.Model.Random.Process.Instance.Type;
using Lofi.Prelude.Algebra.Trait;
using Lofi.Prelude.Data;

namespace Lofi.Lang.Model.Random.Process;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T3> Scan<T1, T2, T3>(
        this IStochasticProcess<T1> operand1,
        IStochasticProcess<T2> operand2,
        T3 init,
        Func<T3, T1, T2, T3> accumulator)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => throw new NotImplementedException();
    
    public static IStochasticProcess<T4> Scan<T1, T2, T3, T4>(
        this IStochasticProcess<T1> operand1,
        IStochasticProcess<T2> operand2,
        IStochasticProcess<T2> operand3,
        T4 init,
        Func<T4, T1, T2, T3, T4> accumulator)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        where T4 : notnull
        => throw new NotImplementedException();
    
    public static IStochasticProcess<T> Scan<T>(
        this IStochasticProcess<T> operand)
        where T : IMonoid<T>
        => operand
            .Scan(
                T.Identity, 
                T.Combine);

    public static IStochasticProcess<T> Scan<T>(
        this IStochasticProcess<T> operand,
        T init,
        Func<T, T, T> accumulator)
        where T : notnull
        => operand
            .ScanLeft(
                init, 
                accumulator);
    
    public static IStochasticProcess<T2> ScanRight<T1, T2>(
        this IStochasticProcess<T1> operand,
        T2 init,
        Func<T1, T2, T2> accumulator)
        where T1 : notnull
        where T2 : notnull
        => operand
            .ScanLeft(
                init, 
                accumulator.Flip());

    public static IStochasticProcess<T2> ScanLeft<T1, T2>(
        this IStochasticProcess<T1> operand,
        T2 init,
        Func<T2, T1, T2> accumulator)
        where T1 : notnull
        where T2 : notnull
        => throw new NotImplementedException();
}