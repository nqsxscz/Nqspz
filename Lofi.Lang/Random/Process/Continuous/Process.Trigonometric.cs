using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IContinuousProcess<T> Sin<T>(
        this IContinuousProcess<T> operand)
        where T : IRealFunctions<T>
        => operand
            .Select(
                T.Sin);
    
    public static IContinuousProcess<T> Cos<T>(
        this IContinuousProcess<T> operand)
        where T : IRealFunctions<T>
        => operand
            .Select(
                T.Cos);
    
    public static IContinuousProcess<T> Tan<T>(
        this IContinuousProcess<T> operand)
        where T : IRealFunctions<T>
        => operand
            .Select(
                T.Tan);
    
    public static IContinuousProcess<T> Asin<T>(
        this IContinuousProcess<T> operand)
        where T : IRealFunctions<T>
        => operand
            .Select(
                T.Asin);
    
    public static IContinuousProcess<T> Acos<T>(
        this IContinuousProcess<T> operand)
        where T : IRealFunctions<T>
        => operand
            .Select(
                T.Acos);
    
    public static IContinuousProcess<T> Atan<T>(
        this IContinuousProcess<T> operand)
        where T : IRealFunctions<T>
        => operand
            .Select(
                T.Atan);
}