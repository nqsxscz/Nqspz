using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IProcess<T> Sinh<T>(
        this IProcess<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Sinh);
    
    public static IProcess<T> Cosh<T>(
        this IProcess<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Cosh);
    
    public static IProcess<T> Tanh<T>(
        this IProcess<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Tanh);
    
    public static IProcess<T> Asinh<T>(
        this IProcess<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Asinh);
    
    public static IProcess<T> Acosh<T>(
        this IProcess<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Acosh);
    
    public static IProcess<T> Atanh<T>(
        this IProcess<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Atanh);
}