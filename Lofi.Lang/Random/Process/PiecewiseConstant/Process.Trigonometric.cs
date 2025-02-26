using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class Process
{
    public static IPiecewiseConstantContinuousProcess<T> Sin<T>(
        this IPiecewiseConstantContinuousProcess<T> operand)
        where T : IRealFunctions<T>
        => operand
            .Select(
                T.Sin);
    
    public static IPiecewiseConstantContinuousProcess<T> Cos<T>(
        this IPiecewiseConstantContinuousProcess<T> operand)
        where T : IRealFunctions<T>
        => operand
            .Select(
                T.Cos);
    
    public static IPiecewiseConstantContinuousProcess<T> Tan<T>(
        this IPiecewiseConstantContinuousProcess<T> operand)
        where T : IRealFunctions<T>
        => operand
            .Select(
                T.Tan);
    
    public static IPiecewiseConstantContinuousProcess<T> Asin<T>(
        this IPiecewiseConstantContinuousProcess<T> operand)
        where T : IRealFunctions<T>
        => operand
            .Select(
                T.Asin);
    
    public static IPiecewiseConstantContinuousProcess<T> Acos<T>(
        this IPiecewiseConstantContinuousProcess<T> operand)
        where T : IRealFunctions<T>
        => operand
            .Select(
                T.Acos);
    
    public static IPiecewiseConstantContinuousProcess<T> Atan<T>(
        this IPiecewiseConstantContinuousProcess<T> operand)
        where T : IRealFunctions<T>
        => operand
            .Select(
                T.Atan);
}