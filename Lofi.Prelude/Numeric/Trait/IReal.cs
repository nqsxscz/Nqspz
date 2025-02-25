namespace Lofi.Prelude.Numeric.Trait;

public interface IReal<T> : 
    INatural<T>
    where T : IReal<T>
{
    static abstract double ToDouble(T t);
    
    static abstract T FromDouble(double i);

    static virtual T Pi
        => double.Pi
            .ToReal<T>();
    
    static virtual T E
        => double.E
            .ToReal<T>();
    
    static virtual T Sqrt(T t)
        => Lift(t, double.Sqrt);
    
    static virtual T Log(T t)
        => Lift(t, double.Log);
    
    static virtual T Exp(T t)
        => Lift(t, double.Exp);
    
    static virtual T Sin(T t)
        => Lift(t, double.Sin);
    
    static virtual T Cos(T t)
        => Lift(t, double.Cos);
    
    static virtual T Tan(T t)
        => Lift(t, double.Tan);
    
    static virtual T Sinh(T t)
        => Lift(t, double.Sinh);
    
    static virtual T Cosh(T t)
        => Lift(t, double.Cosh);
    
    static virtual T Tanh(T t)
        => Lift(t, double.Tanh);
    
    static virtual T Asin(T t)
        => Lift(t, double.Asin);
    
    static virtual T Acos(T t)
        => Lift(t, double.Acos);
    
    static virtual T Atan(T t)
        => Lift(t, double.Atan);
    
    static virtual T Asinh(T t)
        => Lift(t, double.Asinh);
    
    static virtual T Acosh(T t)
        => Lift(t, double.Acosh);
    
    static virtual T Atanh(T t)
        => Lift(t, double.Atanh);
    
    static virtual T Power(
        T left, 
        T right)
        => Lift(
            left, 
            right, 
            double.Pow);
    
    private static T Lift(
        T t, 
        Func<double, double> @operator)
        => @operator(
                t.ToDouble())
            .ToReal<T>();
    
    private static T Lift(
        T left, 
        T right, 
        Func<double, double, double> @operator)
        => @operator(
                left.ToDouble(), 
                right.ToDouble())
            .ToReal<T>();
}