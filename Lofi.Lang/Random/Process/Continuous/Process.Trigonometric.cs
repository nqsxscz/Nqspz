using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IProcess<T> Sin<T>(
        this IProcess<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Sin);
    
    public static IProcess<T> Cos<T>(
        this IProcess<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Cos);
    
    public static IProcess<T> Tan<T>(
        this IProcess<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Tan);
    
    public static IProcess<T> Asin<T>(
        this IProcess<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Asin);
    
    public static IProcess<T> Acos<T>(
        this IProcess<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Acos);
    
    public static IProcess<T> Atan<T>(
        this IProcess<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Atan);
}