using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class StoppedProcess
{
    public static IStoppedProcess<T> Sin<T>(
        this IStoppedProcess<T> operand)
        where T : IRealFunctions<T>
        => operand
            .Select(
                T.Sin);
    
    public static IStoppedProcess<T> Cos<T>(
        this IStoppedProcess<T> operand)
        where T : IRealFunctions<T>
        => operand
            .Select(
                T.Cos);
    
    public static IStoppedProcess<T> Tan<T>(
        this IStoppedProcess<T> operand)
        where T : IRealFunctions<T>
        => operand
            .Select(
                T.Tan);
    
    public static IStoppedProcess<T> Asin<T>(
        this IStoppedProcess<T> operand)
        where T : IRealFunctions<T>
        => operand
            .Select(
                T.Asin);
    
    public static IStoppedProcess<T> Acos<T>(
        this IStoppedProcess<T> operand)
        where T : IRealFunctions<T>
        => operand
            .Select(
                T.Acos);
    
    public static IStoppedProcess<T> Atan<T>(
        this IStoppedProcess<T> operand)
        where T : IRealFunctions<T>
        => operand
            .Select(
                T.Atan);
}