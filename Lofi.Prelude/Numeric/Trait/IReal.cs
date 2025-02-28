using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Prelude.Numeric.Trait;

public interface IReal<T> : 
    INatural<T>,
    IField<T>
    where T : IReal<T>
{
    static abstract T FromDouble(double x);
    
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
    
    static abstract T operator ^(
        T left, 
        T right);

    static T INatural<T>.FromInt(int n)
        => T.FromDouble(n);
}