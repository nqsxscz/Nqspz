using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Observable.Temporal.Continuous;

public static partial class Temporal
{
    public static ITemporal<T> Sin<T>(
        this ITemporal<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Sin);
    
    public static ITemporal<T> Cos<T>(
        this ITemporal<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Cos);
    
    public static ITemporal<T> Tan<T>(
        this ITemporal<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Tan);
    
    public static ITemporal<T> Asin<T>(
        this ITemporal<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Asin);
    
    public static ITemporal<T> Acos<T>(
        this ITemporal<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Acos);
    
    public static ITemporal<T> Atan<T>(
        this ITemporal<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Atan);
}