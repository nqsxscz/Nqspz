using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Prelude.Numeric;

public static class Real
{
    public static double ToDouble<T>(this T t)
        where T : IReal<T>
        => T.ToDouble(t);
    
    public static T ToReal<T>(this double x)
        where T : IReal<T>
        => T.FromDouble(x);

    public static T Pi<T>()
        where T : IReal<T>
        => T.Pi;
    
    public static T E<T>()
        where T : IReal<T>
        => T.E;
    
    public static T Sqrt<T>(this T t)
        where T : IReal<T>
        => T.Sqrt(t);
    
    public static T Log<T>(this T t)
        where T : IReal<T>
        => T.Log(t);
    
    public static T Exp<T>(this T t)
        where T : IReal<T>
        => T.Exp(t);
    
    public static T Sin<T>(this T t)
        where T : IReal<T>
        => T.Sin(t);
    
    public static T Cos<T>(this T t)
        where T : IReal<T>
        => T.Cos(t);
    
    public static T Tan<T>(this T t)
        where T : IReal<T>
        => T.Tan(t);
    
    public static T Sinh<T>(this T t)
        where T : IReal<T>
        => T.Sinh(t);
    
    public static T Cosh<T>(this T t)
        where T : IReal<T>
        => T.Cosh(t);
    
    public static T Tanh<T>(this T t)
        where T : IReal<T>
        => T.Tanh(t);
    
    public static T Asin<T>(this T t)
        where T : IReal<T>
        => T.Asin(t);
    
    public static T Acos<T>(this T t)
        where T : IReal<T>
        => T.Acos(t);
    
    public static T Atan<T>(this T t)
        where T : IReal<T>
        => T.Atan(t);
    
    public static T Asinh<T>(this T t)
        where T : IReal<T>
        => T.Asinh(t);
    
    public static T Acosh<T>(this T t)
        where T : IReal<T>
        => T.Acosh(t);
    
    public static T Atanh<T>(this T t)
        where T : IReal<T>
        => T.Atanh(t);
    
    public static T Power<T>(
        this T left, 
        T right)
        where T : IReal<T>
        => left ^ right;
}