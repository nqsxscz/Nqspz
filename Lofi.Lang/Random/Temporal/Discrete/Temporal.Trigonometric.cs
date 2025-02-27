using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T> Sin<T>(
        this IDiscreteTemporal<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Sin);
    
    public static IDiscreteTemporal<T> Cos<T>(
        this IDiscreteTemporal<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Cos);
    
    public static IDiscreteTemporal<T> Tan<T>(
        this IDiscreteTemporal<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Tan);
    
    public static IDiscreteTemporal<T> Asin<T>(
        this IDiscreteTemporal<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Asin);
    
    public static IDiscreteTemporal<T> Acos<T>(
        this IDiscreteTemporal<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Acos);
    
    public static IDiscreteTemporal<T> Atan<T>(
        this IDiscreteTemporal<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Atan);
}