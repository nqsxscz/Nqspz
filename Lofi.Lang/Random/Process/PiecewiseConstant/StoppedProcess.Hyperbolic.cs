using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class StoppedProcess
{
    public static IStoppedProcess<T> Sinh<T>(
        this IStoppedProcess<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Sinh);
    
    public static IStoppedProcess<T> Cosh<T>(
        this IStoppedProcess<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Cosh);
    
    public static IStoppedProcess<T> Tanh<T>(
        this IStoppedProcess<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Tanh);
    
    public static IStoppedProcess<T> Asinh<T>(
        this IStoppedProcess<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Asinh);
    
    public static IStoppedProcess<T> Acosh<T>(
        this IStoppedProcess<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Acosh);
    
    public static IStoppedProcess<T> Atanh<T>(
        this IStoppedProcess<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Atanh);
}