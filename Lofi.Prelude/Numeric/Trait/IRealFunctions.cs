namespace Lofi.Prelude.Numeric.Trait;

public interface IRealFunctions<T>
    where T : IRealFunctions<T>
{
    static abstract T Pi { get; }
    
    static abstract T E { get; }
    
    static abstract T Sqrt(T t);
    
    static abstract T Log(T t);
    
    static abstract T Exp(T t);
    
    static abstract T Sin(T t);
    
    static abstract T Cos(T t);
    
    static abstract T Tan(T t);
    
    static abstract T Asin(T t);
    
    static abstract T Acos(T t);
    
    static abstract T Atan(T t);
}